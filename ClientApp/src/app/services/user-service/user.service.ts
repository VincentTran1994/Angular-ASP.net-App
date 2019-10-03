import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { userInfo } from '../../domain-objects/userInfo';

@Injectable()
export class UserService {
  public baseApiURL = "https://localhost:5001/";
  public result: Object[];
  public user: userInfo;

  constructor(private http: Http) { }

  // Retrieve all users info
  public GetAllUserInfo(){
    return this.http.get(this.baseApiURL + "api/users-info")
      .map(res => res.json());
  }

  public GetUser(email:string){
    return this.http.get(this.baseApiURL + "api/user-info/" + email)
      .map(res => res.json());
       
  }
}
