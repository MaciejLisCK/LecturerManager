import { ChangeDetectionStrategy, Component, inject, resource } from '@angular/core';
import { RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { Client, CourseDto } from '../../../api/api';

@Component({
  selector: 'app-courses-list',
  imports: [RouterLink],
  templateUrl: './courses-list.html',
  styleUrl: './courses-list.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CoursesList {
  private readonly client = inject(Client);

  protected coursesResource = resource<CourseDto[], void>({
    loader: () => firstValueFrom(this.client.getCourses()),
  });

  protected async deleteCourse(id: string) {
    await firstValueFrom(this.client.deleteCourse(id));
    this.coursesResource.reload();
  }
}
