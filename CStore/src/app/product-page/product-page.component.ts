import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from "../interfaces/product";
import { ActivatedRoute, Route } from "@angular/router"
import { Subscription } from "rxjs";
import { Order } from "../interfaces/orderdata";
import { FormBuilder, FormGroup, FormControl } from '@angular/forms'
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent {
  product!: Product;
  orderform!: FormGroup;
  order!: Order;
  id: number;
  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {

  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id']
    })
    this.http.get<Product>("api/Products/" + this.id).subscribe(result => {
      this.product = result
      console.log(this.product)
    })
    this.orderform = new FormGroup({
      'phone': new FormControl(''),
      'eMail': new FormControl(''),
    })
  }
  onCancel(): void {
    this.router.navigate([''])
  }
  onSubmit(): void {
    var order = <Order>{};
    order.eMail = this.orderform.controls['eMail'].value;
    order.phone = this.orderform.controls['phone'].value;
    order.productId = this.id;
    order.status = 1;
    console.log(order);
    var url = "api/Orders"
    this.http.post<Order>(url, order).subscribe(result => {
      console.log(order, +" has been sent");
    }, error => console.error(error));
    this.router.navigate([''])
  }
}
