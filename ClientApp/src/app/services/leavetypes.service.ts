import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LeavetypesService {

  constructor(private _http: HttpClient) { }

  getLeaveTypes() {
    return this._http.get('localhost:7137/leavetypes');
  }
}
