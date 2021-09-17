import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateStudentParams } from './models/create-student-params.model';
import { ICreateStudentResult } from './models/create-student-result.model';
import { IDeleteStudentResult } from './models/delete-student-result.model';
import { IGetStudentResult } from './models/get-student-result.model';
import { IGetStudentsResult } from './models/get-students-result.model';
import { IUpdateStudentParams } from './models/update-student-params.model';
import { IUpdateStudentResult } from './models/update-student-result.model';

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

  /**
   * Updates a student with the provided information
   * @param oParams - provided information
   */
  public updateStudent(oParams: IUpdateStudentParams): Observable<IUpdateStudentResult> {
    return this.http.put<IUpdateStudentResult>("api/student", oParams);
  }

  /**
   * Creates a student with the provided information
   * @param oParams - student info
   */
  public createStudent(oParams: ICreateStudentParams): Observable<ICreateStudentResult> {
    return this.http.post<ICreateStudentResult>("api/student", oParams);
  }

  /**
   * Deletes a student
   * @param studentId - student id
   */
  public deleteStudent(studentId: number): Observable<IDeleteStudentResult> {
    return this.http.delete<IDeleteStudentResult>(`api/student/${studentId}`);
  }
}
