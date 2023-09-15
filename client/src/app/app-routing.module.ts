import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeFormComponent } from './employee-details/employee-form/employee-form.component';

const routes: Routes = [
{path:'', component: HomeComponent},
{path:'employee-details', component: EmployeeDetailsComponent},
{path:'add', component: EmployeeFormComponent},
{path: '**', component: HomeComponent, pathMatch:'full'},




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
