import { ChangeDetectionStrategy, Component, inject, input, signal } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { Client, CreateAssignmentRequest } from '../../../api/api';

@Component({
  selector: 'app-add-assignment',
  imports: [FormsModule, RouterLink],
  templateUrl: './add-assignment.html',
  styleUrl: './add-assignment.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddAssignment {
  private readonly client = inject(Client);
  private readonly router = inject(Router);

  readonly courseId = input.required<string>();

  protected name = signal('');
  protected isSaving = signal(false);
  protected errorMessage = signal<string | null>(null);

  async onSubmit() {
    if (!this.name().trim()) return;
    this.isSaving.set(true);
    this.errorMessage.set(null);
    try {
      await firstValueFrom(this.client.createAssignment(this.courseId(), new CreateAssignmentRequest({ name: this.name() })));
      await this.router.navigate(['/courses', this.courseId()]);
    } catch {
      this.errorMessage.set('Nie udało się dodać zadania. Spróbuj ponownie.');
    } finally {
      this.isSaving.set(false);
    }
  }
}
