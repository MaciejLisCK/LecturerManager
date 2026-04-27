import { Component, inject, resource } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Client, CourseDto } from '../../../api/api';

@Component({
  selector: 'app-courses-list',
  imports: [],
  templateUrl: './courses-list.html',
  styleUrl: './courses-list.scss',
})
export class CoursesList {
  private readonly client = inject(Client);

  protected coursesResource = resource<CourseDto[], void>({
    loader: () => firstValueFrom(this.client.getCourses()),
  });
}
