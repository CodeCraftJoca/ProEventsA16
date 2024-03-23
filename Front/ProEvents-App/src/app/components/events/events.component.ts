import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent {

  public events: any;
 

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEvents();
  }

  public getEvents(){
    this.http.get('https://localhost:5223/Event').subscribe( 
      response => this.events = response,
      error => console.log(error)
    );
  }

}
