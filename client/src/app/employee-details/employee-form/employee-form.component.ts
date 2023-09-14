import { Component, OnInit, NgModule, ViewChild, ElementRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  constructor(public empService: EmployeeService, public toast: ToastrService){}

  @ViewChild('checkbox1') checkBox: ElementRef; 
  isSlide: string ="off";

  ngOnInit() {
    
  }

  submit(form: NgForm){
    if (this.empService.employeeData.id==0) {
      this.insertEmployee(form);
    }
    else
    this.updateEployee(form);
  }

  insertEmployee(myform:NgForm)
  {  this.empService.addEmployee().subscribe(d=> {
     this.resetForm(myform);
     this.refereshData();
     this.toast.success('Sucess','Record Saved');
    });
  }
  updateEployee(myform:NgForm)
  {
    this.empService.updateEmployee().subscribe(d=> {
      this.resetForm(myform);
      this.refereshData();
      this.toast.warning('Sucess','Record Updated');
    });
  }
  resetForm(myform:NgForm)
  {
    myform.form.reset(myform.value);
    this.empService.employeeData=new Employee();
    this.hideShowSlide();
  }
  refereshData()
  {
    this.empService.getAllEmployees().subscribe(res=>{
      this.empService.listOfEmployee=res;
    });
  }

  hideShowSlide()
  {
    if(this.checkBox.nativeElement.checked)
    {
      this.checkBox.nativeElement.checked=false;
      this.isSlide='off';
    }
    else
    {
      this.checkBox.nativeElement.checked=true;
      this.isSlide='on';
    }
  }

}
