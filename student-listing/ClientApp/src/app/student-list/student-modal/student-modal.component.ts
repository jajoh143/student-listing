import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { IStudent } from '../../models/student.model';
import { getStudent } from '../../store/app.selectors';

export interface StudentModalModel {
  title: string;
  student: IStudent;
}

@Component({
  selector: 'app-student-modal',
  templateUrl: './student-modal.component.html',
  styleUrls: ['./student-modal.component.css']
})
export class StudentModalComponent extends SimpleModalComponent<StudentModalModel, boolean> implements OnInit {

  public title: string = "Add Student";
  public student: IStudent = {} as IStudent;

  constructor(private store: Store) {
    super();
  }

  public ngOnInit(): void {
    this.store.select(getStudent).subscribe((student: IStudent) => {
      console.log(student);
      this.student = student;
    });
  }

  confirm() {
    this.result = true;
    this.close();
  }
}
