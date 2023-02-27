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
    this.client.getList3().subscribe(data => this.specializationList = data);
  }

  createSpecialization() {
    this.client.create3(this.newSpecialization).subscribe(() => {
      this.newSpecialization = new SpecializationDto();
      this.getSpecializationList();
    });
  }

  editSpecialization(specialization: SpecializationDto) {
    this.client.edit3(specialization).subscribe(() => { this.getSpecializationList() });
  }

  removeSpecialization(specialization: SpecializationDto) {
    let test = specialization.id ?? 0;
    this.client.delete3(test).subscribe(() => { this.getSpecializationList() });
  }
}
