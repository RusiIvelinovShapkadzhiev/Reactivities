import React, { useState, useEffect, Fragment } from 'react';
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { IActivity } from '../models/activity';
import NavBar from '../../feature/nav/NavBar';
import ActivityDashboard from '../../feature/nav/activities/dashboard/ActivityDashboard';
import CountriesDashBoard from '../../feature/nav/countries/dashboard/CountriesDashBoard';
import { ICountry } from '../models/country';

const App = () => {
  const [activities, setActivities] = useState<IActivity[]> ([]);
  const [countries, setCountries] = useState<ICountry[]> ([]);
  const [selecttedActivity, setSelectedActivity] = useState<IActivity | null>(null);
  const [editMode, setEditMode] = useState(false);
  const [countriesMode, setCountriesMode] = useState(false);
  const [activityMode, setActivitiesMode] = useState(true); 
  
  
  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.filter(a => a.id === id)[0]);
    setEditMode(false);
  };

  const handleOpenCreateForm = () => {
    setSelectedActivity(null);
    setEditMode(true);
  };

  const handleCreateActivity = (activity: IActivity) => {
    setActivities([...activities, activity]);
    setSelectedActivity(activity);
    setEditMode(false);
  };

  const handleEditActivity = (activity: IActivity) => {
    setActivities([...activities.filter(a => a.id !== activity.id), activity]);
    setSelectedActivity(activity);
    setEditMode(false);
  };

  const handleCountriesViewToggle = () => {
    setCountriesMode(true);
    setActivitiesMode(false);
  }

  const handleActivitiesViewToggle = () => {
    setActivitiesMode(true);
    setCountriesMode(false);
  }

  const handleDeleteActivity = (id: string) => {
    setActivities ([...activities.filter(a => a.id !== id)])
  }

  useEffect(() => {
        axios
        .get<IActivity[]>('http://localhost:5000/api/activities')
        .then((response) => {
          let activities: IActivity[] = [];
          response.data.forEach(activity => {
            activity.date = activity.date.split('.')[0];
            activities.push(activity);
          });
          setActivities(activities);
        });
  }, []);

    return (
      <Fragment>
            <NavBar 
            openCreateForm={handleOpenCreateForm}
            toggleRenderCountriesView={handleCountriesViewToggle}
            toggleRenderActivityView={handleActivitiesViewToggle}
            />
              <Container style={{marginLeft: '7em', padding: 70}}>
                {countriesMode && (<CountriesDashBoard></CountriesDashBoard>)}
                {activityMode && (<ActivityDashboard 
                activities={activities}
                selectActivity={handleSelectActivity}
                selectedActivity={selecttedActivity}
                editMode={editMode}
                setEditMode={setEditMode}
                setSelectedActivity={setSelectedActivity}
                createActivity={handleCreateActivity}
                editActivity={handleEditActivity}
                deleteActivity={handleDeleteActivity}
                />)}
              </Container>
      </Fragment>
    );
}

export default App;
