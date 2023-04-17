import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from "../interfaces/product";
import { Category } from "../interfaces/type";
import { Router, ParamMap, ActivatedRoute } from '@angular/router';
import { Observable } from "rxjs";
import { MatDialog } from '@angular/material/dialog';
import { DialogMenuOrderComponent } from '../dialog-menu-order/dialog-menu-order.component';

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  product!: Product
  categories!: Category[]
  imageSource: any;

  constructor(private http: HttpClient, public dialog: MatDialog, private route: ActivatedRoute) {
  }
  ngOnInit() {
      this.http.get<Product>("api/Products").subscribe(result => {
        this.product = result;
        console.log(this.product);
      }, error => console.error(error));
    this.http.get<Category[]>("api/Categories").subscribe(result => {
      this.categories = result;
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
  ChangeCategory(category: string) {
    this.http.get<Product>(`api/Products/${category}`).subscribe(result => {
      this.product = result;
      console.log(result);
    }, error => console.error(error));
  }
  title = 'CStore';
}
