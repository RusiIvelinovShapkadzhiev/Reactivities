import React, { useState, Fragment, useContext, useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from '../../feature/nav/NavBar';
import ActivityDashboard from '../../feature/nav/activities/dashboard/ActivityDashboard';
import CountriesDashBoard from '../../feature/nav/countries/dashboard/CountriesDashBoard';
import { observer } from 'mobx-react-lite';
import { Route, RouteComponentProps, Switch, withRouter } from 'react-router-dom';
import { HomePage } from '../../feature/nav/home/HomePage';
import ActivityForm from '../../feature/nav/activities/dashboard/form/ActivityForm';
import ActivityDetails from '../../feature/nav/activities/dashboard/details/ActivityDetails';
import NotFound from './NotFound';
import { ToastContainer } from 'react-toastify';
import { RootStoreContext } from '../stores/rootStore';
import { LoadingComponent } from './LoadingComponent';
import ModalContainer from '../common/modals/ModalContainer';
import ProfilePage from '../../feature/profiles/ProfilePage';

const App : React.FC<RouteComponentProps> = ({location}) => {
  const rootStore = useContext(RootStoreContext);
  const { setAppLoaded, token, appLoaded } = rootStore.commonStore;
  const {getUser} = rootStore.userStore;

  useEffect(() => {
    if (token) {
      getUser().finally(() => setAppLoaded())
    } else {
      setAppLoaded();
    }
  }, [getUser, setAppLoaded, token])
  
  const [countriesMode, setCountriesMode] = useState(false);
  const [activityMode, setActivitiesMode] = useState(true);
  const handleCountriesViewToggle = () => {
    setCountriesMode(true);
    setActivitiesMode(false);
  }
  
  const handleActivitiesViewToggle = () => {
    setActivitiesMode(true);
    setCountriesMode(false);
  }

  if(!appLoaded) return <LoadingComponent content="Loading app ..." />
  
    return (
      <Fragment>
        <ModalContainer />
        <ToastContainer position='bottom-right'/>
        <Route exact path='/' component={HomePage}/>
        <Route path={'/(.+)'} render={()=> (
          <Fragment>
            <NavBar 
            toggleRenderCountriesView={handleCountriesViewToggle}
            toggleRenderActivityView={handleActivitiesViewToggle}
            />
              <Container style={{marginLeft: '7em', padding: 70}}>
                {countriesMode && (<CountriesDashBoard></CountriesDashBoard>)}
                <Switch>
                  <Route exact path='/activities' component={ActivityDashboard}/>
                  <Route path='/activities/:id' component={ActivityDetails}/>
                  <Route 
                    key={location.key}
                    path={['/createActivity', '/manage/:id']}
                    component={ActivityForm}/>
                  <Route path='/profile/:username' component={ProfilePage}/>
                  <Route component={NotFound} />
                </Switch>
              </Container>

          </Fragment>
        )}/>
      </Fragment>
    );
}

export default withRouter(observer(App));
