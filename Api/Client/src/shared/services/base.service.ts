import { Injectable } from '@angular/core';
import axios from 'axios';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class BaseService {
    get(url: string) {
        axios.get(`${environment.apiUrl}${url}`);
    }
    post(url: string, data: any) {
        const promise = axios.post(`${environment.apiUrl}${url}`, data);
        const result = promise.then((res) => res);
        console.log(result)
        return result;
    }
    put(url: string, data: any) {
        axios.put(`${environment.apiUrl}${url}`, data);
    }
    delete(url: string, data: any) {
        axios.delete(`${environment.apiUrl}${url}`, data);
    }
}
