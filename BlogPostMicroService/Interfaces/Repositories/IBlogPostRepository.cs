using System.Collections.Generic;
using BlogPostMicroService.DTOs;

namespace BlogPostMicroService.Interfaces.Repositories
{
    public interface IBlogPostRepository
    {
        BlogPost CreatePost(string title, string content, int authorId);
        List<BlogPost> GetAllPosts();
        List<BlogPost> GetPostsByAuthorId(int authorId);
    }
}