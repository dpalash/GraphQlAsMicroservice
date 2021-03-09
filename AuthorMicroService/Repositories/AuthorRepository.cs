using System.Collections.Generic;
using System.Linq;
using AuthorMicroService.DTOs;
using AuthorMicroService.Interfaces.Repositories;

namespace AuthorMicroService.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private static readonly List<Author> Authors = new List<Author>();

        public AuthorRepository()
        {
            Author author1 = new Author
            {
                Id = 1,
                FirstName = "PALASH",
                LastName = "DEBNATH"
            };

            Author author2 = new Author
            {
                Id = 2,
                FirstName = "PRITAM",
                LastName = "DEBNATH"
            };

            if (!Authors.Any())
            {
                Authors.Add(author1);
                Authors.Add(author2);
            }
        }

        public Author CreateAuthor(Author author)
        {
            var lastAuthor = Authors.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastAuthor != null)
            {
                author.Id = lastAuthor.Id + 1;
                Authors.Add(author);
            }

            return author;
        }

        public List<Author> GetAllAuthors()
        {
            return Authors;
        }

        public Author GetAuthorById(int id)
        {
            return Authors.FirstOrDefault(author => author.Id == id);
        }
    }
}
