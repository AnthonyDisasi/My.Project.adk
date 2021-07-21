using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User_pro> userManager;
        private SignInManager<User_pro> _signInManager;

        public AccountService(UserManager<User_pro> usrMgr,
            SignInManager<User_pro> signInManager)
        {
            userManager = usrMgr;
            _signInManager = signInManager;
        }

        public AccountService(UserManager<User_pro> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<User_pro> Create(UserModel user_)
        {
            User_pro user = new User_pro
            {
                UserName = user_.Username,
                Email = user_.Email
            };
            await userManager.CreateAsync(user, user_.Password);
            return user;
        }

        public async Task Delete(string id)
        {
            User_pro user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
            }
        }

        public async Task<ActionResult<IEnumerable<User_pro>>> Get()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<User_pro> Get(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<User_pro> GetByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<User_pro> GetByUsername(string Username)
        {
            return await userManager.FindByNameAsync(Username);
        }

        public Task Update(string id, UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
