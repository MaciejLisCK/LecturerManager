import { ChangeDetectionStrategy, Component, inject, input, resource } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { Client, CourseDto } from '../../../api/api';
import { Breadcrumb } from '../../../layout/breadcrumb/breadcrumb';

@Component({
  selector: 'app-course-detail',
  imports: [RouterLink, Breadcrumb],
  templateUrl: './course-detail.html',
  styleUrl: './course-detail.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CourseDetail {
  private readonly client = inject(Client);
  private readonly router = inject(Router);

  readonly courseId = input.required<string>();

  protected courseResource = resource<CourseDto, string>({
    params: () => this.courseId(),
    loader: ({ params: id }) => firstValueFrom(this.client.getCourseById(id)),
  });

  protected navigateToAssignment(assignmentId: string) {
    this.router.navigate(['/courses', this.courseId(), 'assignments', assignmentId]);
  }

  protected async deleteAssignment(assignmentId: string) {
    await firstValueFrom(this.client.deleteAssignment(this.courseId(), assignmentId));
    this.courseResource.reload();
  }
}
