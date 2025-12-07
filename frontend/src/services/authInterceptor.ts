import { inject } from '@angular/core';
import { HttpInterceptorFn } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs/internal/operators/tap';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);

  const token = localStorage.getItem('token');

  let newReq = req;

  if (token) {
    newReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
  }

  return next(newReq).pipe(
    tap({
      error: (error) => {
        if (error.status === 401 || error.status === 403) {
          localStorage.removeItem('token');
          router.navigate(['/login']);
        }
      },
    })
  );
};
