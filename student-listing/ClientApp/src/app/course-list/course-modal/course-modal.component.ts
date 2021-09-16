import { Component, Input } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { ICourse } from '../../models/course.model';

export interface CourseModalModel {
  title: string;
  course: ICourse;
}

@Component({
  selector: 'app-course-modal',
  templateUrl: './course-modal.component.html',
  styleUrls: ['./course-modal.component.css']
})
export class CourseModalComponent extends SimpleModalComponent<CourseModalModel, boolean> {

  public title: string = "Add Course";
  public course: ICourse = {} as ICourse;

  constructor() {
    super();
  }

  confirm() {
    this.result = true;
    this.close();
  }
}
