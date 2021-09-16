import { IRegistration } from "../../../models/registration.model";
import { IStudent } from "../../../models/student.model";

/**
 * IGetStudentResult
 */
export interface IGetStudentResult extends IStudent {
  registrationCollection: IRegistration[];
}
