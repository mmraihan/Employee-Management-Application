import { Router, RouterModule } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
  model: any={};
  loggedIn: boolean=false;

  constructor(private accountService: AccountService, private router: Router, private toasr: ToastrService ) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  login(){
    this.accountService.logIn(this.model).subscribe(response=>{
      this.router.navigateByUrl('/employee-details') 
      this.toasr.success("","Successfully logged in!")

    },error=>{
      this.toasr.error(error.error);
     
    })
  }

  logout(){
    this.accountService.logout();
    this.loggedIn=false;
    this.router.navigateByUrl('/')  
  }

  getCurrentUser(){
    this.accountService.currentUser$.subscribe(user=>{
     this.loggedIn=!!user;
    }, error=>{
      console.log(error);
    })
  }
  }


