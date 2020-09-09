import React, { useState, useEffect, Fragment } from 'react';
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { IActivity } from '../models/activity';
import NavBar from '../../feature/nav/NavBar';
import ActivityDashboard from '../../feature/nav/activities/dashboard/ActivityDashboard';

const App = () => {
  const [activities, setActivities] = useState<IActivity[]> ([]);  

  useEffect(() => {
        axios
        .get<IActivity[]>('http://localhost:5000/api/activities')
        .then((response) => {
          setActivities(response.data)
        });
  }, []);

    return (
      <Fragment>
            <NavBar/>
              <Container style={{marginLeft: '7em', padding: 70}}>
                <ActivityDashboard activities={activities}/>
              </Container>
      </Fragment>
    );
}

export default App;
