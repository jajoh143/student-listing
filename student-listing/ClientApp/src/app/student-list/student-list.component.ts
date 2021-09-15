import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { getStudents } from '../store/app.selectors';
import { IStudent } from '../store/models/student.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html'
})
export class StudentListComponent {

  public studentList: IStudent[] = [];

  constructor(private store: Store) {
    this.store.select(getStudents).subscribe((students:any) => {
      this.studentList = students.students;
    });
  }
}
