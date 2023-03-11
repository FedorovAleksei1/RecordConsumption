import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AdminDoctorComponent } from './pages/admin-page/shared/admin-doctor/admin-doctor.component';
import { AdminPoliclinicComponent } from './pages/admin-page/shared/admin-policlinic/admin-policlinic.component';
import { AdminSpecializationComponent } from './pages/admin-page/shared/admin-specialization/admin-specialization.component';
import { AdminTownComponent } from './pages/admin-page/shared/admin-town/admin-town.component';
import { HomeDoctorBySpecializationIdComponent } from './pages/home-page/shared/home-doctor-by-specialization-id/home-doctor-by-specialization-id.component';
import { HomeDoctorComponent } from './pages/home-page/shared/home-doctor/home-doctor.component';
import { HomeSpecializationListComponent } from './pages/home-page/shared/home-specialization-list/home-specialization-list.component';

const routes: Routes = [
  { path: '', component: HomeSpecializationListComponent },
  { path: 'doctor/:id', component: HomeDoctorComponent },
  { path: 'specialization/:id', component: HomeDoctorBySpecializationIdComponent },
  { path: 'admin', component: AdminPageComponent },
  { path: 'admin/town', component: AdminTownComponent },
  { path: 'admin/specialization', component: AdminSpecializationComponent },
  { path: 'admin/policlinic', component: AdminPoliclinicComponent },
  { path: 'admin/doctor/:id', component: AdminDoctorComponent },
  { path: 'admin/doctor', component: AdminDoctorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
