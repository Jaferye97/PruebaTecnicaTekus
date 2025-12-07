import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { Router, NavigationEnd } from '@angular/router';
import { CommonModule } from '@angular/common';

import { SidebarComponent } from './components-general/layout/sidebar/sidebar.component';
import { LoginComponent } from './pages/login/login.component';

const myComponents = [SidebarComponent, LoginComponent];

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatSidenavModule, CommonModule, ...myComponents],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'FrontendTekus';
  showSidebar = true;

  constructor(private router: Router) {
    this.showSidebar = !this.router.url.includes('login');

    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.showSidebar = !event.urlAfterRedirects.includes('login');
      }
    });
  }
}
