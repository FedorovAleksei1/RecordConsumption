import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AddTownComponent } from './dialogs/add-town/add-town.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { Client } from './services/Client';
import { HttpClientModule } from '@angular/common/http';
import { AdminTownComponent } from './pages/admin-page/shared/admin-town/admin-town.component';
import { AdminSpecializationComponent } from './pages/admin-page/shared/admin-specialization/admin-specialization.component';
import { AdminPoliclinicComponent } from './pages/admin-page/shared/admin-policlinic/admin-policlinic.component';
import { AdminDoctorComponent } from './pages/admin-page/shared/admin-doctor/admin-doctor.component';import { MaterialModule } from './material/material.module';
import { AdminDoctorListComponent } from './pages/admin-page/shared/admin-doctor-list/admin-doctor-list.component';
import { MatSelectModule } from '@angular/material/select'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MatInputModule } from '@angular/material/input';
import { HomeDoctorComponent } from './pages/home-page/shared/home-doctor/home-doctor.component';
import { HomeSpecializationListComponent } from './pages/home-page/shared/home-specialization-list/home-specialization-list.component';
import { HomeDoctorBySpecializationIdComponent } from './pages/home-page/shared/home-doctor-by-specialization-id/home-doctor-by-specialization-id.component';

@NgModule({
  exports: [
    MatDialogModule,
  ],
  declarations: [
    AppComponent,
    AdminPageComponent,
    AddTownComponent,
    AdminTownComponent,
    AdminSpecializationComponent,
    AdminPoliclinicComponent,
    AdminDoctorComponent,
    AdminDoctorListComponent,
    HomeDoctorComponent,
    HomeSpecializationListComponent,
    HomeDoctorBySpecializationIdComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatInputModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [Client],
  bootstrap: [AppComponent]
})
export class AppModule { }
