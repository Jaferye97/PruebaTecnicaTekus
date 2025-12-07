import { Component, inject, PLATFORM_ID } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from './services/auth';
import { TokenLogin } from './interfaces/Token';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
})
export class LoginComponent {
  private platformId = inject(PLATFORM_ID);

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router,
    private snack: MatSnackBar
  ) {}

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      const token = localStorage.getItem('token');
      if (token) {
        this.router.navigate(['/home']);
      }
    }
  }

  loading = false;

  form = this.fb.group({
    username: ['admin', [Validators.required]],
    password: ['admin', [Validators.required]],
  });

  login() {
    if (this.form.invalid) return;

    this.loading = true;

    const { username, password } = this.form.value;

    this.auth.login(username!, password!).subscribe({
      next: (token: TokenLogin) => {
        localStorage.setItem('token', token.token);
        this.router.navigate(['/home']);
      },
      error: () => {
        this.snack.open('Invalid credentials', 'Cerrar', {
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
        });
        this.loading = false;
      },
    });
  }
}
