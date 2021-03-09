using System.Collections.Generic;
using System.Linq;
using BlogPostMicroService.Interfaces.Repositories;
using BlogPostMicroService.DTOs;

namespace BlogPostMicroService.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private static readonly List<BlogPost> Posts = new List<BlogPost>();

        public BlogPostRepository()
        {
            BlogPost csharp = new BlogPost
            {
                Id = 1,
                Title = "Mastering C#",
                Content = "This is a series of articles on C#.",
                AuthorId = 1
            };

            BlogPost me = new BlogPost
            {
                Id = 2,
                Title = "Mastering Mechanical Engineering",
                Content = "This is a series of articles on Mechanical Engineering",
                AuthorId = 2
            };

            if (!Posts.Any())
            {
                Posts.Add(csharp);
                Posts.Add(me);
            }
        }

        public BlogPost CreatePost(string title, string content, int authorId)
        {
            BlogPost blogPost = new BlogPost
            {
                Id = Posts.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1,
                Title = title,
                Content = content,
                AuthorId = authorId
            };

            Posts.Add(blogPost);

            return blogPost;
        }

        public List<BlogPost> GetAllPosts()
        {
            return Posts;
        }

        public List<BlogPost> GetPostsByAuthorId(int authorId)
        {
            return Posts.Where(post => post.AuthorId == authorId).ToList();
        }
    }
}
