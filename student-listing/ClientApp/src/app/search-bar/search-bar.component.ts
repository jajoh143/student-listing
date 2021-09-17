import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from '../store';
import { getCurrentPage } from '../store/app.selectors';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html'
})
export class SearchBarComponent implements OnInit {

  public currentPage: string = "";
  public searchTermPlaceHolderText: string = "Search the students here...";

  constructor(private store: Store<AppState>) { }

  public ngOnInit(): void {
    this.store.select(getCurrentPage).subscribe((currentPage: string) => {
      this.searchTermPlaceHolderText = "Search the " + currentPage + " here...";
      this.currentPage = currentPage;
    });
  }

  public search(): void {
  }
}
