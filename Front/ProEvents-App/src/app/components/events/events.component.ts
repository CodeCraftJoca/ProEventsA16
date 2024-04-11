import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = [];
  public filteredEvents: any = [];

  imageWidth: number = 150;
  imageMargin: number = 2;
  showImage: boolean = true;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }

  filterEvents(filterBy: string): any {
    console.log("filterEvents")
    console.log(this.events)

    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: { theme: string; local: string; }) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      event.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEvents();
  }

  changeImage() {
    this.showImage = !this.showImage;
  }

  public getEvents(): void {
    this.http.get('https://localhost:5223/Event').subscribe({
      next: (response) => {
      this.events = response;
      this.filteredEvents = this.events;
    },
    error: (error) => console.log(error)
  });
  }

}
