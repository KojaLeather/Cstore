import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ImageBase64 } from '../interfaces/image';
import { FormControl, FormGroup } from '@angular/forms';
import { ProductOne } from '../interfaces/productnew';
import { Category } from '../interfaces/category';
import { ThemePalette } from '@angular/material/core';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  fileName: string;
  base64: string;
  productForm: FormGroup;
  categories!: Category[]
  productId: number;

  constructor(private http: HttpClient) { }

  colorControl = new FormControl('primary' as ThemePalette)

  ngOnInit() {
    this.productForm = new FormGroup({
      'productTitle': new FormControl(),
      'productDescription': new FormControl(),
      'productQuantity': new FormControl(),
      'productCost': new FormControl()
    })
    this.http.get<Category[]>("api/Categories").subscribe(result => {
      this.categories = result;
      console.log(this.categories)
    }, error => console.error(error));
  }

  onFileSelected(fileInput: Event) {
    const element = fileInput.currentTarget as HTMLInputElement;
    if (element.files != null) {
      let file: File | null = element.files[0];
      this.fileName = file.name;
      this.getBase64(file).then(base64String => {
        this.base64 = base64String;
        console.log(this.fileName, this.base64)
      })
    }
  }
  getBase64(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      var reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = function () {
        var base64 = reader.result as string;
        resolve(base64);
      };
      reader.onerror = function () {
        reject('Error reading file');
      };
    });
  }
  postFile() {
    var returnBase64: ImageBase64 = {
      base64: this.base64,
      fileName: this.fileName
    };
    console.log(JSON.stringify(returnBase64));
    this.http.post<ImageBase64>("api/Home", returnBase64).subscribe(result => {
      console.log(JSON.stringify(returnBase64));
    }, error => {
      console.log(JSON.stringify(returnBase64));
    })
  }
  OnSubmit() {
    var product: ProductOne = {
      title: this.productForm.controls['productTitle'].value,
      description: this.productForm.controls['productDescription'].value,
      cost: this.productForm.controls['productCost'].value,
      quantity: this.productForm.controls['productQuantity'].value,
      categoryId: this.productId
    }
    this.http.post('api/Products', product).subscribe(response => {
      console.log(response)
      this.postFile();
    })
    console.log(JSON.stringify(product));
  }
  changeClient(value: number) {
    this.productId = value;
    console.log(value);
  }
}
