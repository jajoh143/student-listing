import { IRegistration } from "./registration.model";

/**
 * IStudent
 */
export interface IStudent {
  studentId: number;
  firstName: string;
  lastName: string;
  email: string;
  courseList: string;
  registrationCollection: IRegistration[];
}
