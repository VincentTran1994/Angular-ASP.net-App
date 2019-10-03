import { Component } from '@angular/core';
import { UserService } from '../../services/user-service/user.service';
import { userInfo } from '../../domain-objects/userInfo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent {
  usersInfo : userInfo[];
  user: userInfo;

  constructor(private userService: UserService){
    this.user = this.userService.GetUser("congvuit@gmail.com");
    console.log("hello");
    console.log(this.user);
  }
  
  
}
