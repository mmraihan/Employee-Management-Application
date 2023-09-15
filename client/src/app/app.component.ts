import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
  title = 'client';
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService){ }

  ngOnInit(){
    this.getUsers();
    this.setCurrentUser();
   }

   setCurrentUser(){
    const user: any=JSON.parse (localStorage.getItem('user')); 
    this.accountService.setCurrentUser(user);
  }

  getUsers(){
    this.http.get("https://localhost:7137/api/users").subscribe(response=>{
      this.users=response;
    }, error=>{
      console.log(error);
    });
  }
}
