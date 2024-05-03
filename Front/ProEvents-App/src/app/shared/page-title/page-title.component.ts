import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-title',
  templateUrl: './page-title.component.html',
  styleUrls: ['./page-title.component.scss']
})
export class PageTitleComponent {
  @Input() title: string | undefined;
  @Input() subTitle: string = "since 2024";
  @Input() iconClass: string = 'fa fa-user';
  @Input() btnList: boolean = false;

  ngOnInit(): void {}

  /**
   *
   */
  constructor(private router: Router) {
  }
  list(): void{
    this.router.navigate([`/${this.title?.toLocaleLowerCase()}/list`])
  }
}