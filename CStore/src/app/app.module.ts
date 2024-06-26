import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/auth.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { DialogMenuOrderComponent } from './dialog-menu-order/dialog-menu-order.component';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ProductPageComponent } from './product-page/product-page.component'
import { MatGridListModule } from '@angular/material/grid-list';
import { OrderPageComponent } from './order-page/order-page.component';
import { AddProductComponent } from './add-product/add-product.component';
import { AddCategoryComponent } from './add-category/add-category.component'
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { LoginComponent } from './auth/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DialogMenuOrderComponent,
    OrdersListComponent,
    HomeComponent,
    ProductPageComponent,
    OrderPageComponent,
    AddProductComponent,
    AddCategoryComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, BrowserAnimationsModule, AppRoutingModule, MatButtonModule, MatToolbarModule, MatIconModule, MatCardModule,
    MatDialogModule, MatInputModule, ReactiveFormsModule, MatTableModule, MatSidenavModule, MatGridListModule, MatSelectModule, MatFormFieldModule,
    MatMenuModule, MatPaginatorModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
