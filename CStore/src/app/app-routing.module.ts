import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestingComponent } from './testing/testing.component';
import { OrdersListComponent } from './orders-list/orders-list.component';

const routes: Routes = [
  { path: 'testing', component: TestingComponent },
  { path: 'orders', component: OrdersListComponent },
  { path: 'testing/:type', component: TestingComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
