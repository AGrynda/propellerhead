import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from "./../customer/customer";
import { CustomersService } from "./../services/customers.service";
import { Server } from 'selenium-webdriver/safari';

@Component({
  selector: 'customers',
  templateUrl: './customers.component.html',
  providers: [CustomersService]
})
export class CustomersComponent {
  public customers: Customer[];
  queryParam: { } = {}
  key;

  constructor(private service: CustomersService) {
    this.loadCustomers();
  }

  loadCustomers(){    
    this.service.loadCustomers(this.queryParam).subscribe(result => {
      this.customers = result;
    }, error => console.error(error));

  }

  onSort(key){
    this.key = key;
    this.queryParam['orderBy'] = key;
    this.loadCustomers();
  }

  onSearch(search){
    this.queryParam['search'] = search;
    this.loadCustomers();
  }
}


