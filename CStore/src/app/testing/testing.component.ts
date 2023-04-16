import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from "../interfaces/product";
import { Type } from "../interfaces/type";
import { Router, ParamMap, ActivatedRoute } from '@angular/router';
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
  types!: Type[]
  imageSource: any;
  check!: string;
  type!: string | null;

  constructor(private http: HttpClient, public dialog: MatDialog, private route: ActivatedRoute) {
  }
  ngOnInit() {
    this.http.get<Product>("api/Products").subscribe(result => {
      this.product = result;
      //console.log(this.product);
    }, error => console.error(error));
    this.http.get<Type[]>("api/TypeTables").subscribe(result => {
      this.types = result;
      console.log(this.types)
    }, error => console.error(error));
    this.type = this.route.snapshot.paramMap.get('type');
    console.log(this.type);
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
