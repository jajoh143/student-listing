import { IRegistration } from "./registration.model";

/**
 * IStudent
 */
export interface IStudent {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  courseList: string;
  courses: IRegistration[];
}
