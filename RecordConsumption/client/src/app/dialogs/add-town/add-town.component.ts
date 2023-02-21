import { Component, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-town',
  templateUrl: './add-town.component.html',
  styleUrls: ['./add-town.component.scss']
})
export class AddTownComponent {
  constructor(
    public dialogRef: MatDialogRef<AddTownComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number,
  ) { }
}
