import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../interfaces/orderdata';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'phone', 'eMail', 'productId']
  public orders!: MatTableDataSource<Order>
  constructor(private http: HttpClient) { }
  ngOnInit() {
    this.http.get<Order[]>("api/Orders").subscribe(result => {
      this.orders = new MatTableDataSource<Order>(result);
      console.log(this.orders);
    }, error => console.log(error));
  }
  onClick() {
    console.log("Row is clicked")
  }
}
