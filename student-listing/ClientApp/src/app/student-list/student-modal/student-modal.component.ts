import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { CourseService } from '../../services/course/course.service';
import { ICourse } from '../../models/course.model';
import { IRegistration } from '../../models/registration.model';
import { IStudent } from '../../models/student.model';
import { GradeService } from '../../services/grade/grade.service';
import { IGrade } from '../../models/grade.model';
import { IGetGradeResult } from '../../services/grade/models/get-grade-result';
import { RegistrationService } from '../../services/registration/registration.service';
import { IGetCourseResult } from '../../services/course/models/get-course-result.model';
import { IDeleteStudentRegistratioResult } from '../../services/registration/models/delete-student-registration-result.model';
import { StudentService } from '../../services/student/student.service';
import { ICreateStudentParams } from '../../services/student/models/create-student-params.model';
import { ICreateStudentResult } from '../../services/student/models/create-student-result.model';
import { IUpdateStudentParams } from '../../services/student/models/update-student-params.model';
import { IUpdateStudentResult } from '../../services/student/models/update-student-result.model';
import { ICreateStudentRegistrationParams } from '../../services/registration/models/create-student-registration-params.model';
import { ICreateStudentRegistrationResult } from '../../services/registration/models/create-student-registration-result.model';
import { IUpdateStudentRegistrationParams } from '../../services/registration/models/update-student-registration-param.model';
import { IUpdateStudentRegistrationResult } from '../../services/registration/models/update-student-registration-result.model';

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
  public studentRegistrationsViewModel: IStudentRegistrationModalViewModel[] = [];
  public courses: ICourse[] = [];
  public grades: IGrade[] = [];
  public selectedCourseId: number = 0;
  public showEditGrade: boolean = false;
  public showStudentCourses: boolean = false;
  public modalContentClassString: string = "modal-content heightFixed480";

  /**
   * Ctor
   * @param registrationService - registration service
   * @param courseService - course service
   * @param gradeService - grade service
   * @param studentService - student service
   */
  constructor(private registrationService: RegistrationService, public courseService: CourseService, private gradeService: GradeService, private studentService: StudentService) {
    super();
  }

  /**
   * OnInit - sets a list of courses available to add for the student
   */
  public ngOnInit(): void {
    if (typeof (this.student.studentId) === "number" && this.student.studentId > 0) {
      this.showStudentCourses = true;
      this.modalContentClassString = "modal-content heightFixed790";

      this.courseService.getStudentCourseList(this.student.studentId).subscribe((result: IGetCourseResult) => {
        this.courses = result.courseCollection;
      });

      this.gradeService.getGrades().subscribe((result: IGetGradeResult) => {
        this.grades = result.gradeCollection;
      });

      if (typeof (this.student.registrationCollection) === "object" && this.student.registrationCollection.length > 0) {
        let studentRegistrations: IStudentRegistrationModalViewModel[] = [];

        for (let index: number = 0; index < this.student.registrationCollection.length; index++) {
          let registration: IStudentRegistrationModalViewModel = {
            position: index,
            showEditGrade: false,
            ...this.student.registrationCollection[index]
          };
          studentRegistrations.push(registration);
        }
        this.studentRegistrationsViewModel = [...studentRegistrations];
      }
    }
  }

  /**
   * Remove a course from a students registration values
   * @param course
   */
  public removeCourse(registration: IRegistration): void {
    this.registrationService.removeRegistration(registration.registrationId).subscribe((result: IDeleteStudentRegistratioResult) => {
      if (result.success) {
        this.studentRegistrationsViewModel = [...this.studentRegistrationsViewModel.filter(reg => reg.courseId !== registration.courseId)];
      }
    });
  }

  /**
   * Adds a course to the student
   */
  public addCourse(): void {
    let oParams: ICreateStudentRegistrationParams = {
      studentId: this.student.studentId,
      courseId: this.selectedCourseId
    };
    this.registrationService.addRegistration(oParams).subscribe((result: ICreateStudentRegistrationResult) => {
      if (result.success) {
        let oStudentRegistrations: IStudentRegistrationModalViewModel[] = this.studentRegistrationsViewModel.length > 0 ? [...this.studentRegistrationsViewModel] : [];
        if (typeof (this.selectedCourseId) === "string") this.selectedCourseId = parseInt(this.selectedCourseId);
        let oSelectedCourse: ICourse = this.courses.find(course => course.courseId === this.selectedCourseId);

        oStudentRegistrations.push({
          courseId: oSelectedCourse.courseId,
          courseName: oSelectedCourse.courseName,
          courseHours: oSelectedCourse.creditHours,
          gradeLetter: 'A',
          position: oStudentRegistrations.length,
          showEditGrade: false
        } as IStudentRegistrationModalViewModel);

        this.courses = [...this.courses.filter(course => course.courseId !== oSelectedCourse.courseId)];
        this.studentRegistrationsViewModel = oStudentRegistrations;
        this.selectedCourseId = 0;
      }
    });
  }

  /**
   * Toggles the ability to edit the grade for a chosen course
   * @param registration
   */
  public toggleShowEditGrade(registration: IStudentRegistrationModalViewModel): void {
    let registrations: IStudentRegistrationModalViewModel[] = [...this.studentRegistrationsViewModel].filter(registrationItem => registrationItem.registrationId !== registration.registrationId);
    registration.showEditGrade = !registration.showEditGrade;
    registrations.splice(registration.position, 0, registration);
    this.studentRegistrationsViewModel = registrations;
  }

  /**
   * Edits the grade for a chosen course registation
   * @param registration
   */
  public editCourseGrade(registration: IStudentRegistrationModalViewModel): void {
    let oParams: IUpdateStudentRegistrationParams = {
      registrationId: registration.registrationId,
      gradeId: registration.gradeId
    };

    this.registrationService.updateRegistration(oParams).subscribe((result: IUpdateStudentRegistrationResult) => {
      if (result.success) {
        if (typeof (registration.gradeId) === "string") registration.gradeId = parseInt(registration.gradeId);
        registration.gradeLetter = this.grades.find(grade => grade.gradeId === registration.gradeId).letter;
        this.toggleShowEditGrade(registration);
      }
    })
  }

  /**
   * Event raised when the Save button is clicked
   */
  confirm() {
    if (typeof (this.student.studentId) === "number" && this.student.studentId > 0) {
      this.updateStudent();
    }
    else {
      this.createStudent();
    }
  }

  /**
   * Updates the student via the student service
   */
  updateStudent(): void {
    let oParams: IUpdateStudentParams = {
      studentId: this.student.studentId,
      firstName: this.student.firstName,
      lastName: this.student.lastName,
      email: this.student.email,
      registrations: []
    }

    this.studentService.updateStudent(oParams).subscribe((result: IUpdateStudentResult) => {
      if (result.success) {
        this.result = true;
        this.close();
      }
    });
  }

  /**
   * creates the student via the student service
   */
  createStudent(): void {
    let oParams: ICreateStudentParams = {
      firstName: this.student.firstName,
      lastName:  this.student.lastName,
      email: this.student.email,
      registrations: []
    };

    this.studentService.createStudent(oParams).subscribe((result: ICreateStudentResult) => {
      if (result.success) {
        this.result = true;
        this.close();
      }
    });
  }
}

/**
 * Used to extends the student registration list items for toggling edit on the grade score of a course
 */
interface IStudentRegistrationModalViewModel extends IRegistration {
  position: number;
  showEditGrade: boolean;
}
