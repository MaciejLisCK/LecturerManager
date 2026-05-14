import { Injectable, computed, signal } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

interface TokenPayload {
  unique_name?: string;
  role?: string;
}

const TOKEN_KEY = 'lecturerManager.accessToken';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly _accessToken = signal<string | null>(localStorage.getItem(TOKEN_KEY));

  readonly currentUser = computed<string | null>(() => {
    const token = this._accessToken();
    if (!token) return null;
    try {
      return jwtDecode<TokenPayload>(token).unique_name?.trim() || null;
    } catch {
      return null;
    }
  });

  login(token: string): void {
    localStorage.setItem(TOKEN_KEY, token);
    this._accessToken.set(token);
  }

  logout(): void {
    localStorage.removeItem(TOKEN_KEY);
    this._accessToken.set(null);
  }

  getToken(): string | null {
    return this._accessToken();
  }
}
