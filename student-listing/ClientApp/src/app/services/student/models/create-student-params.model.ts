import { IRegistration } from "../../../models/registration.model";

/**
 * ICreateStudentParams
 */
export interface ICreateStudentParams {
  firstName: string;
  lastName: string;
  email: string;
  registrations: IRegistration[];
}
