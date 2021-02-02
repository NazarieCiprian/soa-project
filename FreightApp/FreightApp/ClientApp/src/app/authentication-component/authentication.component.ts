import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { AuthenticationService } from "../services/authentication.service";

@Component({
    selector: 'app-authentication',
    templateUrl: './authentication.component.html',
    styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent implements OnInit {
    @ViewChild('username', {static: false}) usernameInput;
    @ViewChild('password', {static: false}) passwordInput;
    isCompany: boolean;
    constructor(private authenticationService: AuthenticationService,
                private router: Router) {
        
    }

    ngOnInit() {

    }

    login() {
        const username = this.usernameInput.nativeElement.value;
        const password = this.passwordInput.nativeElement.value;
        this.isCompany = false;
        this.authenticationService.authenticate({username: username, password: password, isCompany: this.isCompany}).subscribe(result => {
            if(result != null && !this.isCompany){
                localStorage.setItem('token', result.token);
                localStorage.setItem('truckerId', result.id.toString())
                
            }
            this.router.navigate(['/freights']);
        })
    }

    register(){
        this.router.navigate(['/addtrucker'])
    }
}