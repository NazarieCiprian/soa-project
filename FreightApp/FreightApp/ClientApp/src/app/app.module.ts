import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FreightsComponent } from './freights-component/freights.component';
import { FreightsService } from './services/freights.service';
import { CommonModule } from '@angular/common';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import { TruckerService } from './services/trucker.service';
import { AddFreightComponent } from './add-freight-component/add-freight.component';
import {MatInputModule} from '@angular/material/input';
import { AuthenticationComponent } from './authentication-component/authentication.component';
import { TokenInterceptor } from './interceptor/token.interceptor';
import { AuthenticationService } from './services/authentication.service';
import { AddTruckerComponent } from './add-trucker-component/add-trucker.component';
import { TruckerInfoComponent } from './trucker-info-component/trucker-info.component';
import { SignalRService } from './services/signlar.service';
@NgModule({
  declarations: [
    AppComponent,
    FreightsComponent,
    AddFreightComponent,
    AuthenticationComponent,
    AddTruckerComponent,
    TruckerInfoComponent,
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    RouterModule.forRoot([
      { path: '', component: AuthenticationComponent, pathMatch: 'full' },
      { path: 'freights', component: FreightsComponent },
      { path: 'addfreight', component: AddFreightComponent },
      { path: 'addtrucker', component: AddTruckerComponent },
      {path: 'truckerInfo', component: TruckerInfoComponent}
      //{ path: 'fetch-data', component: FetchDataComponent },
    ]),
    NoopAnimationsModule
  ],
  providers: [FreightsService, TruckerService,{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }, AuthenticationService, SignalRService],
  bootstrap: [AppComponent]
})
export class AppModule { }
