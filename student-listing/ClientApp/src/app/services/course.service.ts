import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGetCourseResult } from './models/get-course-result';

@Injectable({ providedIn: "root" })
export class CourseService {
  constructor(private http: HttpClient) { }

  /**
   * Retrieves a list of all students with their courses listed and a cumulative GPA
   */
  getStudents(): Observable<IGetCourseResult> {
    return this.http.get<IGetCourseResult>("/api/course");
  }
}
