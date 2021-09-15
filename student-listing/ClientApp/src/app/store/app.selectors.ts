import { createSelector } from "@ngrx/store";
import { IAppState } from "./app.reducer";
import { ICourse } from "./models/course.model";
import { IStudent } from "./models/student.model";

/**
 * retrives the list of students from the store
 */
export const getStudents = createSelector(
  (state: IAppState) => state.students,
  (students: Array<IStudent>) => students
);

/**
 * retrieves the list of courses from the store
 */
export const getCourses = createSelector(
  (state: IAppState) => state.courses,
  (courses: Array<ICourse>) => courses
);
