import { Routes } from '@angular/router';
import { CoursesList } from './features/courses/courses-list/courses-list';

export const routes: Routes = [
  { path: 'courses', component: CoursesList },
  { path: 'courses/add', children: [] },
  { path: '**', redirectTo: 'courses' },
];
