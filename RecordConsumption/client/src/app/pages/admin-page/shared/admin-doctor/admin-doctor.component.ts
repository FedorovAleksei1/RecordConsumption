import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Client,  DoctorEditDto, PolyclinicDto, PracticeEditDto, SpecializationDto } from '../../../../services/Client';

@Component({
  selector: 'app-admin-doctor',
  templateUrl: './admin-doctor.component.html',
  styleUrls: ['./admin-doctor.component.scss']
})
export class AdminDoctorComponent {

  doctor: DoctorEditDto = new DoctorEditDto();
  polyclinicsId = new FormControl([0]);// для мультиселекта

  policlinicList: PolyclinicDto[] = [];
  newPractice: PracticeEditDto = new PracticeEditDto();

  specializationList: SpecializationDto[] = [];

  constructor(private client: Client,
    private activateRoute: ActivatedRoute,
    private router: Router ) {
    this.getPoliclinicList();
    this.getSpecializationList();

    let id = this.activateRoute.snapshot.params["id"];
    if (id) {
      this.getDoctorById(id);
    }
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

  save() {
    this.doctor.polyclinicsId = this.polyclinicsId.value ? this.polyclinicsId.value : [];

    if (!this.doctor.id || this.doctor.id == 0) {             //Если Id пустой тогда мы вызываем метод создания доктора а если не пустой то мы редактируем
      this.client.create(this.doctor).subscribe(r => {
        this.router.navigate(['./admin/doctor/'+r]) }//редирект на страницу  http://localhost:4200/admin/doctor/{{r}} ./{{r}}
      );
    }
    else {
      this.client.edit(this.doctor).subscribe(() => {
        this.getDoctorById(this.activateRoute.snapshot.params["id"]);
      });
    }
  }

  addPractice() {
    if (!this.doctor.practicesDto) {
      this.doctor.practicesDto = []; //
    }
    this.doctor.practicesDto?.push(this.newPractice);
    this.newPractice = new PracticeEditDto();
  }

  removePractice(practice: PracticeEditDto) {
    this.doctor.practicesDto = this.doctor.practicesDto?.filter(r => r != practice);
  }
}
