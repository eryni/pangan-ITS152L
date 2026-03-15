import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TokenStorageService } from './token-storage';

@Injectable({ providedIn: 'root' })
export class AuthService {
  isLoggedIn: boolean = false;
  currentUser: string | null = null; // Store the username here

  constructor(private http: HttpClient, private tokenStorage: TokenStorageService) {

    const token = this.tokenStorage.getToken();
    this.isLoggedIn = !!token;

    if (this.isLoggedIn) {
      this.currentUser = window.sessionStorage.getItem('auth-username');
    }
  }

  login(username: string, password: string) {
    return this.http.post<any>("https://localhost:7034/api/Login/login", { username, password });
  }

  // Helper to update state after login success
  setSession(username: string) {
    this.isLoggedIn = true;
    this.currentUser = username;
    window.sessionStorage.setItem('auth-username', username);
  }

  logout() {
    this.isLoggedIn = false;
    this.currentUser = null;
    window.sessionStorage.removeItem('auth-username');
  }
}