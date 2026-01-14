import { Component, OnInit, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatDividerModule } from '@angular/material/divider';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { TicketsService } from '../../services/tickets.service';
import { Ticket } from '../../models/ticket.model';
import { TicketList } from '../../components/ticket-list/ticket-list';
import { TicketFormDialog } from '../../components/ticket-form-dialog/ticket-form-dialog';
import { TicketsFilter } from '../../models/tickets-filter.type';

@Component({
  selector: 'app-tickets-page',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatButtonToggleModule,
    MatDividerModule,
    MatSnackBarModule,
    TicketList,
  ],
  templateUrl: './tickets-page.html',
  styleUrl: './tickets-page.scss',
})
export class TicketsPage implements OnInit {
  tickets = signal<Ticket[]>([]);
  filter = signal<TicketsFilter>('all');
  isLoading = signal<boolean>(false);
  error = signal<string | null>(null);

  filteredTickets = computed(() => {
    const allTickets = this.tickets();
    const currentFilter = this.filter();
    
    if (currentFilter === 'all') {
      return allTickets;
    } else if (currentFilter === 'open') {
      return allTickets.filter(ticket => !ticket.isClosed);
    } else {
      return allTickets.filter(ticket => ticket.isClosed);
    }
  });

  constructor(
    private ticketsService: TicketsService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadTickets();
  }

  loadTickets(): void {
    this.startLoading();
    this.ticketsService.getAllTickets().subscribe({
      next: (response) => this.handleLoadSuccess(response),
      error: (err) => this.handleLoadError(err)
    });
  }

  private startLoading(): void {
    this.isLoading.set(true);
    this.error.set(null);
  }

  private handleLoadSuccess(response: any): void {
    this.isLoading.set(false);
    if (response.success) {
      this.tickets.set(response.data);
    } else {
      const errorMessage = response.errorMessage || 'שגיאה בטעינת הפניות';
      this.setError(errorMessage);
    }
  }

  private handleLoadError(err: any): void {
    this.isLoading.set(false);
    const errorMessage = 'שגיאה בטעינת הפניות מהשרת';
    this.setError(errorMessage);
    console.error('Error loading tickets:', err);
  }

  private setError(message: string): void {
    this.error.set(message);
    this.showError(message);
  }

  onFilterChange(filter: TicketsFilter): void {
    this.filter.set(filter);
  }

  openCreateDialog(): void {
    const dialogRef = this.dialog.open(TicketFormDialog, {
      width: '500px',
      direction: 'rtl'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.onTicketCreated(result);
      }
    });
  }

  onTicketCreated(ticket: Ticket): void {
    this.tickets.update(tickets => [...tickets, ticket]);
    this.showSuccess('פנייה נוצרה בהצלחה');
  }

  onTicketClosed(ticketId: number): void {
    this.tickets.update(tickets => 
      tickets.map(ticket => 
        ticket.ticketId === ticketId 
          ? { ...ticket, isClosed: true }
          : ticket
      )
    );
    this.showSuccess('פנייה נסגרה בהצלחה');
  }

  private showSuccess(message: string): void {
    this.snackBar.open(message, 'סגור', {
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      direction: 'rtl'
    });
  }

  private showError(message: string): void {
    this.snackBar.open(message, 'סגור', {
      duration: 5000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      direction: 'rtl',
      panelClass: ['error-snackbar']
    });
  }
}
