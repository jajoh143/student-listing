import { Component, Input } from '@angular/core';
import { IGetStudentsResult } from '../services/models/get-students-result';
import { IStudent } from '../store/student/models/student.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html'
})
export class CourseListComponent {

  public courseList: [] = [];
}
