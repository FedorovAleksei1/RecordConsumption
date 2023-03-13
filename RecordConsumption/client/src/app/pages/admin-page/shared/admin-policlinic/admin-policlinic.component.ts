import { Component } from '@angular/core';
import { SubscriptionLog } from 'rxjs/internal/testing/SubscriptionLog';
import { Client, PolyclinicDto, TownDto } from '../../../../services/Client';

@Component({
  selector: 'app-admin-policlinic',
  templateUrl: './admin-policlinic.component.html',
  styleUrls: ['./admin-policlinic.component.scss']
})
export class AdminPoliclinicComponent {

  townList: TownDto[] = [];

  policlinicList: PolyclinicDto[] = [];
  newPolyclinic: PolyclinicDto = new PolyclinicDto();

  constructor(private client: Client) {
    this.getTownList();
    this.getPoliclinicList();
  }

  getTownList() {
    this.client.adminTownGetList().subscribe(data => this.townList = data);
  }


  getPoliclinicList() {
    this.client.adminPolyclinicGetList().subscribe(data => this.policlinicList = data);
  }

  createPoliclinic() {
    this.client.adminPolyclinicCreate(this.newPolyclinic).subscribe(() => {
      this.newPolyclinic = new PolyclinicDto();
      this.getPoliclinicList();
    });
  }

  editPoliclinic(policlinic: PolyclinicDto) {
    this.client.adminPolyclinicEdit(policlinic).subscribe(() => { this.getPoliclinicList() });
  }

  removePoliclinic(policlinic: PolyclinicDto) {
    let test = policlinic.id ?? 0;
    this.client.adminPolyclinicDelete(test).subscribe(() => { this.getPoliclinicList() });
  }


}
