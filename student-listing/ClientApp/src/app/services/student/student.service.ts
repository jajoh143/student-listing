import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGetStudentResult } from './models/get-student-result.model';
import { IGetStudentsResult } from './models/get-students-result.model';

@Injectable({ providedIn: "root" })
export class StudentService {
  constructor(private http: HttpClient) { }

  /**
   * Retrieves a list of all students with their courses listed and a cumulative GPA
   */
  public getStudents(): Observable<IGetStudentsResult> {
    return this.http.get<IGetStudentsResult>("api/student");
  }

  /**
   * Retrieves a student with the provided id 
   * @param id
   */
  public getStudent(id: number): Observable<IGetStudentResult> {
    return this.http.get<IGetStudentResult>(`api/student/${id}`);
  }
}
