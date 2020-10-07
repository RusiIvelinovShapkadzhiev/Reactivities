import React, { useState, Fragment } from 'react';
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

const App : React.FC<RouteComponentProps> = ({location}) => {
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
  
    return (
      <Fragment>
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
                {/* {activityMode && (<Route exact path='/' component={HomePage}/>)}
                {activityMode && (<Route path='/activities' component={ActivityDashboard}/>)}
                {activityMode && (<Route path='/createActivity' component={ActivityForm}/>)} */}
                <Switch>
                  <Route exact path='/activities' component={ActivityDashboard}/>
                  <Route path='/activities/:id' component={ActivityDetails}/>
                  <Route 
                    key={location.key}
                    path={['/createActivity', '/manage/:id']}
                    component={ActivityForm}/>
                  <Route component={NotFound} />
                </Switch>
              </Container>

          </Fragment>
        )}/>
      </Fragment>
    );
}

export default withRouter(observer(App));
