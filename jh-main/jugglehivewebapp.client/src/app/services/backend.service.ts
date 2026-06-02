import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class BackendService {

    constructor(protected http: HttpClient) {}

    getBackendUrl(): string {
        let Url: string = '';
        if (window.location.hostname.includes('localhost')) {
            Url = 'localhost';
            if (window.location.port === '4200') { Url = Url + ':7187' }
            else { Url = Url + ':8080' };
        } else {
            Url = window.location.hostname.split('.').slice(-2).join('.');
        }
        if (window.location.protocol === 'https:') {
            return 'https://' + Url + '/';
        } else {
            return 'http://' + Url + '/';
        }
    }
}