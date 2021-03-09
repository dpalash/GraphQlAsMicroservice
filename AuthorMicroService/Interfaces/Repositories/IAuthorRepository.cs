using System.Collections.Generic;
using AuthorMicroService.DTOs;

namespace AuthorMicroService.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Author CreateAuthor(Author author);
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
    }
}