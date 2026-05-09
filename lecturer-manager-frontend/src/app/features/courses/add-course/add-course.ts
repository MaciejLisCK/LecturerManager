import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { Client, CreateCourseCommand } from '../../../api/api';

@Component({
  selector: 'app-add-course',
  imports: [FormsModule, RouterLink],
  templateUrl: './add-course.html',
  styleUrl: './add-course.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddCourse {
  private readonly client = inject(Client);
  private readonly router = inject(Router);

  protected name = signal('');
  protected isSaving = signal(false);
  protected errorMessage = signal<string | null>(null);

  async onSubmit() {
    if (!this.name().trim()) return;
    this.isSaving.set(true);
    this.errorMessage.set(null);
    try {
      await firstValueFrom(this.client.createCourse(new CreateCourseCommand({ name: this.name() })));
      await this.router.navigate(['/courses']);
    } catch {
      this.errorMessage.set('Nie udało się dodać kursu. Spróbuj ponownie.');
    } finally {
      this.isSaving.set(false);
    }
  }
}
