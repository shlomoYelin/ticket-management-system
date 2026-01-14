import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MatDialogTitle, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { TicketsService, CreateTicketRequest } from '../../services/tickets.service';

@Component({
  selector: 'app-ticket-form-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './ticket-form-dialog.html',
  styleUrl: './ticket-form-dialog.scss',
})
export class TicketFormDialog {
  form!: FormGroup;
  isSubmitting = signal<boolean>(false);

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<TicketFormDialog>,
    private ticketsService: TicketsService
  ) {
    this.initForm();
  }
  
  private initForm(): void {
    this.form = this.fb.group({
      userId: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d+$/),
        (control) => {
          const value = Number(control.value);
          if (isNaN(value) || value < 1) {
            return { min: true };
          }
          return null;
        }
      ]),
      subject: new FormControl('', [
        Validators.required,
        Validators.minLength(3)
      ]),
      description: new FormControl('', [
        Validators.required,
        Validators.minLength(10)
      ])
    });
  }

  get userId() {
    return this.form.get('userId');
  }

  get subject() {
    return this.form.get('subject');
  }

  get description() {
    return this.form.get('description');
  }

  onSubmit(): void {
    this.form.markAllAsTouched();

    if (!this.isFormValid()) {
      return;
    }

    const request = this.prepareRequest();
    this.sendRequest(request);
  }

  private isFormValid(): boolean {
    return !this.form.invalid && !this.isSubmitting();
  }

  private prepareRequest(): CreateTicketRequest {
    return {
      userId: Number(this.userId?.value),
      subject: this.subject?.value?.trim() || '',
      description: this.description?.value?.trim() || ''
    };
  }

  private sendRequest(request: CreateTicketRequest): void {
    this.isSubmitting.set(true);

    this.ticketsService.createTicket(request).subscribe({
      next: (response) => this.handleSuccess(response),
      error: (err) => this.handleError(err)
    });
  }

  private handleSuccess(response: any): void {
    this.isSubmitting.set(false);
    if (response.success) {
      this.dialogRef.close(response.data);
    } else {
      console.error('Error creating ticket:', response.errorMessage);
      this.dialogRef.close();
    }
  }

  private handleError(err: any): void {
    this.isSubmitting.set(false);
    console.error('Error creating ticket:', err);
    this.dialogRef.close();
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
