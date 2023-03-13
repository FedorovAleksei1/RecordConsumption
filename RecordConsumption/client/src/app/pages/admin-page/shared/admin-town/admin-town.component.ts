import { Component } from '@angular/core';
import { Client, TownDto } from '../../../../services/Client';



@Component({
  selector: 'app-admin-town',
  templateUrl: './admin-town.component.html',
  styleUrls: ['./admin-town.component.scss']
})
export class AdminTownComponent {

  townList: TownDto[] = [];
  newTown: TownDto = new TownDto();

  constructor(private client: Client) {
    this.getTownList();
  }

  getTownList() {
    this.client.adminTownGetList().subscribe(data => this.townList = data);
  }

  createTown() {
    this.client.adminTownCreate(this.newTown).subscribe(() => {
      this.newTown = new TownDto();
      this.getTownList();
    });
  }

  editTown(town: TownDto) {
    this.client.adminTownEdit(town).subscribe(() => { this.getTownList() });
  }

  removeTown(town: TownDto) {
    let test = town.id ?? 0;
    this.client.adminTownDelete(test).subscribe(() => { this.getTownList() });
  }
}
