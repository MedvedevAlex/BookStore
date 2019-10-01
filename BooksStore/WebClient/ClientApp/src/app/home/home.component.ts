import { Component } from '@angular/core';
import { UrlInfoService } from '../shared/services/url-info.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private url: UrlInfoService) {
    url.getBookUrlAsync('GetBooks');
  }
}
