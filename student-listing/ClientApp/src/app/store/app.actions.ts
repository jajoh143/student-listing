import { createAction, props } from "@ngrx/store";
import { ICourse } from "./models/course.model";
import { IStudent } from "./models/student.model";

export const setStudents = createAction(
  '[Student Listing] Set Students',
  props<{ students: IStudent[] }>()
);

export const setCourses = createAction(
  "[Student Listing] Set Courses",
  props<{ courses: ICourse[] }>()
);
