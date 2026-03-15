import { Post } from './post';

describe('Post', () => {
  it('should be a valid object structure', () => {
    const post: Post = {
      id: 1,
      title: 'Test',
      body: 'Test Body',
      dateCreated: new Date(),
      userName: 'user1',
      firstName: 'John',
      lastName: 'Doe'
    };
    expect(post).toBeTruthy();
  });
});