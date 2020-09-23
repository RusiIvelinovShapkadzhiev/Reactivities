import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react';
import { Menu, Container, Button } from 'semantic-ui-react';
import ActivityStore from '../../app/stores/activityStore';

interface IProps {
    toggleRenderCountriesView: () => void;
    toggleRenderActivityView: () => void;
}

const NavBar: React.FC<IProps> = ({
    toggleRenderCountriesView,
    toggleRenderActivityView
}) => {
    const activityStore = useContext(ActivityStore);
    return (
        <div> <Menu fixed='top' inverted>
         <Container>
            <Menu.Item header>
                <img src="/assets/logo.png" alt="logo" style={{marginRight:'10px'}}/>
                 Reactivities   
            </Menu.Item>
            <Menu.Item name='Activites' onClick={toggleRenderActivityView}/>
            <Menu.Item name='Countries' onClick={toggleRenderCountriesView}/>
            <Menu.Item name='friends'>
                <Button positive content='Create Activity' onClick={activityStore.openCreateForm}></Button>
            </Menu.Item>     
        </Container>   
        
      </Menu>
        </div>
    )
}

export default observer(NavBar);
