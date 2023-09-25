import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.routeguard';
import { HomeComponent } from './home/home.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrderPageComponent } from './order-page/order-page.component';
import { AddProductComponent } from './add-product/add-product.component';
import { AddCategoryComponent } from './add-category/add-category.component';
import { LoginComponent } from './auth/login.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'orders', component: OrdersListComponent, canActivate: [AuthGuard] },
  { path: 'product/:id', component: ProductPageComponent },
  { path: 'order/:id', component: OrderPageComponent, canActivate: [AuthGuard] },
  { path: 'addproduct', component: AddProductComponent, canActivate: [AuthGuard] },
  { path: 'addcategory', component: AddCategoryComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
