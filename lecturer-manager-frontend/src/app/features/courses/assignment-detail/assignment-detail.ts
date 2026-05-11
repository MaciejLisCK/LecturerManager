import { ChangeDetectionStrategy, Component, inject, input, resource } from '@angular/core';
import { RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { AssignmentDetailDto, Client } from '../../../api/api';

@Component({
  selector: 'app-assignment-detail',
  imports: [RouterLink],
  templateUrl: './assignment-detail.html',
  styleUrl: './assignment-detail.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AssignmentDetail {
  private readonly client = inject(Client);

  readonly courseId = input.required<string>();
  readonly assignmentId = input.required<string>();

  protected assignmentResource = resource<AssignmentDetailDto, { courseId: string; assignmentId: string }>({
    params: () => ({ courseId: this.courseId(), assignmentId: this.assignmentId() }),
    loader: ({ params }) => firstValueFrom(this.client.getAssignmentById(params.courseId, params.assignmentId)),
  });

  protected async deleteItem(itemId: string) {
    await firstValueFrom(this.client.deleteAssignmentItem(this.courseId(), this.assignmentId(), itemId));
    this.assignmentResource.reload();
  }
}
