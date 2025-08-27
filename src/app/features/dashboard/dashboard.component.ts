
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { AuthService, User } from '../../core/services/auth.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterLink],
  template: `
    <div class="max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8">
      <!-- Welcome Header -->
      <div class="mb-8">
        <h1 class="text-3xl font-bold text-gray-900">
          Welcome, {{ currentUser?.name }}!
        </h1>
        <p class="mt-2 text-gray-600">{{ getRoleDisplayName() }} Dashboard</p>
      </div>

      <!-- Super Admin Dashboard -->
      <div *ngIf="currentUser?.role === 'SuperAdmin'" class="space-y-6">
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
          <!-- Stats Cards -->
          <div class="card p-6">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-blue-500 rounded-md flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 21V5a2 2 0 00-2-2H7a2 2 0 00-2 2v16m14 0h2m-2 0h-5m-9 0H3m2 0h5M9 7h1m-1 4h1m4-4h1m-1 4h1m-5 10v-5a1 1 0 011-1h2a1 1 0 011 1v5m-4 0h4" />
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Total Societies</dt>
                  <dd class="text-lg font-medium text-gray-900">12</dd>
                </dl>
              </div>
            </div>
          </div>

          <div class="card p-6">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-green-500 rounded-md flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z" />
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Total Users</dt>
                  <dd class="text-lg font-medium text-gray-900">245</dd>
                </dl>
              </div>
            </div>
          </div>

          <div class="card p-6">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-yellow-500 rounded-md flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197m13.5-9a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0z" />
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Total Members</dt>
                  <dd class="text-lg font-medium text-gray-900">1,247</dd>
                </dl>
              </div>
            </div>
          </div>

          <div class="card p-6">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-purple-500 rounded-md flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Active Loans</dt>
                  <dd class="text-lg font-medium text-gray-900">89</dd>
                </dl>
              </div>
            </div>
          </div>
        </div>

        <!-- Quick Actions -->
        <div class="card p-6">
          <h2 class="text-lg font-medium text-gray-900 mb-4">Quick Actions</h2>
          <div class="grid grid-cols-2 md:grid-cols-4 gap-4">
            <a routerLink="/societies/create" class="btn btn-primary text-center">
              Create Society
            </a>
            <a routerLink="/users/create" class="btn btn-primary text-center">
              Add User
            </a>
            <a routerLink="/members/create" class="btn btn-primary text-center">
              Add Member
            </a>
            <a routerLink="/loans/report" class="btn btn-secondary text-center">
              Loan Reports
            </a>
          </div>
        </div>
      </div>

      <!-- Society Admin Dashboard -->
      <div *ngIf="currentUser?.role === 'SocietyAdmin'" class="space-y-6">
        <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
          <div class="card p-6">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-green-500 rounded-md flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z" />
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Society Users</dt>
                  <dd class="text-lg font-medium text-gray-900">23</dd>
                </dl>
              </div>
            </div>
          </div>

          <div class="card p-6">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-blue-500 rounded-md flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4.354a4 4 0 110 5.292M15 21H3v-1a6 6 0 0112 0v1zm0 0h6v-1a6 6 0 00-9-5.197m13.5-9a2.5 2.5 0 11-5 0 2.5 2.5 0 015 0z" />
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Society Members</dt>
                  <dd class="text-lg font-medium text-gray-900">156</dd>
                </dl>
              </div>
            </div>
          </div>

          <div class="card p-6">
            <div class="flex items-center">
              <div class="flex-shrink-0">
                <div class="w-8 h-8 bg-orange-500 rounded-md flex items-center justify-center">
                  <svg class="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                  </svg>
                </div>
              </div>
              <div class="ml-5 w-0 flex-1">
                <dl>
                  <dt class="text-sm font-medium text-gray-500 truncate">Pending Approvals</dt>
                  <dd class="text-lg font-medium text-gray-900">3</dd>
                </dl>
              </div>
            </div>
          </div>
        </div>

        <div class="card p-6">
          <h2 class="text-lg font-medium text-gray-900 mb-4">Society Management</h2>
          <div class="grid grid-cols-2 md:grid-cols-4 gap-4">
            <a routerLink="/users/create" class="btn btn-primary text-center">
              Add User
            </a>
            <a routerLink="/members/create" class="btn btn-primary text-center">
              Add Member
            </a>
            <a routerLink="/loans/create" class="btn btn-primary text-center">
              Create Loan
            </a>
            <a routerLink="/demand" class="btn btn-secondary text-center">
              Monthly Demand
            </a>
          </div>
        </div>
      </div>

      <!-- User Dashboard -->
      <div *ngIf="currentUser?.role === 'User'" class="space-y-6">
        <div class="card p-6">
          <h2 class="text-lg font-medium text-gray-900 mb-4">Society Information (Read-Only)</h2>
          <div class="grid grid-cols-2 md:grid-cols-4 gap-4">
            <a routerLink="/members" class="btn btn-secondary text-center">
              View Members
            </a>
            <a routerLink="/loans" class="btn btn-secondary text-center">
              View Loans
            </a>
            <a routerLink="/loans/report" class="btn btn-secondary text-center">
              Loan Reports
            </a>
            <a routerLink="/societies" class="btn btn-secondary text-center">
              Society Details
            </a>
          </div>
        </div>
      </div>

      <!-- Member Dashboard -->
      <div *ngIf="currentUser?.role === 'Member'" class="space-y-6">
        <div class="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div class="card p-6">
            <h3 class="text-lg font-medium text-gray-900 mb-4">My Profile</h3>
            <div class="space-y-2">
              <p><span class="font-medium">Member ID:</span> MEM_001</p>
              <p><span class="font-medium">Society:</span> ABC Cooperative Society</p>
              <p><span class="font-medium">Status:</span> <span class="text-green-600">Active</span></p>
              <p><span class="font-medium">Share Balance:</span> ₹25,000</p>
            </div>
          </div>

          <div class="card p-6">
            <h3 class="text-lg font-medium text-gray-900 mb-4">My Loans</h3>
            <div class="space-y-2">
              <p><span class="font-medium">Active Loans:</span> 1</p>
              <p><span class="font-medium">Outstanding Amount:</span> ₹45,000</p>
              <p><span class="font-medium">Next EMI Date:</span> 15th Jan 2024</p>
              <p><span class="font-medium">EMI Amount:</span> ₹2,500</p>
            </div>
          </div>
        </div>

        <div class="card p-6">
          <h2 class="text-lg font-medium text-gray-900 mb-4">Quick Actions</h2>
          <div class="grid grid-cols-2 md:grid-cols-3 gap-4">
            <a routerLink="/loans" class="btn btn-primary text-center">
              View My Loans
            </a>
            <button class="btn btn-secondary">
              Download Statements
            </button>
            <button class="btn btn-secondary">
              Update Profile
            </button>
          </div>
        </div>
      </div>
    </div>
  `
})
export class DashboardComponent implements OnInit {
  currentUser: User | null = null;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.currentUser$.subscribe(user => {
      this.currentUser = user;
    });
  }

  getRoleDisplayName(): string {
    switch (this.currentUser?.role) {
      case 'SuperAdmin': return 'Super Administrator';
      case 'SocietyAdmin': return 'Society Administrator';
      case 'User': return 'User';
      case 'Member': return 'Member';
      default: return 'User';
    }
  }
}
