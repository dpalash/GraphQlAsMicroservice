using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AuthorMicroService.DTOs;
using AuthorMicroService.Interfaces.Services;
using HotChocolate;
using HotChocolate.Types;

namespace AuthorMicroService.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [ExtendObjectType(Name = "Query")]
    public class AuthorQuery
    {
        public List<Author> GetAllAuthors([Service] IAuthorService authorService) => authorService.GetAllAuthors();

        public Author GetAuthorById([Service] IAuthorService authorService, int id) => authorService.GetAuthorById(id);

    }
}
