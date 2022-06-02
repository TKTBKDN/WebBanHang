import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    constructor(private baseService: BaseService) {

    }

    login(data) {
        var res = this.baseService.post('/login', data);
        res.then(a => console.log("a", a))
        return res;
    }
}
