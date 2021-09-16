import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGetCourseResult } from './models/get-course-result';

@Injectable({ providedIn: "root" })
export class CourseService {
  constructor(private http: HttpClient) { }

  /**
   * Retrieves a list of all courses
   */
  getCourses(): Observable<IGetCourseResult> {
    return this.http.get<IGetCourseResult>("/api/course");
  }

  /**
   * Retireves a list of courses filtered by the student id provided
   * @param id - student id
   */
  getStudentCourseList(id: number): Observable<IGetCourseResult> {
    return this.http.get<IGetCourseResult>(`/api/course?studentId=${id}`);
  }
}
