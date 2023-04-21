import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrderPageComponent } from './order-page/order-page.component';
import { AddProductComponent } from './add-product/add-product.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'orders', component: OrdersListComponent },
  { path: 'product/:id', component: ProductPageComponent },
  { path: 'order/:id', component: OrderPageComponent },
  { path: 'addproduct', component: AddProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
