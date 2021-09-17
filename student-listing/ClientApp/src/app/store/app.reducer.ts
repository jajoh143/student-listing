import { createReducer, on } from "@ngrx/store";
import { IStudent } from "../models/student.model";
import { ICourse } from "../models/course.model";
import { setCourses, setCurrentPage, setSearchTerm, setStudent, setStudents } from "./app.actions";

export const APP_FEATURE_KEY = "app";

/**
 * AppState
 */
export interface IAppState {
  students: IStudent[];
  student: IStudent;
  courses: ICourse[];
  currentPage: string;
  searchTerm: string;
}

export const initialState: IAppState = {
  student: {} as IStudent,
  students: [],
  courses: [],
  currentPage: "students",
  searchTerm: ""
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
  })),
  on(setCurrentPage, (state: IAppState, props) => ({
    ...state,
    currentPage: props.page
  })),
  on(setSearchTerm, (state: IAppState, props) => ({
    ...state,
    searchTerm: state.searchTerm
  }))
);
