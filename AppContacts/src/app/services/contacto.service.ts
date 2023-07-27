import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Contacto } from '../interfaces/contacto';
import { HttpClient } from '@angular/common/http';
import { ResponseApi } from '../interfaces/response-api';

@Injectable({
  providedIn: 'root'
})
export class ContactoService {

  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string= 'api/Contact/';
  constructor(private http: HttpClient) {   }

  getContacts(search:string):Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.myAppUrl}${this.myApiUrl}${'List/'}${search}`);
  }

  getContact(id:number):Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.myAppUrl}${this.myApiUrl}${id}`);
  }

  getByRange(ageinit:number,agefinal:number):Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.myAppUrl}${this.myApiUrl}FindByRangeOfAge?ageinit=${ageinit}&agefinal=${agefinal}`);
  }

  deleteContact(id:number):Observable<ResponseApi>{
    return this.http.delete<ResponseApi>(`${this.myAppUrl}${this.myApiUrl}${id}`);
  }

  addContact(contact:Contacto):Observable<ResponseApi>{
    return this.http.post<ResponseApi>(`${this.myAppUrl}${this.myApiUrl}`,contact)
 }

 updateContact(contact:Contacto):Observable<ResponseApi>{
   return this.http.put<ResponseApi>(`${this.myAppUrl}${this.myApiUrl}`,contact)
}
}
