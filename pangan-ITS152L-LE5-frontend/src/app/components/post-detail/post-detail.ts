import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Post } from '../../models/post';
import { CommonModule, DatePipe } from '@angular/common';

@Component({
  selector: 'app-post-detail',
  standalone: true,
  imports: [CommonModule, DatePipe, RouterLink],
  templateUrl: './post-detail.html'
})
export class PostDetail implements OnInit {
  post?: Post;

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.http.get<Post>(`https://localhost:7034/api/post/${id}`).subscribe(data => {
      this.post = data;
    });
  }
}