import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Ticket } from '../../models/ticket.model';
import { TicketsService } from '../../services/tickets.service';

@Component({
  selector: 'app-ticket-list',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
  ],
  templateUrl: './ticket-list.html',
  styleUrl: './ticket-list.scss',
})
export class TicketList {
  @Input() tickets: Ticket[] = [];
  @Input() isLoading: boolean = false;
  @Output() ticketClosed = new EventEmitter<number>();

  closingTicketId: number | null = null;

  constructor(
    private ticketsService: TicketsService,
    private snackBar: MatSnackBar
  ) {}

  closeTicket(ticketId: number): void {
    if (this.isClosingInProgress()) {
      return;
    }

    this.startClosing(ticketId);
    this.ticketsService.closeTicket(ticketId).subscribe({
      next: (response) => this.handleCloseSuccess(response, ticketId),
      error: (err) => this.handleCloseError(err)
    });
  }

  private isClosingInProgress(): boolean {
    return this.closingTicketId !== null;
  }

  private startClosing(ticketId: number): void {
    this.closingTicketId = ticketId;
  }

  private handleCloseSuccess(response: any, ticketId: number): void {
    this.closingTicketId = null;
    if (response.success) {
      this.ticketClosed.emit(ticketId);
    } else {
      this.showError(response.errorMessage || 'שגיאה בסגירת הפנייה');
    }
  }

  private handleCloseError(err: any): void {
    this.closingTicketId = null;
    this.showError('שגיאה בסגירת הפנייה מהשרת');
    console.error('Error closing ticket:', err);
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
