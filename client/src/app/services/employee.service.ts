import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  employeeUrl: string='https://localhost:7137/api/Employee';
  filterdEmployeeUrl: string='https://localhost:7137/api/FilterdEmployee'


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


  getEmployeesByDateRange(joiningDate: Date, endingDate: Date): Observable<any> {
    // Create HttpParams to send the date range as query parameters
    const params = new HttpParams()
      .set('joiningDate', joiningDate.toISOString())
      .set('endingDate', endingDate.toISOString());

    // Send a GET request with the params
    return this.http.get(this.filterdEmployeeUrl, { params });
  }


}
