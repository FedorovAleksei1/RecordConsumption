import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AddTownComponent } from './dialogs/add-town/add-town.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { Client } from './services/Client';
import { HttpClientModule } from '@angular/common/http';
import { AdminTownComponent } from './pages/admin-page/shared/admin-town/admin-town.component';

@NgModule({
  exports: [
    MatDialogModule,
  ],
  declarations: [
    AppComponent,
    AdminPageComponent,
    AddTownComponent,
    AdminTownComponent,
    
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatTableModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [Client],
  bootstrap: [AppComponent]
})
export class AppModule { }
