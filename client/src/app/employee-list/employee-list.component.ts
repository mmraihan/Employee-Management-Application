import { Component } from '@angular/core';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {

  joiningDate: Date;
  endingDate: Date;
  employees: any[];

  constructor(private employeeService: EmployeeService) {}

  getEmployees() {
    this.employeeService.getEmployeesByDateRange(this.joiningDate, this.endingDate).subscribe(data => {
      this.employees = data;
    });
  }

}
