import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  book: any[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>('http://localhost:5000/api/Book/GetBooks').subscribe(result => {
      this.book = result;
      console.log('5555555555555', result);

    }, error => console.error(error));
  }

  ngOnInit() {

  }

}
