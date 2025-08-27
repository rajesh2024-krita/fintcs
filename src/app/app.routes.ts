
import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { RoleGuard } from './core/guards/role.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadComponent: () => import('./features/auth/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'dashboard',
    loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent),
    canActivate: [AuthGuard]
  },
  {
    path: 'societies',
    loadComponent: () => import('./features/societies/society-list/society-list.component').then(m => m.SocietyListComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'societies/create',
    loadComponent: () => import('./features/societies/society-form/society-form.component').then(m => m.SocietyFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin'] }
  },
  {
    path: 'societies/:id/edit',
    loadComponent: () => import('./features/societies/society-form/society-form.component').then(m => m.SocietyFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'users',
    loadComponent: () => import('./features/users/user-list/user-list.component').then(m => m.UserListComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'users/create',
    loadComponent: () => import('./features/users/user-form/user-form.component').then(m => m.UserFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'users/:id/edit',
    loadComponent: () => import('./features/users/user-form/user-form.component').then(m => m.UserFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'members',
    loadComponent: () => import('./features/members/member-list/member-list.component').then(m => m.MemberListComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User'] }
  },
  {
    path: 'members/create',
    loadComponent: () => import('./features/members/member-form/member-form.component').then(m => m.MemberFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'members/:id/edit',
    loadComponent: () => import('./features/members/member-form/member-form.component').then(m => m.MemberFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'loans',
    loadComponent: () => import('./features/loans/loan-list/loan-list.component').then(m => m.LoanListComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User', 'Member'] }
  },
  {
    path: 'loans/create',
    loadComponent: () => import('./features/loans/loan-form/loan-form.component').then(m => m.LoanFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'loans/:id/edit',
    loadComponent: () => import('./features/loans/loan-form/loan-form.component').then(m => m.LoanFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'loans/report',
    loadComponent: () => import('./features/loans/loan-report/loan-report.component').then(m => m.LoanReportComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User'] }
  },
  {
    path: 'demand',
    loadComponent: () => import('./features/demand/demand-processing/demand-processing.component').then(m => m.DemandProcessingComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'vouchers',
    loadComponent: () => import('./features/vouchers/voucher-list/voucher-list.component').then(m => m.VoucherListComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'vouchers/create',
    loadComponent: () => import('./features/vouchers/voucher-form/voucher-form.component').then(m => m.VoucherFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: 'vouchers/:id/edit',
    loadComponent: () => import('./features/vouchers/voucher-form/voucher-form.component').then(m => m.VoucherFormComponent),
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] }
  },
  {
    path: '**',
    redirectTo: '/dashboard'
  }
];
