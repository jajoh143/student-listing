import { createAction, props } from "@ngrx/store";
import { IStudent } from "./models/student.model";

export const setStudents = createAction(
  '[Student Listing] Set Students Success',
  props<{ students: IStudent[] }>()
);
