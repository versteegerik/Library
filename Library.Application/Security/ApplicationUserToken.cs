﻿using Microsoft.AspNetCore.Identity;
using System;

namespace Library.Application.Security
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
    }
}
