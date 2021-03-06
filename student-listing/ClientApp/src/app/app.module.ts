import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { StudentListComponent } from './student-list/student-list.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CourseListComponent } from './course-list/course-list.component';
import { SimpleModalModule } from 'ngx-simple-modal';
import { CourseModalComponent } from './course-list/course-modal/course-modal.component';
import { metaReducers, reducers } from './store';
import { StudentModalComponent } from './student-list/student-modal/student-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent,
    StudentModalComponent,
    SearchBarComponent,
    CourseListComponent,
    CourseModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    SimpleModalModule,
    RouterModule.forRoot([
      {
        path: "",
        component: StudentListComponent
      },
      {
        path: "students",
        component: StudentListComponent
      },
      {
        path: "courses",
        component: CourseListComponent
      }
    ]),
    StoreModule.forRoot(reducers, {
      metaReducers,
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true
      }
    }),
  ],
  entryComponents: [
    CourseModalComponent,
    StudentModalComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
