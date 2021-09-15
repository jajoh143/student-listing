import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { StoreModule } from '@ngrx/store';
import { StudentListComponent } from './student-list/student-list.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CommonModule } from '@angular/common';
import { studentReducer } from './store/student/student.reducer';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent,
    SearchBarComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      {
        path: "",
        component: StudentListComponent
      },
      {
        path: "/students",
        component: StudentListComponent
      },
      {
        path: "/courseS",
        component: CourseListComponent
      }
    ]),
    StoreModule.forRoot({ students: studentReducer })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
