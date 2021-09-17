import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SimpleModalService } from 'ngx-simple-modal';
import { ICourse } from '../models/course.model';
import { MockStore, provideMockStore } from "@ngrx/store/testing";

import { CourseListComponent } from "./course-list.component";
import { CourseService } from '../services/course/course.service';
import { IGetCourseResult } from '../services/course/models/get-course-result.model';
import { of } from 'rxjs';
import { getCourses } from '../store/app.selectors';

describe('CourseListComponent', () => {
  let component: CourseListComponent;
  let fixture: ComponentFixture<CourseListComponent>;
  let store: MockStore;
  let mockModalService: jasmine.SpyObj<SimpleModalService> = jasmine.createSpyObj<SimpleModalService>(["addModal"]);
  let mockCourseService: jasmine.SpyObj<CourseService> = jasmine.createSpyObj<CourseService>(["getCourses"]);

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CourseListComponent],
      providers: [
        {
          provide: SimpleModalService,
          useValue: mockModalService
        },
        {
          provide: CourseService,
          useValue: mockCourseService
        },
        provideMockStore({
          selectors: [
            {
              selector: getCourses,
              value: []
            }
          ]
        })
      ]
    })
      .compileComponents();
    mockCourseService.getCourses.and.returnValue(of({} as IGetCourseResult));
    mockModalService.addModal.and.returnValue(of(true));
    store = TestBed.get(MockStore);
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it("should launch add modal when editCourse is clicked", () => {
    component.editCourse({} as ICourse);
    expect(mockModalService.addModal).toHaveBeenCalled();
  });

  it("should launch add modal when addCourse is clicked", () => {
    component.addCourse();
    expect(mockModalService.addModal).toHaveBeenCalled();
  });

  it("should display provided rows of courses", () => {
    let courses: ICourse[] = [
      { courseId: 1, courseName: "Test Course", description: "Test Description", creditHours: 4 },
      { courseId: 2, courseName: "Test Course 2", description: "Test Description 2", creditHours: 3 }
    ];
    mockCourseService.getCourses.and.returnValue(of({ courseCollection: courses } as IGetCourseResult));
    store.overrideSelector(getCourses, courses);
    fixture = TestBed.createComponent(CourseListComponent);
    fixture.detectChanges();
    expect(fixture.nativeElement.querySelectorAll("tbody tr").length).toBe(2);
    expect(fixture.nativeElement.querySelector("tbody tr td:nth-child(2)").textContent.trim()).toBe("Test Course");
  });
});
