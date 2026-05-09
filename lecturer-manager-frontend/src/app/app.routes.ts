import { Routes } from '@angular/router';
import { CoursesList } from './features/courses/courses-list/courses-list';
import { AddCourse } from './features/courses/add-course/add-course';
import { AddAssignment } from './features/courses/add-assignment/add-assignment';

export const routes: Routes = [
  { path: 'courses', component: CoursesList },
  { path: 'courses/add', component: AddCourse },
  { path: 'courses/:courseId/assignments/add', component: AddAssignment },
  { path: '**', redirectTo: 'courses' },
];
