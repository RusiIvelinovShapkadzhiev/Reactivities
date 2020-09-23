import React, { useState, useEffect, Fragment, useContext } from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from '../../feature/nav/NavBar';
import ActivityDashboard from '../../feature/nav/activities/dashboard/ActivityDashboard';
import CountriesDashBoard from '../../feature/nav/countries/dashboard/CountriesDashBoard';
import { LoadingComponent } from './LoadingComponent';
import ActivityStore from '../stores/activityStore';
import { observer } from 'mobx-react-lite';

const App = () => {
  const activityStore = useContext(ActivityStore);
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

  useEffect(() => {
        activityStore.loadActivities();
  }, [activityStore]);

  if (activityStore.loadingInitial)  return <LoadingComponent content = 'Loading activities ...'/>

    return (
      <Fragment>
            <NavBar 
            toggleRenderCountriesView={handleCountriesViewToggle}
            toggleRenderActivityView={handleActivitiesViewToggle}
            />
              <Container style={{marginLeft: '7em', padding: 70}}>
                {countriesMode && (<CountriesDashBoard></CountriesDashBoard>)}
                {activityMode && (<ActivityDashboard />)}
              </Container>
      </Fragment>
    );
}

export default observer(App);
