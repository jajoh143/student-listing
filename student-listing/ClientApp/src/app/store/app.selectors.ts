import { createFeatureSelector, createSelector } from "@ngrx/store";
import { APP_FEATURE_KEY, IAppState } from "./app.reducer";
import { ICourse } from "../models/course.model";
import { IStudent } from "../models/student.model";
import { AppState } from ".";

export const selectAppState = createFeatureSelector<AppState, IAppState>(APP_FEATURE_KEY);

/**
 * retrives the list of students from the store
 */
export const getStudents = createSelector(
  selectAppState,
  state => state.students
);

/**
 * retrieves the list of courses from the store
 */
export const getCourses = createSelector(
  selectAppState,
  state => state.courses
);

/**
 * retrieves the student object for editing / detail
 */
export const getStudent = createSelector(
  selectAppState,
  state => state.student
);
