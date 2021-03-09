using System.Collections.Generic;
using BlogPostMicroService.DTOs;

namespace BlogPostMicroService.Interfaces.Services
{
    public interface IBlogPostService
    {
        BlogPost CreatePost(string title, string content, int authorId);
        List<BlogPost> GetAllPosts();
        List<BlogPost> GetPostsByAuthorId(int authorId);
    }
}