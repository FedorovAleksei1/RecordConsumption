import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { AdminTownComponent } from './pages/admin-page/shared/admin-town/admin-town.component';

const routes: Routes = [
  { path: 'admin', component: AdminPageComponent },
  { path: 'admin/town', component: AdminTownComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
