import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TokenStorageService } from '../../services/token-storage';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-add-post',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink],
  templateUrl: './add-post.html'
})
export class AddPost {
  form: any = {
    title: '',
    body: ''
  };

  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorageService,
    public authService: AuthService,
    private router: Router
  ) { }

  onSubmit(): void {
    const token = this.tokenStorage.getToken();

    // The backend [Authorize] attribute requires this Bearer token
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    // Sending the form data to the PostController
    this.http.post("https://localhost:7034/api/Post/add", this.form, { headers, responseType: 'text' })
      .subscribe({
        next: () => {
          // Redirect back to home to see the new post
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.error("Submission failed", err);
          alert("Could not save post. Ensure you are still logged in.");
        }
      });
  }
}