import { Routes } from '@angular/router';

import { LoginComponent } from './public/login/login.component';
import { SignupComponent } from './public/signup/signup.component';
import { AboutComponent } from './public/about/about.component';
import { DashboardComponent } from './secure/dashboard/dashboard.component';

export const routes: Routes = [
  // Public routes
  {
    path: 'public',
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'signup', component: SignupComponent },
      { path: 'logout', redirectTo: 'login' },
      { path: 'about', component: AboutComponent },
    ],
  },

  // Secure routes
  {
    path: 'secure',
    children: [{ path: 'dashboard', component: DashboardComponent }],
  },

  // Fallback route
  { path: '**', redirectTo: 'public/login', pathMatch: 'full' },
];
