import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  //declare lists
  public listsSearch : any[];
  public dropDown = false;
  public urlAPI : string;
  public movieSearch: String;
  public searchWidth = true;

  constructor(private http: Http) {
    // this.http.get()
    // .subscribe(listSearch => this.lists = listSearch);
  }


  onKeyPress($event){

      this.urlAPI = 'https://www.omdbapi.com/?s=' + this.movieSearch + '&apikey=thewdb';

      this.http.get(this.urlAPI)
        .subscribe((lists: Response) => {
          console.log(lists);
          this.listsSearch = lists.json().Search;
        });
  }

  onfocus(){
    this.dropDown = !this.dropDown;
    console.log("drom onforcus: " + this.dropDown);
    if(this.dropDown)
      this.searchWidth = false;
    else
      this.searchWidth = true;
  }

  onblur(){
    console.log(this.listsSearch.length);
    this.searchWidth = true;
    
    console.log("from onblur: " + this.dropDown);
    this.dropDown = !this.dropDown;
    this.onfocus();
  }
}
