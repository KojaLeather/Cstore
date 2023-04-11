import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';
import { TestingComponent } from '../testing/testing.component';
import { Product } from '../interfaces/product';
import { FormBuilder, FormGroup } from '@angular/forms/'
import { HttpClient } from '@angular/common/http';
import { Order } from '../interfaces/orderdata';

@Component({
  selector: 'app-dialog-menu-order',
  templateUrl: './dialog-menu-order.component.html',
  styleUrls: ['./dialog-menu-order.component.css']
})
export class DialogMenuOrderComponent implements OnInit {
  products!: Product;
  order?: Order;
  constructor(public dialogRef: MatDialogRef<DialogMenuOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private httpClient: HttpClient) { }
  ngOnInit() {
    console.log(this.data);
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
/*  onClick(): void {
    console.log(this.orderData.get('eMail'))
  }
  */
}
