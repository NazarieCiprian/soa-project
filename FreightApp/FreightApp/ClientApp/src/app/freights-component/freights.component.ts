import { Component, OnInit } from '@angular/core';
import { Freight } from '../model/Freight';
import { FreightsService } from '../services/freights.service';
import { BrowserModule } from '@angular/platform-browser';
import {CommonModule} from '@angular/common';
import { TruckerService } from '../services/trucker.service';
import { FreightStatus } from '../model/FreightStatus';
import { Router } from '@angular/router';
import { SignalRService } from '../services/signlar.service';

@Component({
    selector: 'app-freight',
    templateUrl: './freights.component.html',
    styleUrls: ['./freights.component.css']
})
export class FreightsComponent implements OnInit {

    freights: Freight[] = [];
    constructor(private freightsService: FreightsService,
                private truckerService: TruckerService,
                private router: Router,
                private signalRService: SignalRService) {
    }

    ngOnInit() {
        this.freightsService.getFreights().subscribe(result => {
            if (result != null) {
                this.freights = result;
                this.signalRService.freights = result;
            }
        })
        this.signalRService.startConnection();
        this.signalRService.addTransferChartDataListener();
        
    }

    takeFreight(freight: Freight) {
        this.truckerService.takeFreight({TruckerId: 1, FreightId: freight.id, Payment: freight.payment, Status: FreightStatus.Taken})
        .subscribe(result => {
            var index = this.freights.findIndex(el => el.id == freight.id);
            if (index > -1){
                this.freights.splice(index, 1);
            }
        });
    }
    addFreight() {
        this.router.navigate(['/addfreight']);
    }
}