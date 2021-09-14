import { createAction, props } from "@ngrx/store";
import { IStudent } from "./student/models/student.model";

export const setStudents = createAction(
  '[Student Listing] Set Students Success',
  props<{ students: IStudent[] }>()
);
