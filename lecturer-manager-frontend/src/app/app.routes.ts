import { Routes } from '@angular/router';
import { CoursesList } from './features/courses/courses-list/courses-list';
import { AddCourse } from './features/courses/add-course/add-course';

export const routes: Routes = [
  { path: 'courses', component: CoursesList },
  { path: 'courses/add', component: AddCourse },
  { path: '**', redirectTo: 'courses' },
];
