import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { EmployeeFormComponent } from './employee-form/employee-form.component';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {

  constructor(public empService: EmployeeService, public datePipe: DatePipe,public toast: ToastrService){
  }
  @ViewChild(EmployeeFormComponent) emp: EmployeeFormComponent;

  ngOnInit() {
    this.empService.getAllEmployees().subscribe(data=>{
      this.empService.listOfEmployee=data;
    });
    
  }

  getEmployee(employee: Employee){
    let df=this.datePipe.transform(employee.dateOfBirth,'yyyy-MM-dd');
    let jd=this.datePipe.transform(employee.joiningDate,'yyyy-MM-dd');
    employee.dateOfBirth=df;
    employee.joiningDate=jd;

    this.empService.employeeData=employee;
    

  }

  deleteEmployee(id: number)
  {

    if(confirm("Are you sure to delete this data?"))
    {
      this.empService.deleteEmployee(id).subscribe(data=>{
      
        this.empService.getAllEmployees().subscribe(data=>{
          this.empService.listOfEmployee=data;
          this.toast.error('', 'Data deleted successfully! ')

      });
    },

    err=>{
      console.log("Not deleted");
    })
  
    }}
}

