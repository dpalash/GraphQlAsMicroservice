using System.Threading.Tasks;
using AuthorMicroService.DTOs;
using AuthorMicroService.Interfaces.Services;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

// ReSharper disable ClassNeverInstantiated.Global

namespace AuthorMicroService.Models
{
    [ExtendObjectType(Name = "Mutation")]
    public class AuthorMutation
    {
        // ReSharper disable once UnusedMember.Global
        public async Task<Author> CreateAuthor([Service] IAuthorService authorService, [Service] ITopicEventSender eventSender, string firstName, string lastName)
        {
            Author author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            var createdAuthor = authorService.CreateAuthor(author);

            var allAuthors = authorService.GetAllAuthors();

            await eventSender.SendAsync("AuthorCreated", allAuthors);

            return createdAuthor;
        }
    }
}
