import { createAction, props } from "@ngrx/store";
import { ICourse } from "../models/course.model";
import { IStudent } from "../models/student.model";

export const setStudents = createAction(
  '[App] Set Students',
  props<{ students: IStudent[] }>()
);

export const setCourses = createAction(
  "[App] Set Courses",
  props<{ courses: ICourse[] }>()
);

export const setStudent = createAction(
  "[App] Set Student",
  props<{ student: IStudent }>()
);

export const setCurrentPage = createAction(
  "[App] Set Current Page",
  props<{ page: string }>()
);

export const setSearchTerm = createAction(
  "[App] Set Search Term",
  props<{ searchTerm: string }>()
);
