import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SimpleModalService } from 'ngx-simple-modal';
import { CourseService } from '../services/course/course.service';
import { setCourses } from '../store/app.actions';
import { getCourses } from '../store/app.selectors';
import { ICourse } from '../models/course.model';
import { CourseModalComponent } from './course-modal/course-modal.component';
import { AppState } from '../store';
import { IGetCourseResult } from '../services/course/models/get-course-result';

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
    this.service.getCourses().subscribe((result: IGetCourseResult) => {
      this.store.dispatch(setCourses({ courses: result.courseCollection }));
    })
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
          this.service.getCourses();
        }
      });
  }
}
