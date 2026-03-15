import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule, DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Post } from '../../models/post';

@Component({
  selector: 'app-list-posts',
  standalone: true,
  imports: [CommonModule, DatePipe, RouterLink],
  templateUrl: './list-posts.html'
})
export class ListPosts implements OnInit {
  // Initializing as an empty array to prevent 'undefined' errors in the HTML
  posts: Post[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchPosts();
  }

  // Moving the logic to a dedicated method makes it easier to call again if needed
  fetchPosts(): void {
    this.http.get<Post[]>('https://localhost:7034/api/post').subscribe({
      next: (data) => {
        this.posts = data;
        console.log("Data fetched successfully:", data);
      },
      error: (err) => {
        console.error("Error fetching posts:", err);
      }
    });
  }
}