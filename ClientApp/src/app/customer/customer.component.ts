import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from './customer';
import { ActivatedRoute } from '@angular/router';
import { CustomersService } from './../services/customers.service';
import { validateConfig } from '@angular/router/src/config';

@Component({
  selector: 'customer',
  templateUrl: './customer.component.html',
  providers: [CustomersService]
})
export class CustomerComponent {
  public customer: Customer;
  sub;
  id;

  constructor(private route: ActivatedRoute, private service : CustomersService ) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
       this.id = +params['id']; 
       this.loadCustomer();
    });
  }

  loadCustomer(){
    this.service.loadCustomer(this.id).subscribe(result => {
        this.customer = result;
    }, error => console.error(error));
  }

  onStatusChanged(value){
    this.service.updateStatus(this.id, value).subscribe(result => {
      this.loadCustomer();
    }, error => console.error(error));
  }

  onRemove(noteId){    
    this.service.deleteNote(noteId).subscribe(result => {
      this.loadCustomer();
    }, error => console.error(error));
  }

  onCreate(note){
    let newNote =  { customerId : this.id, content: note }
    this.service.addNote(newNote).subscribe(result => {
      this.loadCustomer();
    }, error => console.error(error));
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}

