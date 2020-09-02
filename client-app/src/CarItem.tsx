import React from 'react';
import { ICar } from './demo';

interface IProps {
    car: ICar
}

const CarItem : React.FC<IProps> = (props) => {
    return (
        <div>
            <ul>
                <li>
                    {props.car.brand}
                </li>
                <li>
                    {props.car.color}
                </li>
                <li>
                    {props.car.topSpeed}
                </li>
                <li>
                    {props.car.model}
                </li>
            </ul>
            <h1>{props.car.brand}</h1>
        </div>
    )
}

export default CarItem;