using Library.Common.Properties;
using Library.Domain.Requests;
using System.ComponentModel.DataAnnotations;
using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public class Author : BaseEntity
    {
        [Display(Name = nameof(Resources.Author_Initials), ResourceType = typeof(Resources))]
        public virtual string Initials { get; set; }

        [Display(Name = nameof(Resources.Author_FirstNames), ResourceType = typeof(Resources))]
        public virtual string FirstNames { get; set; }

        [Display(Name = nameof(Resources.Author_Prefix), ResourceType = typeof(Resources))]
        public virtual string Prefix { get; set; }

        [Display(Name = nameof(Resources.Author_LastName), ResourceType = typeof(Resources))]
        public virtual string LastName { get; set; }

        public virtual string FullName()
        {
            var fullName = "";
            if (!string.IsNullOrWhiteSpace(Initials))
            {
                fullName += Initials + " ";
            }
            if (!string.IsNullOrWhiteSpace(FirstNames))
            {
                fullName += FirstNames + " ";
            }
            if (!string.IsNullOrWhiteSpace(Prefix))
            {
                fullName += Prefix + " ";
            }
            fullName += LastName;
            return fullName;
        }

        public Author() { }

        public Author(CreateAuthorRequest request) : this()
        {
            HandleAuthorRequest(request);
        }

        public virtual void Update(UpdateAuthorRequest request)
        {
            HandleAuthorRequest(request);
        }

        private void HandleAuthorRequest(AuthorRequest request)
        {
            Initials = request.Initials?.Trim();
            FirstNames = request.FirstNames?.Trim();
            Prefix = request.Prefix?.Trim();
            LastName = request.LastName?.Trim();
        }
    }
}
