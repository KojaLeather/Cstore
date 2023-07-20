import { HttpClient, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from "../interfaces/product";
import { Category } from "../interfaces/type";
import { Router, ParamMap, ActivatedRoute } from '@angular/router';
import { Observable } from "rxjs";
import { MatDialog } from '@angular/material/dialog';
import { DialogMenuOrderComponent } from '../dialog-menu-order/dialog-menu-order.component';
import { PaginationHeader } from '../interfaces/paginationHeader';

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  product!: Product
  categories!: Category[]
  imageSource: any;
  page: number;
  itemsPerPage: 5;
  paginationHeader: PaginationHeader;
  category: string;

  constructor(private http: HttpClient, public dialog: MatDialog, private route: ActivatedRoute, private router: Router) {
  }
  ngOnInit() {
    this.page = 1;
    this.http.get<Product>(`api/Products?Page=${this.page}&ItemsPerPage=5`, { observe: 'response' })
      .subscribe((response: HttpResponse<Product>) => {
        this.product = response.body!;
        const headers = response.headers.get('X-Pagination');
        console.log(headers);
        this.paginationHeader = JSON.parse(headers!) as PaginationHeader;
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
    console.log(this.page)
    this.http.get<Product>(`api/Products?Page=1&ItemsPerPage=5&Category=${category}`, { observe: 'response' })
      .subscribe((response: HttpResponse<Product>) => {
        this.product = response.body!;
        const headers = response.headers.get('X-Pagination');
        console.log(headers);
        this.paginationHeader = JSON.parse(headers!) as PaginationHeader;
      }, error => console.error(error));
  }
  OnImageClick(id: number) {
    this.router.navigate([`/product/${id}`])
  }
  title = 'CStore';
  onPageChange(event: any) {
    var category = ``;
    if (this.category != null) category = `&Category=${this.category}`
    console.log(event);
    var newPageIndex = event.pageIndex;
    console.log(newPageIndex)
    this.http.get<Product>(`api/Products?Page=${newPageIndex+1}&ItemsPerPage=5${category}`, { observe: 'response' })
      .subscribe((response: HttpResponse<Product>) => {
        this.page = newPageIndex;
        this.product = response.body!;
        const headers = response.headers.get('X-Pagination');
        console.log(headers);
        this.paginationHeader = JSON.parse(headers!) as PaginationHeader;
      }, error => console.error(error));
  }
}
