import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';
import { TestingComponent } from '../testing/testing.component';
import { Product } from '../interfaces/product';

@Component({
  selector: 'app-dialog-menu-order',
  templateUrl: './dialog-menu-order.component.html',
  styleUrls: ['./dialog-menu-order.component.css']
})
export class DialogMenuOrderComponent {
  products!: Product;
  constructor(public dialogRef: MatDialogRef<DialogMenuOrderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }
  ngOnInit() {
    console.log(this.data);
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
}
