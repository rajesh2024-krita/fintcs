import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { roleGuard } from './core/guards/role.guard';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () => import('./features/auth/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'dashboard',
    loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent),
    canActivate: [authGuard]
  },
  {
    path: 'societies',
    loadComponent: () => import('./features/societies/society-list/society-list.component').then(m => m.SocietyListComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'societies/create',
    loadComponent: () => import('./features/societies/society-form/society-form.component').then(m => m.SocietyFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin'] }
  },
  {
    path: 'societies/:id/edit',
    loadComponent: () => import('./features/societies/society-form/society-form.component').then(m => m.SocietyFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'users',
    loadComponent: () => import('./features/users/user-list/user-list.component').then(m => m.UserListComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'users/create',
    loadComponent: () => import('./features/users/user-form/user-form.component').then(m => m.UserFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'users/:id/edit',
    loadComponent: () => import('./features/users/user-form/user-form.component').then(m => m.UserFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'members',
    loadComponent: () => import('./features/members/member-list/member-list.component').then(m => m.MemberListComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User'] }
  },
  {
    path: 'members/create',
    loadComponent: () => import('./features/members/member-form/member-form.component').then(m => m.MemberFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'members/:id/edit',
    loadComponent: () => import('./features/members/member-form/member-form.component').then(m => m.MemberFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'loans',
    loadComponent: () => import('./features/loans/loan-list/loan-list.component').then(m => m.LoanListComponent),
    canActivate: [authGuard]
  },
  {
    path: 'loans/create',
    loadComponent: () => import('./features/loans/loan-form/loan-form.component').then(m => m.LoanFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'loans/report',
    loadComponent: () => import('./features/loans/loan-report/loan-report.component').then(m => m.LoanReportComponent),
    canActivate: [authGuard]
  },
  {
    path: 'demand',
    loadComponent: () => import('./features/demand/demand-processing/demand-processing.component').then(m => m.DemandProcessingComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'vouchers',
    loadComponent: () => import('./features/vouchers/voucher-list/voucher-list.component').then(m => m.VoucherListComponent),
    canActivate: [authGuard]
  },
  {
    path: 'vouchers/create',
    loadComponent: () => import('./features/vouchers/voucher-form/voucher-form.component').then(m => m.VoucherFormComponent),
    canActivate: [authGuard, roleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: '/login'
  }
];