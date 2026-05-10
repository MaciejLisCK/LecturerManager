import { Routes } from '@angular/router';
import { CoursesList } from './features/courses/courses-list/courses-list';
import { AddCourse } from './features/courses/add-course/add-course';
import { AddAssignment } from './features/courses/add-assignment/add-assignment';
import { CourseDetail } from './features/courses/course-detail/course-detail';
import { AssignmentDetail } from './features/courses/assignment-detail/assignment-detail';

export const routes: Routes = [
  { path: 'courses', component: CoursesList },
  { path: 'courses/add', component: AddCourse },
  { path: 'courses/:courseId', component: CourseDetail },
  { path: 'courses/:courseId/assignments/add', component: AddAssignment },
  { path: 'courses/:courseId/assignments/:assignmentId', component: AssignmentDetail },
  { path: '**', redirectTo: 'courses' },
];
