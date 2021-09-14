import { createReducer, on } from "@ngrx/store";
import { setStudents } from "./student.actions";
import { IStudent } from "./models/student.model";

/**
 * AppState
 */
export interface IStudentState {
  students: IStudent[];
}

const initialState: IStudentState = {
  students: []
};

export const studentReducer = createReducer(
  initialState,
  on(setStudents, (state: IStudentState, props) => ({
    ...state,
    students: props.students
  }))
);
