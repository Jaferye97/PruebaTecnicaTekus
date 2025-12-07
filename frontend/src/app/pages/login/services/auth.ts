import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';
import { urlServices } from '../../../../environments/url-services';
import { TokenLogin } from '../interfaces/Token';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<TokenLogin> {
    const urlConsulta = `${environment.urlInicial}${urlServices.auth}/Login`;
    return this.http.post<TokenLogin>(urlConsulta, { username, password });
  }
}
