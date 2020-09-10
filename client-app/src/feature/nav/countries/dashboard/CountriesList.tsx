import React from 'react'
import { Segment, Item, Button, Label } from 'semantic-ui-react'
import { ICountry } from '../../../../app/models/country'

interface IProps 
{
    countries: ICountry[]
}

const CountriesList: React.FC<IProps> = ({countries}) => {
    return (
        <Segment clearing>
            <Item.Group divided>
                {countries.map(country => (
                <Item key={country.id}>
                <Item.Content>
                {/* <Item.Header as='a'>{country.title}</Item.Header> */}
                {/* <Item.Meta>{country.date}</Item.Meta> */}
                    <Item.Description>
                    {/* <div>{country.description}</div> */}
                    {/* <div>{country.city}, {country.venue}</div> */}
                    </Item.Description>
                    <Item.Extra>
                        <Button
                        floated='right'
                        content='View'
                        color='blue'
                        />
                        <Button
                        floated='right'
                        content='Delete'
                        color='red'
                        />
                        {/* <Label basic content={country.category}/> */}
                    </Item.Extra>
                </Item.Content>
                </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}

export default CountriesList;
