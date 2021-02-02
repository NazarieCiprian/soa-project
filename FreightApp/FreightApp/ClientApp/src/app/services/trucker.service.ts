import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Trucker } from "../model/trucker";

import { ApiUrls } from "./ApiUrls";
import { FreightsService } from "./freights.service";

@Injectable()
export class TruckerService {
    constructor(private httpClient: HttpClient) {

    }

    takeFreight(takeFreightDto:any): Observable<boolean> {
        return this.httpClient.post<boolean>(ApiUrls.takeFreight, takeFreightDto);
    }

    addTrucker(trucker: any): Observable<Trucker> {
        return this.httpClient.post<Trucker>(ApiUrls.addTrucker, trucker);
    }

    completeFreight() {

    }

    getTruckerFreights(truckerId:number):Observable<FreightsService[]> {
        return this.httpClient.get<FreightsService[]>(ApiUrls.getTruckerFreights+'?truckerId='+truckerId);
    }
}