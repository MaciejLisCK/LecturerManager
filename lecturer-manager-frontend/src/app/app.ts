import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { JsonPipe } from '@angular/common';
import { CoursesService } from './services/courses.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JsonPipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  protected readonly title = signal('lecturer-manager-frontend');

  courses = signal<any>(null);

  constructor(private coursesService: CoursesService) {}

  ngOnInit() {
    this.coursesService.getCourses().subscribe(
      (data) => this.courses.set(data),
      (error) => console.error('API error:', error)
    );
  }
}
