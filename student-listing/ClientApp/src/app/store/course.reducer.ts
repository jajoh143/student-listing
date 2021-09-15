import { createReducer, on } from "@ngrx/store";
import { setCourses } from "./app.actions";
import { ICourse } from "./models/course.model";

export const courseFeatureKey: string = "course";

/**
 * AppState
 */
export interface ICourseState {
  courses: ICourse[];
}

export const initialState: ICourseState = {
  courses: []
};

export const courseReducer = createReducer(
  initialState,
  on(setCourses, (state: ICourseState, props) => ({
    ...state,
    courses: props.courses
  }))
);
