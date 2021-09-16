import { Component, Input, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { getStudent, getStudents } from '../store/app.selectors';
import { IStudent } from '../models/student.model';
import { setStudent, setStudents } from '../store/app.actions';
import { AppState } from '../store';
import { SimpleModalService } from 'ngx-simple-modal';
import { StudentModalComponent } from './student-modal/student-modal.component';
import { GradeService } from '../services/grade/grade.service';
import { StudentService } from '../services/student/student.service';
import { IGetStudentsResult } from '../services/student/models/get-students-result.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html'
})
export class StudentListComponent implements OnInit {

  public studentList: IStudent[] = [];

  constructor(private store: Store<AppState>, private service: StudentService, private modalService: SimpleModalService) {
    this.store.select(getStudents).subscribe((students: IStudent[]) => {
      this.studentList = students;
    });

    this.store.select(getStudent).subscribe((student: IStudent) => {
      if (typeof (student.studentId) === "number" && student.studentId > 0) {
        this.launchModal(student);
      }
    });
  }

  public ngOnInit(): void {
    this.loadStudents();
  }

  public loadStudents(): void {
    this.service.getStudents().subscribe((result: IGetStudentsResult) => {
      this.store.dispatch(setStudents({ students: result.studentCollection }));
    });
  }

  addStudent(): void {
    this.launchModal({} as IStudent);
  }

  public editStudent(student: IStudent): void {
    this.service.getStudent(student.studentId).subscribe((result: any) => {
      this.store.dispatch(setStudent({ student: result }))
    });
  }

  private launchModal(student: IStudent): void {

    let modalTitle: string = student.studentId > 0 ? "Edit Student" : "Add Student";

    this.modalService.addModal(StudentModalComponent,
      {
        title: modalTitle,
        student: student
      })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.loadStudents();
        }
      });
  }
}
