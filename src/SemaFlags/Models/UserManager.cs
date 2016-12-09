using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace SemaFlags.Models
{
    //public class UserManager : UserManager<User>
    //{
    //    public UserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    //    {
            
    //    }

    //    public virtual int GetUserId(ClaimsPrincipal principal) {
    //        if (principal == null)
    //        {
    //            throw new ArgumentNullException(nameof(principal));
    //        }
    //        return principal.FindFirstValue(Options.ClaimsIdentity.UserIdClaimType);
    //    }
    //}
}
