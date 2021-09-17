import { Component, Input } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { ICourse } from '../../models/course.model';
import { CourseService } from '../../services/course/course.service';
import { ICreateCourseParams } from '../../services/course/models/create-course-params.model';
import { ICreateCourseResult } from '../../services/course/models/create-course-result.model';
import { IUpdateCourseParams } from '../../services/course/models/update-course-params.model';
import { IUpdateCourseResult } from '../../services/course/models/update-course-result.model';
import { ICreateStudentParams } from '../../services/student/models/create-student-params.model';
import { IUpdateStudentParams } from '../../services/student/models/update-student-params.model';

export interface CourseModalModel {
  title: string;
  course: ICourse;
}

@Component({
  selector: 'app-course-modal',
  templateUrl: './course-modal.component.html',
  styleUrls: ['./course-modal.component.css']
})
export class CourseModalComponent extends SimpleModalComponent<CourseModalModel, boolean> {

  public title: string = "Add Course";
  public course: ICourse = {} as ICourse;

  /**
   * Ctor
   * @param courseService - course service
   */
  constructor(private courseService: CourseService) {
    super();
  }

  /**
  * Event raised when the Save button is clicked
  */
  confirm() {
    if (typeof (this.course.courseId) === "number" && this.course.courseId > 0) {
      this.updateCourse();
    }
    else {
      this.createCourse();
    }
  }

  /**
   * Updates the student via the student service
   */
  updateCourse(): void {
    let oParams: IUpdateCourseParams = {
      courseId: this.course.courseId,
      name: this.course.courseName,
      description: this.course.description,
      creditHours: this.course.creditHours
    };

    this.courseService.updateCourse(oParams).subscribe((result: IUpdateCourseResult) => {
      if (result.success) {
        this.result = true;
        this.close();
      }
    });
  }

  /**
   * creates the student via the student service
   */
  createCourse(): void {
    let oParams: ICreateCourseParams = {
      name: this.course.courseName,
      description: this.course.description,
      creditHours: this.course.creditHours
    };

    this.courseService.createCourse(oParams).subscribe((result: ICreateCourseResult) => {
      if (result.success) {
        this.result = true;
        this.close();
      }
    });
  }
}
