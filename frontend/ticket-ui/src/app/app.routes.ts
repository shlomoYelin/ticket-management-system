import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'tickets' },
  {
    path: 'tickets',
    loadComponent: () =>
      import('./features/tickets/pages/tickets-page/tickets-page').then(m => m.TicketsPage),
  },
];
