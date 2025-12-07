import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthApiService {
  private baseUrl = environment.urlInicial;

  constructor(private http: HttpClient) {}

  request<T>(
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    endpoint: string,
    data?: any
  ): Observable<T> {
    const url = `${this.baseUrl}${endpoint}`;

    // GET → usar query params
    if (method === 'GET') {
      let params = new HttpParams();

      if (data) {
        Object.keys(data).forEach((key) => {
          const value = data[key];
          if (value !== null && value !== undefined && value !== '') {
            params = params.set(key, value);
          }
        });
      }

      return this.http.request<T>(method, url, { params });
    }

    // POST, PUT, DELETE → usar body
    return this.http.request<T>(method, url, { body: data });
  }
}
