import { Component } from '@angular/core';
import { Post } from '../models/post.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list-posts',
  imports: [],
  templateUrl: './list-posts.html',
  styleUrl: './list-posts.css'
})
export class ListPosts {

  constructor(private http: HttpClient) { }

  posts?: Post[] = [];

  ngOnInit(): void {
    this.initData();
  }

  initData(): void {
    this.http.get<Post[]>('https://localhost:7161/api/post')
      .subscribe({
        next: (data: Post[]) => {
          this.posts = data;
          console.log(this.posts);
        }
      });
  }

}
