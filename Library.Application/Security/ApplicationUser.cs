using Library.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace Library.Application.Security
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
