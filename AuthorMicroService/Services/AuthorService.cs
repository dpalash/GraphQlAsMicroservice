using System.Collections.Generic;
using AuthorMicroService.DTOs;
using AuthorMicroService.Interfaces.Repositories;
using AuthorMicroService.Interfaces.Services;

namespace AuthorMicroService.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author CreateAuthor(Author author)
        {
            return _authorRepository.CreateAuthor(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }

    }
}
