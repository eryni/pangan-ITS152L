import { Post } from './post.model';

describe('Post', () => {
  it('should create a Post object', () => {
    const post: Post = {} as Post;
    expect(post).toBeTruthy();
  });
});
