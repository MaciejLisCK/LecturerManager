import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { JsonPipe } from '@angular/common';
import { Client, CourseDto } from './api/api';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JsonPipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  protected readonly title = signal('lecturer-manager-frontend');

  courses = signal<CourseDto[] | null>(null);

  constructor(private client: Client) {}

  ngOnInit() {
    this.client.getCourses().subscribe(
      (data) => this.courses.set(data),
      (error) => console.error('API error:', error)
    );
  }
}
