import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { IGetStudentsResult } from './services/models/get-students-result';
import { StudentService } from './services/student.service';
import { setStudents } from './store/app.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(private studentService: StudentService, private store: Store) {
  
  }

  ngOnInit() {
    this.studentService.getStudents().subscribe((result: IGetStudentsResult) => {
      this.store.dispatch(setStudents({ students: result.studentCollection }));
    });
  }
}
