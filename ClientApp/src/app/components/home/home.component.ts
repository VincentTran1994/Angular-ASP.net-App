import { Component } from '@angular/core';
import { UserService } from '../../services/user-service/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent {
  usersInfo : object[];

  constructor(private userService: UserService){
    this.userService.GetAllUserInfo().subscribe(
      usersInfo =>{
        this.usersInfo = usersInfo;
        console.log(this.usersInfo);
      }
    );
  }
  
  
}
