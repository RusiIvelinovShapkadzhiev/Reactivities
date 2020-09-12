import React, { useState, useEffect, Fragment, SyntheticEvent } from 'react';
import { Container } from 'semantic-ui-react';
import { IActivity } from '../models/activity';
import NavBar from '../../feature/nav/NavBar';
import ActivityDashboard from '../../feature/nav/activities/dashboard/ActivityDashboard';
import CountriesDashBoard from '../../feature/nav/countries/dashboard/CountriesDashBoard';
import agent from '../api/agent';
import { LoadingComponent } from './LoadingComponent';

const App = () => {
  const [activities, setActivities] = useState<IActivity[]> ([]);
  const [selecttedActivity, setSelectedActivity] = useState<IActivity | null>(null);
  const [editMode, setEditMode] = useState(false);
  const [countriesMode, setCountriesMode] = useState(false);
  const [activityMode, setActivitiesMode] = useState(true); 
  const [loading, setLoading] = useState(true);
  const [submitting, setSubmitting]  = useState(false);
  const [target, setTarget] = useState(''); 
  
  
  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.filter(a => a.id === id)[0]);
    setEditMode(false);
  };

  const handleOpenCreateForm = () => {
    setSelectedActivity(null);
    setEditMode(true);
  };

  const handleCreateActivity = (activity: IActivity) => {
    setSubmitting(true);
    agent.Activities.create(activity).then(() => {
      setActivities([...activities, activity]);
      setSelectedActivity(activity);
      setEditMode(false);
    }).then(() => setSubmitting(false));
  };

  const handleEditActivity = (activity: IActivity) => {
    setSubmitting(true);
    agent.Activities.update(activity).then(() => {
      setActivities([...activities.filter(a => a.id !== activity.id), activity]);
      setSelectedActivity(activity);
      setEditMode(false);
    }).then(() => setSubmitting(false));
  };

  const handleCountriesViewToggle = () => {
    setCountriesMode(true);
    setActivitiesMode(false);
  }

  const handleActivitiesViewToggle = () => {
    setActivitiesMode(true);
    setCountriesMode(false);
  }

  const handleDeleteActivity = (event: SyntheticEvent<HTMLButtonElement>, id: string) => {
    setSubmitting(true);
    setTarget(event.currentTarget.name);
    agent.Activities.delete(id).then(() => {
      setActivities ([...activities.filter(a => a.id !== id)]);
    }).then(() => setSubmitting(false));;
  }

  useEffect(() => {
        agent.Activities.list()
        .then((response) => {
          let activities: IActivity[] = [];
          response.forEach((activity) => {
            activity.date = activity.date.split('.')[0];
            activities.push(activity);
          });
          setActivities(activities);
        }).then(() => setLoading(false));
  }, []);

  if (loading) return <LoadingComponent content = 'Loading activities ...'/>

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
                submitting={submitting}
                target={target}
                />)}
              </Container>
      </Fragment>
    );
}

export default App;
