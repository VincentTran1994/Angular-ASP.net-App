import { Component, OnInit } from '@angular/core';
declare var $ :any;
import { UserService } from '../../services/user-service/user.service';
import { userInfo } from '../../domain-objects/userInfo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent implements OnInit{
  usersInfo : object[];
  user: userInfo;

  constructor(private userService: UserService){ }
  
  ngOnInit() {
    this.GetAllUserInfo();
    this.GetUserInfo("2");  

    this.frontAutomation();
  }

  // Make automation
  private frontAutomation()
  {
    var carousel = $(".carousel"),
    currdeg  = 0;

    $(".next").on("click", { d: "n" }, rotate);
    $(".prev").on("click", { d: "p" }, rotate);

    function rotate(e){
      if(e.data.d=="n"){
        currdeg = currdeg - 60;
      }
      if(e.data.d=="p"){
        currdeg = currdeg + 60;
      }
      carousel.css({
        "-webkit-transform": "rotateY("+currdeg+"deg)",
        "-moz-transform": "rotateY("+currdeg+"deg)",
        "-o-transform": "rotateY("+currdeg+"deg)",
        "transform": "rotateY("+currdeg+"deg)"
      });
    }
  }

  // Get allUserinfo
  private GetAllUserInfo()
  {
    this.userService.GetAllUserInfo().subscribe(
      res =>{
        this.usersInfo = res;
        console.log(res);
      });
  }

  // Get user info with userId
  private GetUserInfo(userId:string){
    this.userService.GetUser(userId).subscribe(
      res => {
        console.log(res);
      });
  }
}
