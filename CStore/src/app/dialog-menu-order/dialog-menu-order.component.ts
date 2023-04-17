import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';
import { HomeComponent } from '../home/home.component';
import { Product } from '../interfaces/product';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Order } from '../interfaces/orderdata';

@Component({
  selector: 'app-dialog-menu-order',
  templateUrl: './dialog-menu-order.component.html',
  styleUrls: ['./dialog-menu-order.component.css']
})
export class DialogMenuOrderComponent implements OnInit {
  orderform!: FormGroup;
  products!: Product;
  order!: Order;
  constructor(public dialogRef: MatDialogRef<DialogMenuOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private http: HttpClient) {}
  ngOnInit() {
    this.orderform = new FormGroup({
      'phone': new FormControl(''),
      'eMail': new FormControl(''),
    })
    console.log(this.data.product.id);
  }
  onClose(): void {
    this.dialogRef.close();
  }
  onSubmit(): void {
    var order = <Order>{};
    order.eMail = this.orderform.controls['eMail'].value;
    order.phone = this.orderform.controls['phone'].value;
    order.productId = this.data.product.id;
    console.log(order);
    var url = "api/Orders"
    this.http.post<Order>(url, order).subscribe(result => {
      console.log(order, +" has been sent");
      this.dialogRef.close();
    }, error => console.error(error));
  }
}
