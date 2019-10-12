import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { request } from '../../domain-objects/request';

@Injectable()
export class RequestService {
  public baseApiURL = "https://localhost:5001/";
  public request: request[];

  constructor(private http: Http) { }

  // Retrieve all users info
  public GetAllRequests(){
    return this.http.get(this.baseApiURL + "api/requests")
      .map(res => this.request = res.json());
  }

}
