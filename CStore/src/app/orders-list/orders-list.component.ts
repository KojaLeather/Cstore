import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../interfaces/orderdata';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { OrderPageComponent } from '../order-page/order-page.component';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'phone', 'eMail', 'productId', 'status']
  public orders!: MatTableDataSource<Order>
  constructor(private http: HttpClient, private router: Router) { }
  ngOnInit() {
    this.http.get<Order[]>("api/Orders").subscribe(result => {
      this.orders = new MatTableDataSource<Order>(result);
      console.log(this.orders);
    }, error => console.log(error));
  }
  onClick(id: number) {
    this.router.navigate(['/order/' + id]);
  }
  getStatus(status: number) {
    switch (status) {
      case 1: {
        return "Ordered";
      }
      case 2: {
        return "Accepted";
      }
      case 3: {
        return "Completed";
      }
      case 4: {
        return "Canceled";
      }
      default: {
        break;
      }
    }
    return "Error";
  }
}
