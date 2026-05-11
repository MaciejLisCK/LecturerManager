import { ChangeDetectionStrategy, Component, inject, input, resource } from '@angular/core';
import { RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { AssignmentDetailDto, Client, CourseDto } from '../../../api/api';
import { Breadcrumb } from '../../../layout/breadcrumb/breadcrumb';

@Component({
  selector: 'app-assignment-detail',
  imports: [RouterLink, Breadcrumb],
  templateUrl: './assignment-detail.html',
  styleUrl: './assignment-detail.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssignmentDetail {
  private readonly client = inject(Client);

  readonly courseId = input.required<string>();
  readonly assignmentId = input.required<string>();

  protected courseResource = resource<CourseDto, string>({
    params: () => this.courseId(),
    loader: ({ params: id }) => firstValueFrom(this.client.getCourseById(id)),
  });

  protected assignmentResource = resource<AssignmentDetailDto, { courseId: string; assignmentId: string }>({
    params: () => ({ courseId: this.courseId(), assignmentId: this.assignmentId() }),
    loader: ({ params }) => firstValueFrom(this.client.getAssignmentById(params.courseId, params.assignmentId)),
  });

  protected async deleteItem(itemId: string) {
    await firstValueFrom(this.client.deleteAssignmentItem(this.courseId(), this.assignmentId(), itemId));
    this.assignmentResource.reload();
  }
}
