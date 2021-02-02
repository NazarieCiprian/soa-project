import { Component } from "@angular/core";
import { OnInit } from "@angular/core";
import { DeliveryStatus } from "../model/DeliveryStatus";
import { TruckerService } from "../services/trucker.service";

@Component({
    selector: 'app-trucker-info',
    templateUrl: './trucker-info.component.html',
    styleUrls: ['./trucker-info.component.css']
})
export class TruckerInfoComponent implements OnInit {

    freights = [];
    currentFreight:any;
    constructor(private truckerService: TruckerService) {
        
    }

    ngOnInit() {
        this.truckerService.getTruckerFreights(parseInt(localStorage.getItem('truckerId'))).subscribe(result => {
            if(result != null){
                this.freights = result;
                console.log(this.freights);
                const idx = this.freights.findIndex(el => el.Status == DeliveryStatus.Pending);
                if (idx > -1){
                    this.currentFreight = this.freights[idx];
                    this.freights.splice(idx, 1);
                }
            }
            
        })
    }
}