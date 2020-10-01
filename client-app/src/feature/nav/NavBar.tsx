import { observer } from 'mobx-react-lite';
import React from 'react';
import { NavLink } from 'react-router-dom';
import { Menu, Container, Button } from 'semantic-ui-react';

interface IProps {
    toggleRenderCountriesView: () => void;
    toggleRenderActivityView: () => void;
}

const NavBar: React.FC<IProps> = ({
    toggleRenderCountriesView,
    toggleRenderActivityView
}) => {
    return (
        <div> <Menu fixed='top' inverted>
         <Container>
            <Menu.Item header as={NavLink} exact to='/'>
                <img src="/assets/logo.png" alt="logo" style={{marginRight:'10px'}}/>
                 Reactivities   
            </Menu.Item>
            <Menu.Item name='Activites' onClick={toggleRenderActivityView} as={NavLink} to='/activities'/>
            <Menu.Item name='Countries' onClick={toggleRenderCountriesView} as={NavLink} to='/countries'/>
            <Menu.Item name='friends'>
                <Button positive content='Create Activity' as={NavLink} exact to='/createActivity'></Button>
            </Menu.Item>     
        </Container>   
        
      </Menu>
        </div>
    )
}

export default observer(NavBar);
