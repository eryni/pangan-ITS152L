import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register-page.html'
})
export class RegisterPage {
  form: any = { username: '', password: '', firstName: '', lastName: '' };

  constructor(private http: HttpClient, private router: Router) { }

  onSubmit(): void {
    this.http.post("https://localhost:7034/api/Login/register", this.form, { responseType: 'text' }).subscribe(() => {
      this.router.navigate(['/login']);
    });
  }
}