import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public text: string[];
  public book: any[];


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>('http://localhost:5000/api/Book/GetBooks').subscribe(result => {
      this.book = result;
      console.log('5555555555555', result);
      
    }, error => console.error(error));

    http.get<string[]>(baseUrl + 'api/SampleData/GetText').subscribe(result => {
      this.text = result;
    }, error => console.error(error));

    http.get<any[]>(baseUrl + 'api/Book').subscribe(result => {
      this.book = result;
    }, error => console.error(error));
    
  }
}
