
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { ToastService } from '../../../shared/services/toast.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="min-h-screen flex items-center justify-center bg-gray-50 py-12 px-4 sm:px-6 lg:px-8">
      <div class="max-w-md w-full space-y-8">
        <div>
          <h2 class="mt-6 text-center text-3xl font-extrabold text-gray-900">
            Fintcs Login
          </h2>
          <p class="mt-2 text-center text-sm text-gray-600">
            Finance Management System
          </p>
        </div>
        
        <form [formGroup]="loginForm" (ngSubmit)="onSubmit()" class="mt-8 space-y-6">
          <div class="rounded-md shadow-sm space-y-4">
            <div>
              <label for="username" class="block text-sm font-medium text-gray-700">Username</label>
              <input 
                id="username"
                name="username"
                type="text"
                formControlName="username"
                class="form-input"
                [class.border-red-500]="loginForm.get('username')?.invalid && loginForm.get('username')?.touched"
                placeholder="Enter username">
              <div *ngIf="loginForm.get('username')?.invalid && loginForm.get('username')?.touched" 
                   class="mt-1 text-sm text-red-600">
                Username is required
              </div>
            </div>
            
            <div>
              <label for="password" class="block text-sm font-medium text-gray-700">Password</label>
              <input 
                id="password"
                name="password"
                type="password"
                formControlName="password"
                class="form-input"
                [class.border-red-500]="loginForm.get('password')?.invalid && loginForm.get('password')?.touched"
                placeholder="Enter password">
              <div *ngIf="loginForm.get('password')?.invalid && loginForm.get('password')?.touched" 
                   class="mt-1 text-sm text-red-600">
                Password is required
              </div>
            </div>
          </div>

          <div>
            <button 
              type="submit"
              [disabled]="loginForm.invalid || isLoading"
              class="btn-primary w-full">
              <span *ngIf="isLoading" class="inline-block animate-spin rounded-full h-4 w-4 border-b-2 border-white mr-2"></span>
              {{ isLoading ? 'Signing in...' : 'Sign in' }}
            </button>
          </div>
        </form>

        <div class="mt-6 bg-gray-50 p-4 rounded-lg">
          <h3 class="text-sm font-medium text-gray-900 mb-2">Default Login:</h3>
          <p class="text-xs text-gray-600">Username: <strong>admin</strong></p>
          <p class="text-xs text-gray-600">Password: <strong>admin</strong></p>
        </div>
      </div>
    </div>
  `
})
export class LoginComponent {
  loginForm: FormGroup;
  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastService: ToastService
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // Redirect if already authenticated
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/dashboard']);
    }
  }

  onSubmit(): void {
    if (this.loginForm.valid && !this.isLoading) {
      this.isLoading = true;
      
      this.authService.login(this.loginForm.value).subscribe({
        next: (response) => {
          this.isLoading = false;
          if (response.success) {
            this.toastService.success('Login successful!');
            this.router.navigate(['/dashboard']);
          } else {
            this.toastService.error(response.message || 'Login failed');
          }
        },
        error: (error) => {
          this.isLoading = false;
          this.toastService.error(error.error?.message || 'Login failed');
        }
      });
    }
  }
}
