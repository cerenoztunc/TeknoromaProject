using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjection.CustomValidations
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            string[] noIncludeCharacter = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "ğ", "Ğ" };
            foreach (var item in noIncludeCharacter)
            {
                if (user.UserName[0].ToString() == item)
                {
                    errors.Add(new IdentityError() { Code = "UserNameContainsInvalidFirstCharacter", Description = "Kullanıcı adının ilk harfi 'Ğ' ya da rakam içermemelidir!" });
                }

            }
            if (errors.Count < 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
        }
    }
}
