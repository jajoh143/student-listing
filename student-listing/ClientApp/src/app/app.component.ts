import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { IGetStudentsResult } from './student-list/services/models/get-students-result.model';
import { StudentService } from './student-list/services/student.service';
import { setStudents } from './store/app.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(private studentService: StudentService, private store: Store) {
  
  }

  ngOnInit() {
   
  }
}
