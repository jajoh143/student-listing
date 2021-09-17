import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { CourseService } from '../services/course/course.service';
import { IGetCourseResult } from '../services/course/models/get-course-result.model';
import { IGetStudentsResult } from '../services/student/models/get-students-result.model';
import { StudentService } from '../services/student/student.service';
import { AppState } from '../store';
import { setCourses, setStudents } from '../store/app.actions';
import { getCurrentPage } from '../store/app.selectors';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html'
})
export class SearchBarComponent implements OnInit {

  public currentPage: string = "";
  public searchTerm: string = "";
  public searchTermPlaceHolderText: string = "Search the students here...";

  constructor(private store: Store<AppState>, private studentService: StudentService, private courseService: CourseService) { }

  public ngOnInit(): void {
    this.store.select(getCurrentPage).subscribe((currentPage: string) => {
      this.searchTermPlaceHolderText = "Search the " + currentPage + " here...";
      this.currentPage = currentPage;
    });
  }

  public search(): void {
    switch (this.currentPage) {
      case ("students"):
        this.studentService.searchStudents(this.searchTerm).subscribe((result: IGetStudentsResult) => {
          this.store.dispatch(setStudents({ students: result.studentCollection }));
        });
        break;
      case ("courses"):
        this.courseService.searchCourses(this.searchTerm).subscribe((result: IGetCourseResult) => {
          this.store.dispatch(setCourses({ courses: result.courseCollection }));
        });
        break;
      default:
        break;
    }
  }
}
