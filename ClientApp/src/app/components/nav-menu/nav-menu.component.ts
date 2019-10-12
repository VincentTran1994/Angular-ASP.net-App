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

  constructor(private http: Http) { }


  onKeyPress($event){
      this.urlAPI = 'https://www.omdbapi.com/?s=' + this.movieSearch + '&apikey=thewdb';

      this.http.get(this.urlAPI)
        .subscribe((lists: Response) => {
          this.listsSearch = lists.json().Search;
        });
        
      (this.listsSearch.length > 0) ? this.dropDown = true : this.dropDown = false;
  }

  onfocus(){
    (this.listsSearch.length > 0) ? this.dropDown = true : this.dropDown = false;
  }

  onblur(){
    this.dropDown = !this.dropDown;
  }
}
