using Microsoft.AspNetCore.Identity;
using My.Project.adk.DbFolder;
using My.Project.adk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator<DbProject>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<DbProject> manager, DbProject user, string password)
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
