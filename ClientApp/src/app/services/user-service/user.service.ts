import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { userInfo } from '../../domain-objects/userInfo';

@Injectable()
export class UserService {
  public baseApiURL = "https://localhost:5001/";
  public usersInfo: userInfo[];
  public user: userInfo;

  constructor(private http: Http) { }

  // Retrieve all users info
  public GetAllUserInfo(){
     this.http.get(this.baseApiURL + "api/users-info")
      .map(res => this.usersInfo = res.json());
    return this.usersInfo;
  }

  // Retrieve a user info with userId
  public GetUser(userId: string){
    console.log("11");
    this.http.get(this.baseApiURL + "api/user-info/" + userId)
      .map(res=> {
        this.user = res.json()
        console.log("11");
        console.log(this.user);
      });

      return this.user;
  }

  // Create a new user
  public CreateUser(userInfo){
    var headers = new Headers();
    headers.append('Content-Type','application/json');

    this.http.post(this.baseApiURL + "api/add-new-user",JSON.stringify(userInfo),{headers: headers})
      .subscribe(res => {console.log("Create a new user sucessful!")});
  }

  // Update user info
  public UpdateUserInfo(userInfo){
    var headers = new Headers();
    headers.append('Content-Type','application/json');
   
    return this.http.put(this.baseApiURL + "api/update-user", JSON.stringify(userInfo),{headers: headers})
    .subscribe(res => {console.log("Update sucessful!")})
  }

  // Delete a user information
  public DeleteUser(id:string){
    var headers = new Headers();
    headers.append('Content-Type','application/json');
   
    return this.http.delete(this.baseApiURL + "api/delete-user/"+id)
    .subscribe(res=>{console.log("Delete sucessful!")});
  }
}
