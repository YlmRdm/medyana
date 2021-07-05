import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../app/services/signal-r.service';
import { PatientViewModel } from '../app/models/patient-view-model'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  patientList: PatientViewModel[] = [];

  constructor(private signalRService: SignalRService) {}

  ngOnInit() {
    this.signalRService.patientReceived.subscribe((patient: PatientViewModel) => {
      this.patientList.push(patient);
    });
  }
}
