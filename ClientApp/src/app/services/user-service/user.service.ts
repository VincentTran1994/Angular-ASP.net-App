import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {
  public baseApiURL = "https://localhost:5001/";
  public result: Object[];

  constructor(private http: Http) { }

  // Retrieve all users info
  public GetAllUserInfo(){
    return this.http.get(this.baseApiURL + "api/users-info")
      .map(res => res.json());
  }

  // 
}
