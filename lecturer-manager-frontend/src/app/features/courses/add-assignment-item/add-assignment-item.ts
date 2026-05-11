import { ChangeDetectionStrategy, Component, inject, input, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { Client, CreateAssignmentItemRequest, AssignmentItemType } from '../../../api/api';

@Component({
  selector: 'app-add-assignment-item',
  imports: [FormsModule, RouterLink],
  templateUrl: './add-assignment-item.html',
  styleUrl: './add-assignment-item.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddAssignmentItem {
  private readonly client = inject(Client);
  private readonly router = inject(Router);

  readonly courseId = input.required<string>();
  readonly assignmentId = input.required<string>();

  protected readonly AssignmentItemType = AssignmentItemType;
  protected itemType = signal<AssignmentItemType>(AssignmentItemType.Text);
  protected name = signal('');
  protected text = signal('');
  protected imageUrl = signal('');
  protected isSaving = signal(false);
  protected errorMessage = signal<string | null>(null);

  async onSubmit() {
    if (!this.name().trim()) return;
    const type = this.itemType();
    if (type === AssignmentItemType.Text && !this.text().trim()) return;
    if (type === AssignmentItemType.Image && !this.imageUrl().trim()) return;

    this.isSaving.set(true);
    this.errorMessage.set(null);
    try {
      await firstValueFrom(
        this.client.createAssignmentItem(
          this.courseId(),
          this.assignmentId(),
          new CreateAssignmentItemRequest({
            type,
            name: this.name(),
            text: type === AssignmentItemType.Text ? this.text() : undefined,
            imageUrl: type === AssignmentItemType.Image ? this.imageUrl() : undefined,
          }),
        ),
      );
      await this.router.navigate(['/courses', this.courseId(), 'assignments', this.assignmentId()]);
    } catch {
      this.errorMessage.set('Nie udało się dodać elementu. Spróbuj ponownie.');
    } finally {
      this.isSaving.set(false);
    }
  }
}
