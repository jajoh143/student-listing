import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { CourseService } from '../services/course.service';
import { IGetCourseResult } from '../services/models/get-course-result';
import { setCourses } from '../store/app.actions';
import { getCourses } from '../store/app.selectors';
import { ICourse } from '../store/models/course.model';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html'
})
export class CourseListComponent implements OnInit {

  public courseList: ICourse[] = [];

  constructor(private store: Store, private service: CourseService) {
    this.store.select(getCourses).subscribe((courses: any) => {
      console.log(courses);
      this.courseList = courses.courses;
    });
  }

  public ngOnInit(): void {
    this.service.getStudents().subscribe((result: IGetCourseResult) => {
      this.store.dispatch(setCourses({ courses: result.courseCollection }));
    })
  }
}
