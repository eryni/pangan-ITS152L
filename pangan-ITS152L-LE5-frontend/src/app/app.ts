import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, Router } from '@angular/router';
import { AuthService } from './services/auth';
import { TokenStorageService } from './services/token-storage';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, CommonModule],
  templateUrl: './app.html'
})
export class App {
  constructor(
    public auth: AuthService, 
    private tokenStorage: TokenStorageService,
    private router: Router
  ) {}

  goHome() {
    this.router.navigate(['/']).then(() => {
      if (this.router.url === '/') {
        window.location.reload(); 
      }
    });
  }

  // Getter to retrieve the username for the header
  get username(): string {
    return window.sessionStorage.getItem('auth-username') || 'Guest';
  }

  onLogout() {
    this.tokenStorage.signOut();
    window.sessionStorage.removeItem('auth-username'); // Clear username
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}