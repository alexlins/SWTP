import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public starShipStops: StarShipStop[];
  public url: string;

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  ngOnInit() {
  }
  
  public FetchStops(distance: string) {
    this.http.get<StarShipStop[]>(this.url + 'api/StarShip/StarShipStops/' + distance).subscribe(result => {
      this.starShipStops = result;
    }, error => console.error(error));

  }
}


interface StarShipStop {
  StarShipCode: number;
  Name: string;
  Stops: string;
  Message: string;
}
