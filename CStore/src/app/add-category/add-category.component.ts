import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormControl, Form } from '@angular/forms'
import { Router } from '@angular/router';
import { Category } from '../interfaces/category';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  categoryform: FormGroup;
  category: Category;
  isDupe: boolean;
  constructor(private http: HttpClient, private router: Router) {

  }
  ngOnInit() {
    this.categoryform = new FormGroup({
      'category': new FormControl([''])
    })
    this.isDupe = false;
  }
  onCancel(): void {
    this.router.navigate([''])
  }
  onSubmit(): void {
    this.isDupe = false;
    var category = <Category>{}
    category.CategoryName = this.categoryform.controls['category'].value;
    this.http.post<Category>("api/Categories", category).subscribe(result => {
      console.log("Successful");
      this.router.navigate([``]);;
    }, error => {
      this.isDupe = true;
    })
    
  }
}
