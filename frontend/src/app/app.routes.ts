import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { authGuard } from './guards/auth';
import { HomeComponent } from './pages/home/home.component';

import { SupplierRoutes } from './pages/suppliers/supplier.routes';

export const routes: Routes = [
  ...SupplierRoutes,
  { path: 'home', component: HomeComponent, canActivate: [authGuard] },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: 'login' },
];
