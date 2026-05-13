import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { Client, RegisterStudentCommand } from '../../../api/api';

@Component({
  selector: 'app-register',
  imports: [FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Register {
  private readonly client = inject(Client);
  private readonly router = inject(Router);

  protected login = signal('');
  protected password = signal('');
  protected firstName = signal('');
  protected lastName = signal('');
  protected studentIndex = signal('');
  protected email = signal('');

  protected isSaving = signal(false);
  protected errorMessage = signal<string | null>(null);
  protected successMessage = signal<string | null>(null);

  async onSubmit() {
    this.isSaving.set(true);
    this.errorMessage.set(null);
    this.successMessage.set(null);

    try {
      const publicKey = await this.fetchPublicKey();

      const encryptedFirstName = await this.encryptField(this.firstName(), publicKey);
      const encryptedLastName = await this.encryptField(this.lastName(), publicKey);
      const encryptedStudentIndex = await this.encryptField(this.studentIndex(), publicKey);
      const encryptedEmail = await this.encryptField(this.email(), publicKey);

      await firstValueFrom(
        this.client.registerStudent(new RegisterStudentCommand({
          login: this.login(),
          password: this.password(),
          encryptedFirstName,
          encryptedLastName,
          encryptedStudentIndex,
          encryptedEmail,
        }))
      );

      this.successMessage.set('Rejestracja zakończona sukcesem. Możesz się teraz zalogować.');
    } catch (err: unknown) {
      if (err instanceof Error && err.message) {
        this.errorMessage.set(`Rejestracja nie powiodła się: ${err.message}`);
      } else {
        this.errorMessage.set('Rejestracja nie powiodła się. Spróbuj ponownie.');
      }
    } finally {
      this.isSaving.set(false);
    }
  }

  private async fetchPublicKey(): Promise<CryptoKey> {
    const response = await firstValueFrom(this.client.getPublicKey()) as { publicKey: string };
    const base64 = response.publicKey;
    const binaryDer = Uint8Array.from(atob(base64), c => c.charCodeAt(0));
    return crypto.subtle.importKey(
      'spki',
      binaryDer.buffer,
      { name: 'RSA-OAEP', hash: 'SHA-256' },
      false,
      ['encrypt']
    );
  }

  private async encryptField(value: string, publicKey: CryptoKey): Promise<string> {
    const encoded = new TextEncoder().encode(value);
    const encrypted = await crypto.subtle.encrypt(
      { name: 'RSA-OAEP' },
      publicKey,
      encoded
    );
    return btoa(String.fromCharCode(...new Uint8Array(encrypted)));
  }
}
