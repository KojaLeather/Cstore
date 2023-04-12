import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from "../interfaces/product";
import { Observable } from "rxjs";
import { MatDialog } from '@angular/material/dialog';
import { DialogMenuOrderComponent } from '../dialog-menu-order/dialog-menu-order.component';

@Component({
  selector: 'app-root',
  templateUrl: './testing.component.html',
  styleUrls: ['./testing.component.css']
})
export class TestingComponent implements OnInit {
  product!: Product
  imageSource: any;
  check!: string;

  constructor(private http: HttpClient, public dialog: MatDialog) {
  }
  ngOnInit() {
    this.http.get<Product>("api/Products").subscribe(result => {
      this.product = result;
      //console.log(this.product);
    }, error => console.error(error));
  }
  openDialog(i: any): void {
    const dialogRef = this.dialog.open(DialogMenuOrderComponent, {
      width: '600px',
      /*    panelClass: "mdc-dialog__surface", */
      data: { product: this.product.data[i - 1] }
    });
    dialogRef.afterClosed().subscribe(result =>
      console.log(result));
  }
  title = 'CStore';
}
