import { createReducer, on } from "@ngrx/store";
import { setStudents } from "./app.actions";
import { IStudent } from "./models/student.model";

export const studentFeatureKey: string = "student";

/**
 * AppState
 */
export interface IStudentState {
  students: IStudent[];
}

export const initialState: IStudentState = {
  students: []
};

export const studentReducer = createReducer(
  initialState,
  on(setStudents, (state: IStudentState, props) => ({
    ...state,
    students: props.students
  }))
);
