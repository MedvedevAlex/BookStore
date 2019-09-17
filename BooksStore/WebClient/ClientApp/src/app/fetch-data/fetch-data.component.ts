import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { log } from 'util';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  public text: string[];
  public book: any[];


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

    http.get<string[]>(baseUrl + 'api/SampleData/GetText').subscribe(result => {
      this.text = result;
    }, error => console.error(error));

    http.get<any[]>(baseUrl + 'api/Book').subscribe(result => {
      this.book = result;
    }, error => console.error(error));
    
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
