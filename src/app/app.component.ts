
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, Router } from '@angular/router';
import { AuthService } from './core/services/auth.service';
import { ToastService } from './shared/services/toast.service';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { ToastComponent } from './shared/components/toast/toast.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    NavbarComponent,
    ToastComponent
  ],
  template: `
    <div class="min-h-screen bg-gray-50">
      <app-navbar *ngIf="isAuthenticated"></app-navbar>
      <main [class.pt-16]="isAuthenticated">
        <router-outlet></router-outlet>
      </main>
      <app-toast></app-toast>
    </div>
  `
})
export class AppComponent implements OnInit {
  isAuthenticated = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastService: ToastService
  ) {}

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe(
      isAuth => {
        this.isAuthenticated = isAuth;
        if (!isAuth && this.router.url !== '/login') {
          this.router.navigate(['/login']);
        }
      }
    );
  }
}
