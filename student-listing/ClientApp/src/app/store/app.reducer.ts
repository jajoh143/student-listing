import { Action, createReducer, on } from "@ngrx/store";
import { IStudent } from "../models/student.model";
import { ICourse } from "../models/course.model";
import { setCourses, setStudent, setStudents } from "./app.actions";

export const APP_FEATURE_KEY = "app";

/**
 * AppState
 */
export interface IAppState {
  students: IStudent[];
  student: IStudent;
  courses: ICourse[];
}

export const initialState: IAppState = {
  student: {} as IStudent,
  students: [],
  courses: []
};

export const appReducer = createReducer(
  initialState,
  on(setStudents, (state: IAppState, props) => ({
    ...state,
    students: props.students
  })),
  on(setCourses, (state: IAppState, props) => ({
    ...state,
    courses: props.courses
  })),
  on(setStudent, (state: IAppState, props) => ({
    ...state,
    student: props.student
  }))
);
