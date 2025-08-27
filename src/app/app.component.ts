import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, Router } from '@angular/router';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { ToastComponent } from './shared/components/toast/toast.component';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavbarComponent, ToastComponent],
  template: `
    <div class="min-h-screen bg-gray-100">
      <app-navbar *ngIf="authService.isAuthenticated()"></app-navbar>
      <main [class]="authService.isAuthenticated() ? 'pt-16' : ''">
        <router-outlet></router-outlet>
      </main>
      <app-toast></app-toast>
    </div>
  `
})
export class AppComponent implements OnInit {

  constructor(
    public authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    if (this.authService.isAuthenticated()) {
      const userRole = this.authService.getUserRole();
      if (userRole) {
        this.router.navigate(['/dashboard']);
      }
    }
  }
}