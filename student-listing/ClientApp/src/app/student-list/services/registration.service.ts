import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateStudentRegistrationParam } from './models/create-student-registration-param.model';
import { ICreateStudentRegistrationResult } from './models/create-student-registration-result.model';
import { IDeleteStudentRegistratioResult } from './models/delete-student-registration-result.model';

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

  public addRegistration(params: ICreateStudentRegistrationParam): Observable<ICreateStudentRegistrationResult> {
    return this.http.post<ICreateStudentRegistrationResult>(`api/registration`, params);
  }
}
