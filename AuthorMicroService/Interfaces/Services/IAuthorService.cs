using System.Collections.Generic;
using AuthorMicroService.DTOs;

namespace AuthorMicroService.Interfaces.Services
{
    public interface IAuthorService
    {
        Author CreateAuthor(Author author);
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
    }
}