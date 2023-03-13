import { Component } from '@angular/core';
import { Client, SpecializationDto } from '../../../../services/Client';

@Component({
  selector: 'app-admin-specialization',
  templateUrl: './admin-specialization.component.html',
  styleUrls: ['./admin-specialization.component.scss']
})
export class AdminSpecializationComponent {
  specializationList: SpecializationDto[] = [];
  newSpecialization: SpecializationDto = new SpecializationDto();

  constructor(private client: Client) {
    this.getSpecializationList();
  }

  getSpecializationList() {
    this.client.adminSpecializationGetList().subscribe(data => this.specializationList = data);
  }

  createSpecialization() {
    this.client.adminSpecializationCreate(this.newSpecialization).subscribe(() => {
      this.newSpecialization = new SpecializationDto();
      this.getSpecializationList();
    });
  }

  editSpecialization(specialization: SpecializationDto) {
    this.client.adminSpecializationEdit(specialization).subscribe(() => { this.getSpecializationList() });
  }

  removeSpecialization(specialization: SpecializationDto) {
    let test = specialization.id ?? 0;
    this.client.adminSpecializationDelete(test).subscribe(() => { this.getSpecializationList() });
  }
}
