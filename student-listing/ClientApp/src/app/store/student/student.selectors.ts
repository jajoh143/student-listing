import { createSelector } from "@ngrx/store";
import { IStudentState } from "./student.reducer";
import { IStudent } from "./models/student.model";

/**
 * retrives the list of students from the store
 */
export const getStudents = createSelector(
  (state: IStudentState) => state.students,
  (students: Array<IStudent>) => students
);
