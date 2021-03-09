using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AuthorMicroService.Interfaces.Services;
using BlogPostMicroService.DTOs;
using HotChocolate;
using HotChocolate.Types;

namespace AuthorMicroService.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [ExtendObjectType(Name = "Query")]
    public class BlogPostQuery
    {
        public List<BlogPost> GetPostsByAuthorId([Service] IBlogPostService authorService, int id) => authorService.GetPostsByAuthorId(id);

        public List<BlogPost> GetAllPosts([Service] IBlogPostService authorService) => authorService.GetAllPosts();
    }
}
