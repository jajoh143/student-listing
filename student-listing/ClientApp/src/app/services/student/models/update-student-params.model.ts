import { IRegistration } from "../../../models/registration.model";

/**
 * IUpdateStudentParams
 */
export interface IUpdateStudentParams {
  studentId: number;
  firstName: string;
  lastName: string;
  email: string;
  registrations: IRegistration[];
}
