import React from 'react';
import { Menu, Container, Button } from 'semantic-ui-react';

const NavBar = () => {
    return (
        <div> <Menu fixed='top' inverted>
         <Container>
            <Menu.Item header>
                <img src="/assets/quora.png" alt="logo" style={{marginRight:'10px'}}/>
                 Reactivities   
            </Menu.Item>
            <Menu.Item name='Activites'/>
            <Menu.Item name='friends'>
                <Button positive content='Create Activity'></Button>
            </Menu.Item>     
        </Container>   
        
      </Menu>
        </div>
    )
}

export default NavBar
