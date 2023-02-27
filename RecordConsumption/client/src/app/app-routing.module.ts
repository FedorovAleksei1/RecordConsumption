import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AdminDoctorComponent } from './pages/admin-page/shared/admin-doctor/admin-doctor.component';
import { AdminPoliclinicComponent } from './pages/admin-page/shared/admin-policlinic/admin-policlinic.component';
import { AdminSpecializationComponent } from './pages/admin-page/shared/admin-specialization/admin-specialization.component';
import { AdminTownComponent } from './pages/admin-page/shared/admin-town/admin-town.component';

const routes: Routes = [
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
