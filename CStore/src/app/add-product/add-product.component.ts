import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ImageBase64 } from '../interfaces/image';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
  fileName = '';
  base64 = '';

  constructor(private http: HttpClient) { }

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
      Base64: this.base64,
      FileName: this.fileName
    };
    this.http.post<ImageBase64>("api/Home", returnBase64).subscribe(result => {
      console.log(returnBase64);
    }, error => {
      console.log(error, returnBase64);
    })
  }
}
