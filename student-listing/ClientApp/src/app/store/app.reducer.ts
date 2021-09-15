import { createReducer, on } from "@ngrx/store";
import { IStudent } from "./models/student.model";
import { ICourse } from "./models/course.model";
import { setCourses, setStudents } from "./app.actions";

export const studentFeatureKey: string = "student";

/**
 * AppState
 */
export interface IAppState {
  students: IStudent[];
  courses: ICourse[];
}

export const initialState: IAppState = {
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
  }))
);
