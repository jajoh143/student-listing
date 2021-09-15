import { IStudent } from "./models/student.model";
import { ICourse } from "./models/course.model";


export const appFeatureKey = "app";

export interface AppState {
  students: Array<IStudent>;
  courses: Array<ICourse>;
}
