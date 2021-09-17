import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateCourseParams } from './models/create-course-params.model';
import { ICreateCourseResult } from './models/create-course-result.model';
import { IDeleteCourseResult } from './models/delete-course-result.model';
import { IGetCourseResult } from './models/get-course-result.model';
import { IUpdateCourseParams } from './models/update-course-params.model';
import { IUpdateCourseResult } from './models/update-course-result.model';

/**
 * CourseService
 */
@Injectable({ providedIn: "root" })
export class CourseService {
  constructor(private http: HttpClient) { }

  /**
   * Retrieves a list of all courses
   */
  public getCourses(): Observable<IGetCourseResult> {
    return this.http.get<IGetCourseResult>("api/course");
  }

  /**
   * Retireves a list of courses filtered by the student id provided
   * @param id - student id
   */
  public getStudentCourseList(id: number): Observable<IGetCourseResult> {
    return this.http.get<IGetCourseResult>(`api/course?studentId=${id}`);
  }

  /**
   * Updates the provided course
   * @param params - course info
   */
  public updateCourse(params: IUpdateCourseParams): Observable<IUpdateCourseResult> {
    return this.http.put<IUpdateCourseResult>("api/course", params);
  }

  /**
   * Creates a course
   * @param params - course info
   */
  public createCourse(params: ICreateCourseParams): Observable<ICreateCourseResult> {
    return this.http.post<ICreateCourseResult>("api/course", params);
  }

  /**
   * Deletes a course
   * @param params
   */
  public deleteCourse(courseId: number): Observable<IDeleteCourseResult> {
    return this.http.delete<IDeleteCourseResult>(`api/course/${courseId}`);
  }
}
