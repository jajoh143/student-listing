import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html'
})
export class SearchBarComponent {

  public searchTerm: string = "";

  constructor(private store: Store) { }

  public search(): void {
   
  }
}
