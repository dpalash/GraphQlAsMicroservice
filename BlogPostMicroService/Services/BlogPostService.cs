using System.Collections.Generic;
using BlogPostMicroService.Interfaces.Repositories;
using BlogPostMicroService.Interfaces.Services;
using BlogPostMicroService.DTOs;

namespace BlogPostMicroService.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _authorRepository;

        public BlogPostService(IBlogPostRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public BlogPost CreatePost(string title, string content, int authorId)
        {
            return _authorRepository.CreatePost(title, content, authorId);
        }

        public List<BlogPost> GetAllPosts()
        {
            return _authorRepository.GetAllPosts();
        }

        public List<BlogPost> GetPostsByAuthorId(int authorId)
        {
            return _authorRepository.GetPostsByAuthorId(authorId);
        }
    }
}
