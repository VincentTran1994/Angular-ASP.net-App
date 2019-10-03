import { Component } from '@angular/core';
import { UserService } from '../../services/user-service/user.service';
import { userInfo } from '../../domain-objects/userInfo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent {
  usersInfo : object[];
  user: userInfo;

  constructor(private userService: UserService){
    this.userService.GetAllUserInfo().subscribe(
      res =>{
        this.usersInfo = res;
        console.log(res);
      }
    );

    this.userService.GetUser("congvuit@gmail.com").subscribe(
      res => {
        console.log(res);
      }
    );

  }
  
  
}
