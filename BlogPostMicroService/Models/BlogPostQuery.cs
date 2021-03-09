using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BlogPostMicroService.Interfaces.Services;
using BlogPostMicroService.DTOs;
using HotChocolate;
using HotChocolate.Types;

namespace BlogPostMicroService.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [ExtendObjectType(Name = "Query")]
    public class BlogPostQuery
    {
        public List<BlogPost> GetPostsByAuthorId([Service] IBlogPostService authorService, int authorId) => authorService.GetPostsByAuthorId(authorId);

        public List<BlogPost> GetAllPosts([Service] IBlogPostService authorService) => authorService.GetAllPosts();
    }
}
