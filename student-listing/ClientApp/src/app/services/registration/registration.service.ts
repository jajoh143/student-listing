import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateStudentRegistrationParams } from './models/create-student-registration-params.model';
import { ICreateStudentRegistrationResult } from './models/create-student-registration-result.model';
import { IDeleteStudentRegistratioResult } from './models/delete-student-registration-result.model';
import { IUpdateStudentRegistrationParams } from './models/update-student-registration-param.model';
import { IUpdateStudentRegistrationResult } from './models/update-student-registration-result.model';

@Injectable({ providedIn: "root" })
export class RegistrationService {
  constructor(private http: HttpClient) { }

  /**
   * Removes the provided registration for a student
   * @param id
   */
  public removeRegistration(id: number): Observable<IDeleteStudentRegistratioResult> {
    return this.http.delete<IDeleteStudentRegistratioResult>(`api/registration/${id}`);
  }

  /**
   * Adds a new registration course record for the student provided
   * @param params - student and course for registration
   */
  public addRegistration(params: ICreateStudentRegistrationParams): Observable<ICreateStudentRegistrationResult> {
    return this.http.post<ICreateStudentRegistrationResult>(`api/registration`, params);
  }

  /**
   * Updates an existing registration record
   * @param params
   */
  public updateRegistration(params: IUpdateStudentRegistrationParams): Observable<IUpdateStudentRegistrationResult> {
    return this.http.put<IUpdateStudentRegistrationResult>('api/registration', params);
  }
}
