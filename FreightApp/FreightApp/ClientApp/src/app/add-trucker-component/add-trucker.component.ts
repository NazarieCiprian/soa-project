import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { TruckerService } from "../services/trucker.service";

@Component({
    selector: 'app-add-trucker',
    templateUrl: './add-trucker.component.html',
    styleUrls: ['./add-trucker.component.css']
})
export class AddTruckerComponent implements OnInit {

    @ViewChild('username', {static: false}) usernameInput;
    @ViewChild('password', {static: false}) passwordInput;
    @ViewChild('truckingcompany', {static: false}) truckingcompanyInput;
    constructor(private truckerService: TruckerService,
                private router: Router) {
        
    }

    ngOnInit() {

    }

    addTrucker() {
        const trucker = {
            Username: this.usernameInput.nativeElement.value,
            Password: this.passwordInput.nativeElement.value,
            TruckingCompany: this.truckingcompanyInput.nativeElement.value,
        }
        this.truckerService.addTrucker(trucker).subscribe(result => {
            console.log(result);
            this.router.navigate(['']);
        })
    }
}