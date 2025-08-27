
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <nav class="bg-blue-600 text-white shadow-lg fixed top-0 left-0 right-0 z-50">
      <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="flex justify-between h-16">
          <div class="flex items-center">
            <div class="flex-shrink-0">
              <h1 class="text-xl font-bold">Fintcs</h1>
            </div>
            <div class="hidden md:block ml-10">
              <div class="flex items-baseline space-x-4">
                <a routerLink="/dashboard" 
                   routerLinkActive="bg-blue-700" 
                   class="px-3 py-2 rounded-md text-sm font-medium hover:bg-blue-500">
                  Dashboard
                </a>
                
                <div class="relative group" *ngIf="authService.hasRole(['SuperAdmin', 'SocietyAdmin'])">
                  <button class="px-3 py-2 rounded-md text-sm font-medium hover:bg-blue-500 flex items-center">
                    Management
                    <svg class="ml-1 h-4 w-4" fill="currentColor" viewBox="0 0 20 20">
                      <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd"></path>
                    </svg>
                  </button>
                  <div class="absolute left-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 opacity-0 invisible group-hover:opacity-100 group-hover:visible transition-all duration-200 z-50">
                    <div class="py-1">
                      <a routerLink="/societies" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Societies</a>
                      <a routerLink="/users" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Users</a>
                      <a routerLink="/members" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Members</a>
                    </div>
                  </div>
                </div>

                <div class="relative group">
                  <button class="px-3 py-2 rounded-md text-sm font-medium hover:bg-blue-500 flex items-center">
                    Operations
                    <svg class="ml-1 h-4 w-4" fill="currentColor" viewBox="0 0 20 20">
                      <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd"></path>
                    </svg>
                  </button>
                  <div class="absolute left-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 opacity-0 invisible group-hover:opacity-100 group-hover:visible transition-all duration-200 z-50">
                    <div class="py-1">
                      <a routerLink="/loans" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Loans</a>
                      <a routerLink="/demand" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100" *ngIf="authService.hasRole(['SuperAdmin', 'SocietyAdmin'])">Monthly Demand</a>
                      <a routerLink="/vouchers" class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">Vouchers</a>
                    </div>
                  </div>
                </div>

                <a routerLink="/loans/report" 
                   routerLinkActive="bg-blue-700" 
                   class="px-3 py-2 rounded-md text-sm font-medium hover:bg-blue-500">
                  Reports
                </a>
              </div>
            </div>
          </div>
          
          <div class="flex items-center">
            <div class="relative group">
              <button class="flex items-center px-3 py-2 rounded-md text-sm font-medium hover:bg-blue-500">
                <span>{{ currentUser?.name || currentUser?.username }}</span>
                <span class="ml-2 text-xs bg-blue-800 px-2 py-1 rounded">{{ currentUser?.role }}</span>
                <svg class="ml-2 h-4 w-4" fill="currentColor" viewBox="0 0 20 20">
                  <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd"></path>
                </svg>
              </button>
              <div class="absolute right-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 opacity-0 invisible group-hover:opacity-100 group-hover:visible transition-all duration-200 z-50">
                <div class="py-1">
                  <button (click)="logout()" class="block w-full text-left px-4 py-2 text-sm text-gray-700 hover:bg-gray-100">
                    Logout
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </nav>
  `
})
export class NavbarComponent {
  currentUser = this.authService.getCurrentUser();

  constructor(
    public authService: AuthService,
    private router: Router
  ) {}

  logout(): void {
    this.authService.logout();
  }
}
