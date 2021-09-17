import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SimpleModalService } from 'ngx-simple-modal';
import { CourseService } from '../services/course/course.service';
import { setCourses } from '../store/app.actions';
import { getCourses, getSearchTerm } from '../store/app.selectors';
import { ICourse } from '../models/course.model';
import { CourseModalComponent } from './course-modal/course-modal.component';
import { AppState } from '../store';
import { IGetCourseResult } from '../services/course/models/get-course-result.model';
import { IDeleteCourseResult } from '../services/course/models/delete-course-result.model';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html'
})
export class CourseListComponent implements OnInit {

  public courseList: ICourse[] = [];

  /**
   * Ctor
   * @param store - Redux store for the application
   * @param service - the course service
   * @param modalService - the modal service
   */
  constructor(private store: Store<AppState>, private service: CourseService, private modalService: SimpleModalService) {
    this.store.select(getCourses).subscribe((courses: any) => {
      this.courseList = courses;
    });
  }

  /**
   * OnInit - sets courses for the store
   */
  public ngOnInit(): void {
    this.loadCourses();
  }

  /**
   *  Launches the modal to edit the selected course
   * @param course
   */
  public editCourse(course: ICourse): void {
    this.launchModal(course);
  }

  /**
   * Launches the modal to add a new course
   */
  public addCourse(): void {
    this.launchModal({} as ICourse);
  }

  /**
   * Removes a course from the db and refresh the courses value in the store
   * @param courseId
   */
  public removeCourse(courseId: number): void {
    this.service.deleteCourse(courseId).subscribe((result: IDeleteCourseResult) => {
      this.loadCourses();
    });
  }

  /**
   * Launches the modal
   * @param course
   */
  private launchModal(course: ICourse): void {

    let modalTitle: string = course.courseId > 0 ? "Edit Course" : "Add Course";

    this.modalService.addModal(CourseModalComponent,
      {
        title: modalTitle,
        course
      })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.loadCourses();
        }
      });
  }

  /**
   * Reloads the value of the course list in the store
   */
  public loadCourses(): void {
    this.service.getCourses().subscribe((result: IGetCourseResult) => {
      this.store.dispatch(setCourses({ courses: result.courseCollection }));
    });
  }
}
