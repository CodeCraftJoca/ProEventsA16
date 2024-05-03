import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Events } from 'src/app/models/Events';
import { EventsService } from 'src/app/services/events.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss'],
})
export class EventListComponent {
  modalRef?: BsModalRef;

  public title = 'Events';

  public events: Events[] = [];
  public filteredEvents: Events[] = [];

  public imageWidth: number = 150;
  public imageMargin: number = 2;
  public showImage: boolean = true;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.filteredEvents = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }

  public filterEvents(filterBy: string): Events[] {
    console.log('filterEvents');
    console.log(this.events);

    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: { theme: string; local: string }) =>
        event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        event.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(
    private EventsService: EventsService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.spinner.show();
    this.getEvents();
  }

  public changeImage(): void {
    this.showImage = !this.showImage;
  }

  public getEvents(): void {
    this.EventsService.getEvents().subscribe({
      next: (response: Events[]) => {
        this.events = response;
        this.filteredEvents = this.events;
      },
      error: (error) => {
        this.spinner.hide();
        this.toastr.error('An error occurred while loading events', 'Error!');
        console.log(error);
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('The event was successfully deleted', 'Deleted!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  eventDetail(id: number){
    this.router.navigate([`events/detail/${id}`]);
  }


}
