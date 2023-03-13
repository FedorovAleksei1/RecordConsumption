import { Component } from '@angular/core';
import { Client, SpecailizationWithDoctorsDto } from '../../../../services/Client';

@Component({
  selector: 'app-home-specialization-list',
  templateUrl: './home-specialization-list.component.html',
  styleUrls: ['./home-specialization-list.component.scss']
})
export class HomeSpecializationListComponent {
  specializationList: SpecailizationWithDoctorsDto[] = [];
  townName: string = "";

  constructor(private client: Client) {
   this. getSpecializationList();
  }

  getSpecializationList() {
    this.client.getList(this.townName).subscribe(data => this.specializationList = data);
  }
}
