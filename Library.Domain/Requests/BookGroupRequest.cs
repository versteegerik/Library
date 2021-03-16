using Library.Common.Properties;
using Library.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Requests
{
    public abstract class BookGroupRequest
    {
        [Display(Name = nameof(Resources.BookGroup_Name), ResourceType = typeof(Resources))]
        public string Name { get; set; }
    }

    public class SearchBookGroupRequest : BookGroupRequest
    {
        [Display(Name = nameof(Resources.SearchBookGroupRequest_Author), ResourceType = typeof(Resources))]
        public string Author { get; set; }
        [Display(Name = nameof(Resources.Book_Title), ResourceType = typeof(Resources))]
        public string Title { get; set; }
    }

    public class CreateBookGroupRequest : BookGroupRequest { }

    public class UpdateBookGroupRequest : BookGroupRequest
    {
        public Guid BookGroupId { get; set; }

        public UpdateBookGroupRequest(BookGroup bookGroup) {
            BookGroupId = bookGroup.Id;
            Name = bookGroup.Name;
        }
    }
}
