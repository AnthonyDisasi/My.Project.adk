using Microsoft.AspNetCore.Identity;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator<User_pro>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<User_pro> manager, User_pro user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            List<IdentityError> errors = result.Succeeded ?
            new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Le mot de passe  ne peut contenir l'identifiant"
                });
            }

            if (password.Contains("12345"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Le mot de passe ne peut contenir des chiffres numeriques"
                });
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
