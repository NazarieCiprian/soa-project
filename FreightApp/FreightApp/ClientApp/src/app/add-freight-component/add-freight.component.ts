import { Component, OnInit, ViewChild } from "@angular/core";
import { FreightStatus } from "../model/FreightStatus";
import { FreightsService } from "../services/freights.service";

@Component({
    selector: 'app-add-freight',
    templateUrl: './add-freight.component.html',
    styleUrls: ['./add-freight.component.css']
})
export class AddFreightComponent implements OnInit {
    @ViewChild('location', {static: false}) locationInput;
    @ViewChild('destination', {static: false}) destinationInput;
    @ViewChild('cargo', {static: false}) cargoInput;
    @ViewChild('payment', {static: false}) paymentInput;
    
    constructor(private freightsService: FreightsService) {
        
    }

    ngOnInit() {

    }

    addFreight() {
        const freight = {
            Location: this.locationInput.nativeElement.value,
            Destination: this.destinationInput.nativeElement.value,
            Cargo: this.cargoInput.nativeElement.value,
            Payment: parseInt(this.paymentInput.nativeElement.value),
            Status: FreightStatus.Available
        }
        this.freightsService.addFreight(freight).subscribe(result => {
            console.log(result);
        })
    }
}