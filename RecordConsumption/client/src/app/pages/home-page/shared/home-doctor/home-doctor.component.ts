import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Client,  DoctorViewDto, PolyclinicDto, SpecializationDto } from '../../../../services/Client';

@Component({
  selector: 'app-home-doctor',
  templateUrl: './home-doctor.component.html',
  styleUrls: ['./home-doctor.component.scss']
})
export class HomeDoctorComponent {
  doctor: DoctorViewDto = new DoctorViewDto();
  policlinicList: PolyclinicDto[] = [];
  specializationList: SpecializationDto[] = [];

  constructor(private client: Client, private activateRoute: ActivatedRoute) {

    this.getDoctor();
    this.getPoliclinicList();
    this.getSpecializationList() 
  }

  getDoctor() {
    this.client.getDoctorById(this.activateRoute.snapshot.params["id"]).subscribe(data => {
      this.doctor = data;
    });
  }

  getPoliclinicList() {
    this.client.adminPolyclinicGetList().subscribe(data => this.policlinicList = data);
  }

  getSpecializationList() {
    this.client.adminSpecializationGetList().subscribe(data => this.specializationList = data);
  }

  getPoliclinicById(id: number): PolyclinicDto | undefined {
    return this.policlinicList.find(p => p.id == id);
  }

  getSpecializationById(id: number): SpecializationDto | undefined {
    return this.specializationList.find(p => p.id == id);
  }
}

