export interface ICar {
    color: string;
    brand: string;
    model?: string;
    topSpeed?: number; 
}

const Car1 : ICar = {
    color: 'blue',
    brand: 'BMW',
    model: '525',
    topSpeed: 212
}

const Car2 : ICar = {
    color: 'red',
    brand: 'Toyota',
    topSpeed: 148
}

export const cars = [Car1, Car2];