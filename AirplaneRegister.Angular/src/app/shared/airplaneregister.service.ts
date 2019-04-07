import { Injectable } from '@angular/core';
import { Airplaneregister } from './airplaneregister.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AirplaneregisterService {
  formData:Airplaneregister;
  readonly rootURL = 'https://localhost:44373/api';
  list: Airplaneregister[];
  
  constructor(private http : HttpClient) { }

  postAirplaneRegister(formData:Airplaneregister){
    return this.http.post(this.rootURL + '/AirplaneRegister',formData);
  }

  refreshList(){
    this.http.get(this.rootURL + '/AirplaneRegister')
    .toPromise()
    .then(res => this.list = res as Airplaneregister[]);
  }

  putAirplaneRegister(formData : Airplaneregister){
    return this.http.put(this.rootURL+'/AirplaneRegister/'+formData.Id,formData);
   }

  deleteAirplaneregister(id : number){

    return this.http.delete(this.rootURL + '/AirplaneRegister/'+id);

   }
}
