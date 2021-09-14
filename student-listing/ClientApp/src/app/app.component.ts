import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { StudentService } from './services/student.service';
import { setStudents } from './store/app.actions';
import { IStudent } from './store/student/models/student.model';
import { getStudents } from './store/student/student.selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  public students$ = this.store.pipe(select(getStudents));

  constructor(private studentService: StudentService, private store: Store) {
  
  }

  ngOnInit() {
    this.studentService.getStudents().subscribe((students: IStudent[]) => {
      this.store.dispatch(setStudents({ students }))
    });
  }
}
