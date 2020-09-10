import React from 'react';
import { Menu, Container, Button } from 'semantic-ui-react';

interface IProps {
    openCreateForm: () => void;
    toggleRenderCountriesView: () => void;
    toggleRenderActivityView: () => void;
}

const NavBar: React.FC<IProps> = ({
    openCreateForm,
    toggleRenderCountriesView,
    toggleRenderActivityView
    }) => {
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
                <Button positive content='Create Activity' onClick={openCreateForm}></Button>
            </Menu.Item>     
        </Container>   
        
      </Menu>
        </div>
    )
}

export default NavBar
