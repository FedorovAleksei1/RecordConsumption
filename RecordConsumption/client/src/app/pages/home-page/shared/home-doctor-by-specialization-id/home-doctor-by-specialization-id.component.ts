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
  page: number = 1;
  take: number = 5;
  totalCount: number = 1;
  pageAll: number = 1;


  constructor(private client: Client, private activateRoute: ActivatedRoute) {
     
    this.getdoctorList();

  }

  getdoctorList() {
    this.client.getDoctorsBySpecializationId(this.activateRoute.snapshot.params["id"], this.page, this.take).subscribe(data => {
      this.doctorList = data.elements || [];
      this.totalCount = data.totalCount || 0;
      this.pageAll = Math.ceil(this.totalCount / this.take);
    });
  }

  pageForward(): void {
    this.page = this.page + 1;
    this.getdoctorList();
  }

  pageBack(): void {
    this.page = this.page - 1;
    this.getdoctorList();
  }

  changeTheNumberOfLines(event: any): void {
    this.page = 1;
    this.take = event.value;
    this.getdoctorList();
  }

}
