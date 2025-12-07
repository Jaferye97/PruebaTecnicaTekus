import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import {
  MatPaginator,
  MatPaginatorModule,
  PageEvent,
} from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

import { AuthApiService } from '../../../../../services/AuthApiService';
import { urlServices } from '../../../../../environments/url-services';

import { Supplier } from '../../interfaces/Supplier';
import { PagedResult } from '../../../../components-general/interfaces/PagedResult';

@Component({
  selector: 'app-all-suppliers',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
  ],
  templateUrl: './all-suppliers.component.html',
  styleUrls: ['./all-suppliers.component.css'],
})
export class AllSuppliersComponent {
  loading = false;
  columns: string[] = ['taxId', 'name', 'email'];
  dataSource = new MatTableDataSource<Supplier>([]);
  totalItems = 0;

  filters = {
    taxId: '',
    name: '',
    email: '',
    page: 1,
    pageSize: 5,
  };

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private authApiService: AuthApiService) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.loading = true;

    const url = `${urlServices.supplier}/GetAll`;

    this.authApiService
      .request<PagedResult<Supplier>>('GET', url, this.filters)
      .subscribe({
        next: (res) => {
          this.dataSource = new MatTableDataSource(res.items);
          this.totalItems = res.totalItems;
          this.filters.page = res.currentPage;
          this.dataSource.sort = this.sort;
          this.loading = false;
        },
        error: () => {
          this.loading = false;
        },
      });
  }

  applyFilter() {
    this.filters.page = 1;
    this.loadData();
  }

  clearFilters() {
    this.filters = { taxId: '', name: '', email: '', page: 1, pageSize: 5 };
    this.loadData();
  }

  onPageChange(event: PageEvent) {
    this.filters.page = event.pageIndex + 1;
    this.filters.pageSize = event.pageSize;
    this.loadData();
  }
}
