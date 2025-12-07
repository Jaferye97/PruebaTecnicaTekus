import { Injectable } from '@angular/core';
import { delay, of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  login(username: string, password: string) {
    if (username === 'admin' && password === 'admin') {
      return of('mocked-token-12345').pipe(delay(800)); // simula delay
    } else {
      return throwError(() => new Error('Invalid credentials')).pipe(
        delay(800)
      );
    }
  }
}
