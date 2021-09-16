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

  constructor(private store: Store<AppState>, private service: CourseService, private modalService: SimpleModalService) {
    this.store.select(getCourses).subscribe((courses: any) => {
      this.courseList = courses;
    });
  }

  public editCourse(course: ICourse): void {
    console.log(course);
    this.modalService.addModal(CourseModalComponent,
      {
        title: "Edit Course",
        course: course
      })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.service.getCourses();
        }
        else {
          console.log("JK");
        }
      });
  }

  public addCourse(): void {
    this.modalService.addModal(CourseModalComponent,
      {
        title: "Add Course",
        course: {} as ICourse
      })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.service.getCourses();
        }
        else {
          console.log("JK");
        }
      });
  }

  public ngOnInit(): void {
    this.service.getCourses().subscribe((result: IGetCourseResult) => {
      this.store.dispatch(setCourses({ courses: result.courseCollection }));
    })
  }
}
