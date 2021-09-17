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
import { IDeleteStudentResult } from '../services/student/models/delete-student-result.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html'
})
export class StudentListComponent implements OnInit {

  public studentList: IStudent[] = [];

  /**
   * Ctor
   * @param store
   * @param service
   * @param modalService
   */
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

  /**
   * loads the students into the store
   */
  public ngOnInit(): void {
    this.loadStudents();
  }

  /**
   * refreshes the students in the store
   */
  public loadStudents(): void {
    this.service.getStudents().subscribe((result: IGetStudentsResult) => {
      this.store.dispatch(setStudents({ students: result.studentCollection }));
    });
  }

  /**
   * launches the modal to add a new student
   */
  addStudent(): void {
    this.launchModal({} as IStudent);
  }

  /**
   * launches the modal to edit the provided student
   * @param student - student info
   */
  public editStudent(student: IStudent): void {
    this.service.getStudent(student.studentId).subscribe((result: any) => {
      this.store.dispatch(setStudent({ student: result }))
    });
  }

  /**
   * Deletes a student
   * @param studentId - student id
   */
  public deleteStudent(studentId: number): void {
    this.service.deleteStudent(studentId).subscribe((result: IDeleteStudentResult) => {
      this.loadStudents();
    });
  }

  /**
   * launches the modal
   * @param student
   */
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
