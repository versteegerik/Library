using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Common
{
    public class ServiceResult
    {
        public IList<string> Errors  => new List<string>();
        public bool Succeeded => !Errors.Any();

        public ServiceResult(string error)
        {
            Errors.Add(error);
        }

        public ServiceResult(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    Errors.Add(error.Description);
                }
            }
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Result { get; }

        public ServiceResult(string error, T result): base(error)
        {
            Result = result;
        }
        public ServiceResult(IdentityResult identityResult, T result) : base(identityResult)
        {
            Result = result;
        }
    }
}
