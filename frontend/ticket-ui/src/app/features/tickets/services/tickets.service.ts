import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Ticket } from '../models/ticket.model';
import { ResultModel } from '../../../core/models/result-model';

export interface CreateTicketRequest {
  userId: number;
  subject: string;
  description: string;
}

@Injectable({
  providedIn: 'root',
})
export class TicketsService {
  private readonly apiBaseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  getAllTickets() {
    return this.http.get<ResultModel<Ticket[]>>(`${this.apiBaseUrl}/tickets/GetAllTickets`);
  }

  createTicket(request: CreateTicketRequest){
    return this.http.post<ResultModel<Ticket>>(`${this.apiBaseUrl}/tickets/CreateTicket`, request);
  }

  closeTicket(ticketId: number){
    return this.http.post<ResultModel<object>>(`${this.apiBaseUrl}/tickets/CloseTicket`, { ticketId });
  }
}
