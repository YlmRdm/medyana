import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr"; 
import { PatientViewModel } from '../models/patient-view-model';

@Injectable({
  providedIn: "root"
})
export class SignalRService {
  private hubConnection!: signalR.HubConnection;
  patientReceived = new EventEmitter<PatientViewModel>();

  constructor() { 
    this.buildConnection();
    this.startConnection();
  }

  public buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:53873/patientHub")
    .build();
  };

  public startConnection = () => {
    this.hubConnection
    .start()
    .then(() => {
      console.log("Connection Started...");
      this.registerPatientEvent();
    })
    .catch((err) => {
      console.log("Error while starting connection: " + err);

      setTimeout( () => {
        this.startConnection(); 
      }, 3000);
    });
  };

  private registerPatientEvent() {
    this.hubConnection.on("PatientMessageReceived", (data: PatientViewModel) => {
      this.patientReceived.emit(data);
    });
  }
}
