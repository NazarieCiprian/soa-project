import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthInfo } from "../model/AuthInfo";
import { ApiUrls } from "./ApiUrls";

@Injectable()
export class AuthenticationService {
    constructor(private httpClient: HttpClient) {

    }

    authenticate(authInput: any): Observable<any> {
        return this.httpClient.post<any>(ApiUrls.authenticate, authInput);
    }

    public getToken(): string {
        return localStorage.getItem('token');
    }
}