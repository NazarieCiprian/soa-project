import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Freight } from "../model/Freight";
import { ApiUrls } from "./ApiUrls";

@Injectable()
export class FreightsService {
    constructor(private httpClient: HttpClient) {

    }

    getFreights(): Observable<Freight[]> {
        return this.httpClient.get<Freight[]>(ApiUrls.getFreights);
    }

    addFreight(freight: any): Observable<Freight> {
        return this.httpClient.post<Freight>(ApiUrls.addFreight, freight);
    }
}