
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Customer } from '../customer/customer';

@Injectable()
export class CustomersService{
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        
    }

    loadCustomers(params){
        return this.http.get<Customer[]>(this.baseUrl + 'api/customers', { params: params });
    }

    loadCustomer(id){
        return this.http.get<Customer>(this.baseUrl + 'api/customers/' + id);
    }

    updateStatus(id, value){
        return this.http.put(this.baseUrl + 'api/customers/' + id+'/status', { newStatus: value });
    }

    deleteNote(noteId){
        return this.http.delete(this.baseUrl + 'api/notes/' + noteId);
    }

    addNote(newNote: { customerId: number, content: string }){
        return this.http.post(this.baseUrl + 'api/notes', newNote);
    }
}