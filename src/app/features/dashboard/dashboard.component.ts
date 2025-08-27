
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
      <div class="mb-8">
        <h1 class="text-2xl font-bold text-gray-900">Dashboard</h1>
        <p class="mt-1 text-sm text-gray-600">Welcome back, {{ currentUser?.name || currentUser?.username }}!</p>
      </div>

      <!-- Super Admin Dashboard -->
      <div *ngIf="currentUser?.role === 'SuperAdmin'" class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        <div class="card">
          <div class="card-body">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-blue-100 rounded-full flex items-center justify-center">
                  <svg class="w-5 h-5 text-blue-600" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M13 6a3 3 0 11-6 0 3 3 0 016 0zM18 8a2 2 0 11-4 0 2 2 0 014 0zM14 15a4 4 0 00-8 0v3h8v-3z"></path>
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Total Societies</dt>
                  <dd class="text-lg font-medium text-gray-900">{{ stats.totalSocieties }}</dd>
                </dl>
              </div>
            </div>
            <div class="mt-5">
              <a routerLink="/societies" class="text-sm text-blue-600 hover:text-blue-500">
                Manage Societies →
              </a>
            </div>
          </div>
        </div>

        <div class="card">
          <div class="card-body">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-green-100 rounded-full flex items-center justify-center">
                  <svg class="w-5 h-5 text-green-600" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M9 6a3 3 0 11-6 0 3 3 0 016 0zM17 6a3 3 0 11-6 0 3 3 0 016 0zM12.93 17c.046-.327.07-.66.07-1a6.97 6.97 0 00-1.5-4.33A5 5 0 0119 16v1h-6.07zM6 11a5 5 0 015 5v1H1v-1a5 5 0 015-5z"></path>
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Total Users</dt>
                  <dd class="text-lg font-medium text-gray-900">{{ stats.totalUsers }}</dd>
                </dl>
              </div>
            </div>
            <div class="mt-5">
              <a routerLink="/users" class="text-sm text-blue-600 hover:text-blue-500">
                Manage Users →
              </a>
            </div>
          </div>
        </div>

        <div class="card">
          <div class="card-body">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-purple-100 rounded-full flex items-center justify-center">
                  <svg class="w-5 h-5 text-purple-600" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M8 9a3 3 0 100-6 3 3 0 000 6zM8 11a6 6 0 016 6H2a6 6 0 016-6zM16 7a1 1 0 10-2 0v1h-1a1 1 0 100 2h1v1a1 1 0 102 0v-1h1a1 1 0 100-2h-1V7z"></path>
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Total Members</dt>
                  <dd class="text-lg font-medium text-gray-900">{{ stats.totalMembers }}</dd>
                </dl>
              </div>
            </div>
            <div class="mt-5">
              <a routerLink="/members" class="text-sm text-blue-600 hover:text-blue-500">
                Manage Members →
              </a>
            </div>
          </div>
        </div>
      </div>

      <!-- Society Admin Dashboard -->
      <div *ngIf="currentUser?.role === 'SocietyAdmin'" class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        <div class="card">
          <div class="card-body">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-blue-100 rounded-full flex items-center justify-center">
                  <svg class="w-5 h-5 text-blue-600" fill="currentColor" viewBox="0 0 20 20">
                    <path d="M8 9a3 3 0 100-6 3 3 0 000 6zM8 11a6 6 0 016 6H2a6 6 0 016-6zM16 7a1 1 0 10-2 0v1h-1a1 1 0 100 2h1v1a1 1 0 102 0v-1h1a1 1 0 100-2h-1V7z"></path>
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Society Members</dt>
                  <dd class="text-lg font-medium text-gray-900">{{ stats.societyMembers }}</dd>
                </dl>
              </div>
            </div>
            <div class="mt-5">
              <a routerLink="/members" class="text-sm text-blue-600 hover:text-blue-500">
                Manage Members →
              </a>
            </div>
          </div>
        </div>

        <div class="card">
          <div class="card-body">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-green-100 rounded-full flex items-center justify-center">
                  <svg class="w-5 h-5 text-green-600" fill="currentColor" viewBox="0 0 20 20">
                    <path fill-rule="evenodd" d="M4 4a2 2 0 00-2 2v4a2 2 0 002 2V6h10a2 2 0 00-2-2H4zm2 6a2 2 0 012-2h8a2 2 0 012 2v4a2 2 0 01-2 2H8a2 2 0 01-2-2v-4zm6 4a2 2 0 100-4 2 2 0 000 4z" clip-rule="evenodd"></path>
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Active Loans</dt>
                  <dd class="text-lg font-medium text-gray-900">{{ stats.activeLoans }}</dd>
                </dl>
              </div>
            </div>
            <div class="mt-5">
              <a routerLink="/loans" class="text-sm text-blue-600 hover:text-blue-500">
                Manage Loans →
              </a>
            </div>
          </div>
        </div>

        <div class="card">
          <div class="card-body">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-yellow-100 rounded-full flex items-center justify-center">
                  <svg class="w-5 h-5 text-yellow-600" fill="currentColor" viewBox="0 0 20 20">
                    <path fill-rule="evenodd" d="M3 4a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zm0 4a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zm0 4a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zm0 4a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1z" clip-rule="evenodd"></path>
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Monthly Vouchers</dt>
                  <dd class="text-lg font-medium text-gray-900">{{ stats.monthlyVouchers }}</dd>
                </dl>
              </div>
            </div>
            <div class="mt-5">
              <a routerLink="/vouchers" class="text-sm text-blue-600 hover:text-blue-500">
                Manage Vouchers →
              </a>
            </div>
          </div>
        </div>
      </div>

      <!-- User Dashboard -->
      <div *ngIf="currentUser?.role === 'User'" class="grid grid-cols-1 md:grid-cols-2 gap-6">
        <div class="card">
          <div class="card-header">
            <h3 class="text-lg leading-6 font-medium text-gray-900">Society Information</h3>
          </div>
          <div class="card-body">
            <p class="text-sm text-gray-600">Society: {{ currentUser?.societyName }}</p>
            <div class="mt-4">
              <a routerLink="/members" class="text-sm text-blue-600 hover:text-blue-500">
                View Members →
              </a>
            </div>
          </div>
        </div>

        <div class="card">
          <div class="card-header">
            <h3 class="text-lg leading-6 font-medium text-gray-900">Quick Actions</h3>
          </div>
          <div class="card-body">
            <div class="space-y-3">
              <a routerLink="/loans/report" class="block text-sm text-blue-600 hover:text-blue-500">
                View Loan Reports →
              </a>
              <a routerLink="/vouchers" class="block text-sm text-blue-600 hover:text-blue-500">
                View Vouchers →
              </a>
            </div>
          </div>
        </div>
      </div>

      <!-- Member Dashboard -->
      <div *ngIf="currentUser?.role === 'Member'" class="grid grid-cols-1 md:grid-cols-2 gap-6">
        <div class="card">
          <div class="card-header">
            <h3 class="text-lg leading-6 font-medium text-gray-900">My Profile</h3>
          </div>
          <div class="card-body">
            <p class="text-sm text-gray-600">EDP No: {{ currentUser?.edpNo }}</p>
            <p class="text-sm text-gray-600">Society: {{ currentUser?.societyName }}</p>
          </div>
        </div>

        <div class="card">
          <div class="card-header">
            <h3 class="text-lg leading-6 font-medium text-gray-900">My Loans</h3>
          </div>
          <div class="card-body">
            <div class="mt-4">
              <a routerLink="/loans" class="text-sm text-blue-600 hover:text-blue-500">
                View My Loans →
              </a>
            </div>
          </div>
        </div>
      </div>

      <!-- Recent Activity -->
      <div class="mt-8">
        <div class="card">
          <div class="card-header">
            <h3 class="text-lg leading-6 font-medium text-gray-900">Recent Activity</h3>
          </div>
          <div class="card-body">
            <div class="flow-root">
              <ul class="-mb-8">
                <li *ngFor="let activity of recentActivity; let last = last">
                  <div class="relative pb-8">
                    <span *ngIf="!last" class="absolute top-4 left-4 -ml-px h-full w-0.5 bg-gray-200" aria-hidden="true"></span>
                    <div class="relative flex space-x-3">
                      <div>
                        <span class="h-8 w-8 rounded-full bg-blue-500 flex items-center justify-center ring-8 ring-white">
                          <svg class="h-5 w-5 text-white" fill="currentColor" viewBox="0 0 20 20">
                            <path fill-rule="evenodd" d="M6 2a1 1 0 00-1 1v1H4a2 2 0 00-2 2v10a2 2 0 002 2h12a2 2 0 002-2V6a2 2 0 00-2-2h-1V3a1 1 0 10-2 0v1H7V3a1 1 0 00-1-1zm0 5a1 1 0 000 2h8a1 1 0 100-2H6z" clip-rule="evenodd"></path>
                          </svg>
                        </span>
                      </div>
                      <div class="min-w-0 flex-1">
                        <div>
                          <div class="text-sm">
                            <span class="font-medium text-gray-900">{{ activity.action }}</span>
                          </div>
                          <p class="mt-0.5 text-sm text-gray-500">{{ activity.timestamp | date:'short' }}</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  `
})
export class DashboardComponent implements OnInit {
  currentUser = this.authService.getCurrentUser();
  stats = {
    totalSocieties: 12,
    totalUsers: 45,
    totalMembers: 234,
    societyMembers: 67,
    activeLoans: 23,
    monthlyVouchers: 15
  };

  recentActivity = [
    { action: 'New member registration completed', timestamp: new Date() },
    { action: 'Monthly demand processing completed', timestamp: new Date(Date.now() - 86400000) },
    { action: 'Loan disbursement approved', timestamp: new Date(Date.now() - 172800000) }
  ];

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    // Load dashboard statistics based on user role
    this.loadDashboardStats();
  }

  private loadDashboardStats(): void {
    // This would typically call various API endpoints to get real statistics
    // For now, we're using mock data
  }
}
