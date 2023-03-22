import { Component } from '@angular/core';
import { SubscriptionLog } from 'rxjs/internal/testing/SubscriptionLog';
import { Client, PhotoDto, PolyclinicDto, TownDto } from '../../../../services/Client';

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



  removePhote(policlinic: PolyclinicDto, photo: PhotoDto) {
    policlinic.photos = policlinic.photos?.filter(p => p.base64 != photo.base64);
  }

  onFileChange(fileInput: any, policlinic: PolyclinicDto) {
    let file = fileInput.target.files[0];

    if (!policlinic.photos || policlinic.photos.length < 1) {
      policlinic.photos = new Array<PhotoDto>();

    }

    if (file != null) {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = (e: any) => {
        var base64 = e.target.result.replace('data:' + file.type + ';base64,', '');
        var fileName = file.name;
        var newPhoto = new PhotoDto();
        newPhoto.base64 = base64;
        newPhoto.nameFile = fileName;
        policlinic.photos?.push(newPhoto);
      };
    } else {
      console.log('Файл не указан');
    }
  }
}
