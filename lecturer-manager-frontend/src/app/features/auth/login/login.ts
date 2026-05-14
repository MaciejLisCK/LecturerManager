import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { ApiException, Client, LoginStudentCommand } from '../../../api/api';
import { AuthService } from '../../../core/auth/auth.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Login {
  private readonly client = inject(Client);
  private readonly router = inject(Router);
  private readonly authService = inject(AuthService);

  protected login = signal('');
  protected password = signal('');
  protected isSaving = signal(false);
  protected errorMessage = signal<string | null>(null);

  async onSubmit() {
    if (!this.login().trim() || !this.password().trim()) return;

    this.isSaving.set(true);
    this.errorMessage.set(null);

    try {
      const response = await firstValueFrom(
        this.client.loginStudent(new LoginStudentCommand({
          login: this.login(),
          password: this.password(),
        }))
      );

      this.authService.login(response.accessToken);

      await this.router.navigate(['/courses']);
    } catch (err: unknown) {
      if (err instanceof ApiException && err.status === 401) {
        this.errorMessage.set('Nieprawidłowy login lub hasło.');
      } else {
        this.errorMessage.set('Logowanie nie powiodło się. Spróbuj ponownie.');
      }
    } finally {
      this.isSaving.set(false);
    }
  }
}