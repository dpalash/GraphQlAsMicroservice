using System.Threading.Tasks;
using BlogPostMicroService.Interfaces.Services;
using BlogPostMicroService.DTOs;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

// ReSharper disable ClassNeverInstantiated.Global

namespace BlogPostMicroService.Models
{
    [ExtendObjectType(Name = "Mutation")]
    public class BlogPostMutation
    {
        // ReSharper disable once UnusedMember.Global
        public async Task<BlogPost> CreateBlogPost([Service] IBlogPostService authorService, [Service] ITopicEventSender eventSender, string title, string content, int authorId)
        {
            var createdPost = authorService.CreatePost(title, content, authorId);

            var allPosts = authorService.GetAllPosts();

            await eventSender.SendAsync("BlogPostreated", allPosts);

            return createdPost;
        }
    }
}
