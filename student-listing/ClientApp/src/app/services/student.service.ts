import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IGetStudentsResult } from './models/get-students-result';

@Injectable({ providedIn: "root" })
export class StudentService {
  constructor(private http: HttpClient) { }

  /**
   * Retrieves a list of all students with their courses listed and a cumulative GPA
   */
  getStudents(): Observable<IGetStudentsResult> {
    return this.http.get<IGetStudentsResult>("/api/student");
  }
}