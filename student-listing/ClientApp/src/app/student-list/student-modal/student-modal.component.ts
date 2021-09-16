import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { CourseService } from '../../course-list/services/course.service';
import { IGetCourseResult } from '../../course-list/services/models/get-course-result';
import { ICourse } from '../../models/course.model';
import { IRegistration } from '../../models/registration.model';
import { IStudent } from '../../models/student.model';
import { getStudent } from '../../store/app.selectors';
import { ICreateStudentRegistrationParam } from '../services/models/create-student-registration-param.model';
import { ICreateStudentRegistrationResult } from '../services/models/create-student-registration-result.model';
import { IDeleteStudentRegistratioResult } from '../services/models/delete-student-registration-result.model';
import { RegistrationService } from '../services/registration.service';
import { StudentService } from '../services/student.service';

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
  public courses: ICourse[] = [];
  public showCourseAddDropdown: boolean = false;
  public selectedCourseId: number = 0;

  constructor(private studentService: StudentService, private registrationService: RegistrationService, public courseService: CourseService) {
    super();
  }

  public ngOnInit(): void {
    this.courseService.getCourses().subscribe((result: IGetCourseResult) => {
      this.courses = result.courseCollection;
    });
  }

  /**
   * Remove a course from a students registration values
   * @param course
   */
  public removeCourse(registration: IRegistration): void {
    this.registrationService.removeRegistration(registration.id).subscribe((result: IDeleteStudentRegistratioResult) => {
      if (result.success) {
        this.student.registrationCollection = [...this.student.registrationCollection.filter(reg => reg.courseId !== registration.courseId)];
      }
    });
  }

  public toggleShowCourseAddDropdown(): void {
    this.showCourseAddDropdown = !this.showCourseAddDropdown;
  }

  public addCourse(): void {
    let oParams: ICreateStudentRegistrationParam = {
      studentId: this.student.id,
      courseId: this.selectedCourseId
    };
    this.registrationService.addRegistration(oParams).subscribe((result: ICreateStudentRegistrationResult) => {
      let oStudentRegistrations: IRegistration[] = [...this.student.registrationCollection];
      let oSelectedCourse: ICourse = this.courses.find(course => course.courseId === this.selectedCourseId);

      oStudentRegistrations.push({
        courseId: oSelectedCourse.courseId,
        courseName: oSelectedCourse.courseName,
        courseHours: oSelectedCourse.creditHours,
        gradeLetter: 'A'
      } as IRegistration);

      this.student.registrationCollection = oStudentRegistrations;
    });
  }

  confirm() {
    this.result = true;
    this.close();
  }
}
