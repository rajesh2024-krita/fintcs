
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService, User } from '../../../core/services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  template: `
    <nav class="bg-primary-800 shadow-lg fixed w-full top-0 z-50">
      <div class="max-w-7xl mx-auto px-4">
        <div class="flex justify-between h-16">
          <!-- Logo and primary nav -->
          <div class="flex">
            <div class="flex-shrink-0 flex items-center">
              <h1 class="text-xl font-bold text-white">Fintcs</h1>
            </div>
            
            <!-- Navigation links -->
            <div class="hidden sm:ml-6 sm:flex sm:space-x-8">
              <a routerLink="/dashboard" 
                 routerLinkActive="border-primary-300 text-white"
                 [routerLinkActiveOptions]="{exact: true}"
                 class="border-transparent text-primary-100 hover:text-white hover:border-primary-300 inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium transition-colors">
                Dashboard
              </a>
              
              <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/societies" 
                 routerLinkActive="border-primary-300 text-white"
                 class="border-transparent text-primary-100 hover:text-white hover:border-primary-300 inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium transition-colors">
                Societies
              </a>
              
              <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/users" 
                 routerLinkActive="border-primary-300 text-white"
                 class="border-transparent text-primary-100 hover:text-white hover:border-primary-300 inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium transition-colors">
                Users
              </a>
              
              <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin', 'User'])" 
                 routerLink="/members" 
                 routerLinkActive="border-primary-300 text-white"
                 class="border-transparent text-primary-100 hover:text-white hover:border-primary-300 inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium transition-colors">
                Members
              </a>
              
              <a routerLink="/loans" 
                 routerLinkActive="border-primary-300 text-white"
                 class="border-transparent text-primary-100 hover:text-white hover:border-primary-300 inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium transition-colors">
                Loans
              </a>
              
              <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/demand" 
                 routerLinkActive="border-primary-300 text-white"
                 class="border-transparent text-primary-100 hover:text-white hover:border-primary-300 inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium transition-colors">
                Monthly Demand
              </a>
              
              <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
                 routerLink="/vouchers" 
                 routerLinkActive="border-primary-300 text-white"
                 class="border-transparent text-primary-100 hover:text-white hover:border-primary-300 inline-flex items-center px-1 pt-1 border-b-2 text-sm font-medium transition-colors">
                Vouchers
              </a>
            </div>
          </div>

          <!-- User menu -->
          <div class="flex items-center">
            <div class="relative">
              <button (click)="toggleUserMenu()" 
                      class="bg-primary-700 flex text-sm rounded-full focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-offset-primary-800 focus:ring-white">
                <span class="sr-only">Open user menu</span>
                <div class="h-8 w-8 rounded-full bg-primary-600 flex items-center justify-center">
                  <span class="text-sm font-medium text-white">
                    {{ getUserInitials() }}
                  </span>
                </div>
              </button>

              <!-- Dropdown menu -->
              <div *ngIf="showUserMenu" 
                   class="origin-top-right absolute right-0 mt-2 w-48 rounded-md shadow-lg py-1 bg-white ring-1 ring-black ring-opacity-5 focus:outline-none z-50">
                <div class="px-4 py-2 text-xs text-gray-500 border-b">
                  <div class="font-medium text-gray-900">{{ currentUser?.name }}</div>
                  <div>{{ currentUser?.role }}</div>
                </div>
                <a href="#" (click)="logout($event)" 
                   class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">
                  Sign out
                </a>
              </div>
            </div>
          </div>

          <!-- Mobile menu button -->
          <div class="sm:hidden flex items-center">
            <button (click)="toggleMobileMenu()"
                    class="text-primary-100 hover:text-white focus:outline-none focus:text-white">
              <svg class="h-6 w-6" stroke="currentColor" fill="none" viewBox="0 0 24 24">
                <path [attr.d]="showMobileMenu ? 'M6 18L18 6M6 6l12 12' : 'M4 6h16M4 12h16M4 18h16'"
                      stroke-linecap="round" stroke-linejoin="round" stroke-width="2" />
              </svg>
            </button>
          </div>
        </div>

        <!-- Mobile menu -->
        <div *ngIf="showMobileMenu" class="sm:hidden">
          <div class="px-2 pt-2 pb-3 space-y-1 border-t border-primary-700">
            <a routerLink="/dashboard" 
               (click)="closeMobileMenu()"
               class="text-primary-100 hover:text-white block px-3 py-2 rounded-md text-base font-medium">
              Dashboard
            </a>
            <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
               routerLink="/societies"
               (click)="closeMobileMenu()" 
               class="text-primary-100 hover:text-white block px-3 py-2 rounded-md text-base font-medium">
              Societies
            </a>
            <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
               routerLink="/users"
               (click)="closeMobileMenu()" 
               class="text-primary-100 hover:text-white block px-3 py-2 rounded-md text-base font-medium">
              Users
            </a>
            <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin', 'User'])" 
               routerLink="/members"
               (click)="closeMobileMenu()" 
               class="text-primary-100 hover:text-white block px-3 py-2 rounded-md text-base font-medium">
              Members
            </a>
            <a routerLink="/loans"
               (click)="closeMobileMenu()" 
               class="text-primary-100 hover:text-white block px-3 py-2 rounded-md text-base font-medium">
              Loans
            </a>
            <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
               routerLink="/demand"
               (click)="closeMobileMenu()" 
               class="text-primary-100 hover:text-white block px-3 py-2 rounded-md text-base font-medium">
              Monthly Demand
            </a>
            <a *ngIf="hasAnyRole(['SuperAdmin', 'SocietyAdmin'])" 
               routerLink="/vouchers"
               (click)="closeMobileMenu()" 
               class="text-primary-100 hover:text-white block px-3 py-2 rounded-md text-base font-medium">
              Vouchers
            </a>
          </div>
        </div>
      </div>
    </nav>
  `
})
export class NavbarComponent implements OnInit {
  currentUser: User | null = null;
  showUserMenu = false;
  showMobileMenu = false;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.currentUser$.subscribe(user => {
      this.currentUser = user;
    });
  }

  hasAnyRole(roles: string[]): boolean {
    return this.authService.hasAnyRole(roles);
  }

  getUserInitials(): string {
    if (!this.currentUser?.name) return '';
    return this.currentUser.name
      .split(' ')
      .map(word => word[0])
      .join('')
      .toUpperCase()
      .slice(0, 2);
  }

  toggleUserMenu(): void {
    this.showUserMenu = !this.showUserMenu;
  }

  toggleMobileMenu(): void {
    this.showMobileMenu = !this.showMobileMenu;
  }

  closeMobileMenu(): void {
    this.showMobileMenu = false;
  }

  logout(event: Event): void {
    event.preventDefault();
    this.authService.logout();
  }
}
