import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Menu, Container, Button, Dropdown, Image } from 'semantic-ui-react';
import { RootStoreContext } from '../../app/stores/rootStore';

interface IProps {
    toggleRenderCountriesView: () => void;
    toggleRenderActivityView: () => void;
}

const NavBar: React.FC<IProps> = ({
    toggleRenderCountriesView,
    toggleRenderActivityView
}) => {
    const rootStore = useContext(RootStoreContext);
    const { user, logout } = rootStore.userStore;
    return (
        <div> <Menu fixed='top' inverted>
         <Container>
            <Menu.Item header as={NavLink} exact to='/'>
                <img src="/assets/logo.png" alt="logo" style={{marginRight:'10px'}}/>
                 Reactivities   
            </Menu.Item>
            <Menu.Item
              name='Activites'
              onClick={toggleRenderActivityView}
              as={NavLink}
              to='/activities'
            />
            <Menu.Item
              name='Countries'
              onClick={toggleRenderCountriesView}
              as={NavLink}
              to='/countries'
            />
            <Menu.Item name='friends'>
                <Button
                  positive content='Create Activity'
                  as={NavLink}
                  exact to='/createActivity'
                >
                </Button>
            </Menu.Item>
            {user && 
                        <Menu.Item position='right'>
                          <Image avatar spaced='right' src={user.image || '/assets/user.png'} />
                          <Dropdown pointing='top left' text={user.displayName}>
                            <Dropdown.Menu>
                              <Dropdown.Item 
                              as={Link}
                              to={`/profile/${user.username}`}
                              text='My profile'
                              icon='user'
                              />
                              <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                            </Dropdown.Menu>
                          </Dropdown>
                        </Menu.Item>
            }  
        </Container>   
        
      </Menu>
        </div>
    )
}

export default observer(NavBar);
