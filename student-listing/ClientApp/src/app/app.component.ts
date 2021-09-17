import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { setCurrentPage } from './store/app.actions';
import { IAppState } from './store/app.reducer';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  public constructor(private store: Store<IAppState>) {

  }

  /**
   * sets the current page in the store
   * @param currentPage - current page
   */
  public setCurrentPage(currentPage: string) {
    this.store.dispatch(setCurrentPage({ page: currentPage }));
  }
}
