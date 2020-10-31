import axios, { AxiosResponse } from 'axios';
import { IActivitiesEnvelope, IActivity } from '../models/activity';
import { history } from '../..';
import { toast } from 'react-toastify';
import { IUser, IUserFormValues } from '../models/user';
import { IPhoto, IProfile } from '../models/profile';

// axios.defaults.baseURL = 'http://localhost:5000/api';
axios.defaults.baseURL = process.env.REACT_APP_API_URL;

axios.interceptors.request.use((config) => {
    const token = window.localStorage.getItem('jwt');
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
}, error => {
    return Promise.reject(error);
})

axios.interceptors.response.use(undefined,error => {
    if(error.message === 'Network Error' && !error.response)
    {
        toast.error('Network error - make sure API is running!');
    }
    const{status, data, config, headers} = error.response;
    if(error.response.status === 404)
    {
        history.push('/notfound');
    }
    if(status === 401 && headers["www-authenticate"].toString()
        .includes('Bearer error="invalid_token", error_description="The token expire'))
    {
        console.log(error.response);
        window.localStorage.removeItem('jwt');
        history.push('/');
        toast.info('Your session has expired, please login again');
    }
    if(status === 400 && config.method === 'get' && data.errors.hasOwnProperty('id'))
    {
        history.push('/notfound');
    }
    if(status === 500)
    {
        toast.error('Server error - check the terminal for more info!');
    }
    throw error.response;
});

const responseBody = (response: AxiosResponse) => response.data;
// const sleep = (ms: number) => (response: AxiosResponse) => 
//     new Promise<AxiosResponse>(resolve => setTimeout(() => resolve(response), ms));

const requests = {
    get: (url: string) => axios.get(url)
        // .then(sleep(2000))
        .then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body)
        // .then(sleep(2000))
        .then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body)
        // .then(sleep(2000))
        .then(responseBody),
    del: (url: string) => axios.delete(url)
        // .then(sleep(2000))
        .then(responseBody),
    postForm: (url: string, file: Blob) => {
        let formData = new FormData();
        formData.append('File', file);
        return axios.post(url, formData, {
            headers: {'Content-type': 'multipart/form-data'}
        }).then(responseBody);
    }
}

const Activities = {
    list: (params: URLSearchParams): Promise<IActivitiesEnvelope> =>
        axios.get('/activities', {params: params})
            // .then(sleep(1000))
            .then(responseBody),
    details: (id: string) => requests.get(`/activities/${id}`),
    create: (activity: IActivity) => requests.post('/activities', activity),
    update: (activity: IActivity) => requests.put(`/activities/${activity.id}`, activity),
    delete: (id: string) => requests.del(`/activities/${id}`),
    attend: (id: string) => requests.post(`/activities/${id}/attend`, {}),
    unattend: (id: string) => requests.del(`/activities/${id}/attend`)
};

const User = {
    current: (): Promise<IUser> => requests.get('/user'),
    loggin: (user: IUserFormValues) : Promise<IUser> => requests.post('/user/login', user),
    register: (user: IUserFormValues) : Promise<IUser> => requests.post('/user/register', user),
    fbLogin: (accessToken: string) => requests.post(`/user/facebook`, {accessToken}),
    refreshToken: (): Promise<IUser> => requests.post(`/user/refreshToken`, {}) 
}

const Profiles = {
    get: (username: string): Promise<IProfile> => requests.get(`/profile/${username}`),
    uploadPhoto: (photo: Blob): Promise<IPhoto> => requests.postForm(`/photos`, photo),
    setMainPhoto: (id: string) => requests.post(`/photos/${id}/setMain`, {}),
    deletePhoto: (id: string) => requests.del(`/photos/${id}`),
    follow: (username: string) => requests.post(`/profile/${username}/follow`, {}),
    unfollow: (username: string) => requests.del(`/profile/${username}/follow`),
    listFollowings: (username: string, predicate: string) => requests.get(`/profile/${username}/follow?predicate=${predicate}`),
    listActivities: (username: string, predicate: string) =>
        requests.get(`/profile/${username}/activities?predicate=${predicate}`)
};


export default {
    Activities,
    User, 
    Profiles
}