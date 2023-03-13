import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Client, DoctorDto } from '../../../../services/Client';

@Component({
  selector: 'app-home-doctor-by-specialization-id',
  templateUrl: './home-doctor-by-specialization-id.component.html',
  styleUrls: ['./home-doctor-by-specialization-id.component.scss']
})
export class HomeDoctorBySpecializationIdComponent {
  doctorList: DoctorDto[] = [];

  constructor(private client: Client, private activateRoute: ActivatedRoute) {
     
    this.getdoctorList();

  }

  getdoctorList() {
  this.client.getDoctorsBySpecializationId(this.activateRoute.snapshot.params["id"],0,0).subscribe(data => this.doctorList = data);
  }
}
