import { Component, OnInit } from '@angular/core';
import { RequestService } from '../../services/request-service/request.service';
import { request } from '../../domain-objects/request';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  public email:string;
  public fullName:string;
  public content:string;
  public phonePlaceHolder : string;
  public requests: request[];

  constructor(private requestService: RequestService) {  }

  ngOnInit() {
    this.requestService.GetAllRequests().subscribe(
      res =>{
       this.requests = res;
       console.log(this.requests);
    });
  }

  onsubmit(){
    console.log(this.email + " "  + " "+this.content);
  }
  
}
