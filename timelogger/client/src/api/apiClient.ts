import axios from "axios";

const axiosInstance = axios.create({
    baseURL: 'http://localhost:3001/api',
  });
  
  class APIClient<T> {
    endpoint: string;
  
    constructor(endpoint: string) {
      this.endpoint = endpoint;
    }
  
    getAll = () => {
      return axiosInstance
        .get<T[]>(this.endpoint)
        .then((res) => res.data);
    }

    post = (data: T) => {
      return axiosInstance
        .post<T>(this.endpoint, data)
        .then(res => res.data);
    }

    update = (data: T) => {
      return axiosInstance
        .patch<T>(this.endpoint, data)
        .then(res => res.data);
    }
  }
  
  export default APIClient;
  