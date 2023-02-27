import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Client,  DoctorEditDto, PolyclinicDto, PracticeEditDto, SpecializationDto } from '../../../../services/Client';

@Component({
  selector: 'app-admin-doctor',
  templateUrl: './admin-doctor.component.html',
  styleUrls: ['./admin-doctor.component.scss']
})
export class AdminDoctorComponent {

  doctor: DoctorEditDto = new DoctorEditDto();
  polyclinicsId = new FormControl([0]);

  policlinicList: PolyclinicDto[] = [];
  newPractice: PracticeEditDto = new PracticeEditDto();
  specializationList: SpecializationDto[] = [];

  constructor(private client: Client,
    private activateRoute: ActivatedRoute) {
    this.getPoliclinicList();
    this.getSpecializationList();

    let id = this.activateRoute.snapshot.params["id"];
    if (id) {
      this.getDoctorById(id);
    }

    //this.polyclinicsId.value;
  }

  getDoctorById(id: number) {
    this.client.get(id).subscribe(d => {
      this.doctor = d;
      let test = d.polyclinicsId ? d.polyclinicsId : [];
      this.polyclinicsId.setValue(test); 
    });
  }

  getPoliclinicList() {
    this.client.getList2().subscribe(data => this.policlinicList = data);
  }

  getSpecializationList() {
    this.client.getList3().subscribe(data => this.specializationList = data);
  }
}
