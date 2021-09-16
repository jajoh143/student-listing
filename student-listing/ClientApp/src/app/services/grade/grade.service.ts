import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGetGradeResult } from './models/get-grade-result';

/**
 * GradeService
 */
@Injectable({ providedIn: "root" })
export class GradeService {
  constructor(private http: HttpClient) { }

  /**
   * Retrieves a list of all students with their courses listed and a cumulative GPA
   */
  public getGrades(): Observable<IGetGradeResult> {
    return this.http.get<IGetGradeResult>("api/grade");
  }
}
