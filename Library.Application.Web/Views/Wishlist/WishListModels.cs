using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Web.Views.Wishlist
{
    public class WishListViewModel
    {
        public IEnumerable<WishViewModel> Wishlist { get; set; }
    }

    public class WishViewModel
    {
        public Guid Id { get; set; }
    }
}
