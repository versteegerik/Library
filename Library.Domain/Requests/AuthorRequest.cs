using Library.Common.Properties;
using Library.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Requests
{
    public abstract class AuthorRequest
    {
        [Display(Name = nameof(Resources.Author_Initials), ResourceType = typeof(Resources))]
        public virtual string Initials { get; set; }

        [Display(Name = nameof(Resources.Author_FirstNames), ResourceType = typeof(Resources))]
        public virtual string FirstNames { get; set; }

        [Display(Name = nameof(Resources.Author_Prefix), ResourceType = typeof(Resources))]
        public virtual string Prefix { get; set; }

        [Display(Name = nameof(Resources.Author_LastName), ResourceType = typeof(Resources))]
        public virtual string LastName { get; set; }

        public AuthorRequest() { }
    }

    public class CreateAuthorRequest : AuthorRequest { }

    public class UpdateAuthorRequest : AuthorRequest
    {
        public Guid Id { get; set; }

        public UpdateAuthorRequest(Author author)
        {
            Id = author.Id;
            Initials = author.Initials;
            FirstNames = author.FirstNames;
            Prefix = author.Prefix;
            LastName = author.LastName;
        }
    }

    public class AuthorDropDownRequest
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public AuthorDropDownRequest() { }
        public AuthorDropDownRequest(Author author) : this()
        {
            Id = author.Id;
            FullName = author.FullName();
        }
    }
}
