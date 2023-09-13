import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  employeeUrl: string='https://localhost:7137/api/Employee';

  listOfEmployee: Employee[]=[]; // for get

  employeeData: Employee= new Employee(); // for post


  getAllEmployees():Observable<Employee[]>
  {
    return this.http.get<Employee[]>(this.employeeUrl);
  }

  addEmployee()
  {
    return this.http.post(this.employeeUrl,this.employeeData);
  }

  updateEmployee()
  {
    return this.http.put(`${this.employeeUrl}/${this.employeeData.id}` ,this.employeeData);
  }

  deleteEmployee(id:number)
  {
    return this.http.delete(`${this.employeeUrl}/${id}`);
  }


}
