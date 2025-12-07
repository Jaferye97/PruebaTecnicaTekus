import { Routes } from '@angular/router';
import { AllSuppliersComponent } from './components/all-suppliers/all-suppliers.component';

export const SupplierRoutes: Routes = [
  {
    path: '',
    children: [{ path: 'Supplier', component: AllSuppliersComponent }],
  },
];
