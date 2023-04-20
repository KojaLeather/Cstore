import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../interfaces/orderdata';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.css']
})
export class OrderPageComponent implements OnInit {
  order: Order;
  id: number;
  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {

  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      console.log(this.id);
    })
    this.http.get<Order>("api/Orders/" + this.id).subscribe(result => {
      this.order = result;
      console.log(this.order);
    })
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
  onClick() {
    this.order.status = this.order.status + 1;
    this.http.put<Order>("api/Orders/" + this.order.id, this.order).subscribe(result => {
      console.log("Put method is sended")
    })
    this.router.navigate([`/orders`]);
  }
  onCancel() {
    this.order.status = 4;
    this.http.put<Order>("api/Orders/" + this.order.id, this.order).subscribe(result => {
      console.log("Put method is sended")
    })
    this.router.navigate([`/orders`]);
  }
}
