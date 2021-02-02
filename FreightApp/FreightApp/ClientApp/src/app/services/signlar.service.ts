import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { Freight } from '../model/Freight';
@Injectable()
export class SignalRService {
private hubConnection: signalR.HubConnection;
  public freights: Freight[];
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:5876/freighthub')
                            .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }
  public addTransferChartDataListener = () => {
    this.hubConnection.on('addedfreight', (data) => {
        this.freights = data;
      console.log(data);
    });
  }

  
}