import { Component } from '@angular/core';
import { Client, DoctorEditDto } from '../../../../services/Client';

@Component({
  selector: 'app-admin-doctor-list',
  templateUrl: './admin-doctor-list.component.html',
  styleUrls: ['./admin-doctor-list.component.scss']
})
export class AdminDoctorListComponent {
  doctorList: DoctorEditDto[] = [];

  constructor(private client: Client) {
    this.getDoctorList();
  }

  getDoctorList() {
    this.client.adminDoctorGetList().subscribe(data => this.doctorList = data);
  }
}
