using Library.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Application.Security
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Person Person { get; set; }
    }
}
