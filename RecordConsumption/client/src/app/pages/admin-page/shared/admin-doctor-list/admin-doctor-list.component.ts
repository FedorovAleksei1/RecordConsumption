import { Component } from '@angular/core';
import { Client, DoctorDto } from '../../../../services/Client';

@Component({
  selector: 'app-admin-doctor-list',
  templateUrl: './admin-doctor-list.component.html',
  styleUrls: ['./admin-doctor-list.component.scss']
})
export class AdminDoctorListComponent {
  doctorList: DoctorDto[] = [];

  constructor(private client: Client) {
    this.getDoctorList();
  }

  getDoctorList() {
    this.client.adminDoctorGetList().subscribe(data => {
      this.doctorList = data;
      console.log(data)
      console.log(this.doctorList)
    });
  }
}
