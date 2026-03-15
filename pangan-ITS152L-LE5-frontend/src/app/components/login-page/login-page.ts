import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TokenStorageService } from '../../services/token-storage';
import { AuthService } from '../../services/auth';
@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login-page.html'
})
export class LoginPage {
  form: any = { username: '', password: '' };

  constructor(
    private http: HttpClient, 
    private tokenStorage: TokenStorageService, 
    private router: Router,
    private authService: AuthService 
  ) { }

  onSubmit() {
  this.http.post<any>("https://localhost:7034/api/Login/login", this.form).subscribe({
    next: (data) => {
      this.tokenStorage.saveToken(data.id_token);
      this.tokenStorage.saveUser(data.id);
      this.authService.setSession(this.form.username);       
      this.authService.isLoggedIn = true; 
      
      this.router.navigate(['/add-post']); 
    },
    error: (err) => alert("Login failed!")
  });
}
}