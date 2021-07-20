using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.DataContext;
using My.Project.adk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Project.adk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<User_pro> userManager;
        private SignInManager<User_pro> signInManager;
        private readonly ProjectDbContext context; 
        private IUserValidator<User_pro> userValidator;
        private IPasswordValidator<User_pro> passwordValidator;
        private IPasswordHasher<User_pro> passwordHasher;

        public AccountController(UserManager<User_pro> userMgr,
        SignInManager<User_pro> signinMgr,
        ProjectDbContext _context,
        IUserValidator<User_pro> userValid,
        IPasswordValidator<User_pro> passValid,
        IPasswordHasher<User_pro> passwordHash)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_pro>>> GetUser()
        {
            return await context.User_Pros.ToListAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<User_pro>> PostUser(User_pro user)
        {
                IdentityResult result = await userManager.CreateAsync(user, user.Password);
                if (result.Succeeded)
                {
                    user = await userManager.FindByEmailAsync(user.Email);
                    context.Add(user);
                    await context.SaveChangesAsync();
                    return user;
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User_pro user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            context.Entry(user).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletUser(string id)
        {
            var user = await context.User_Pros.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.User_Pros.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User_pro>> GetUser(string id)
        {
            var user = await context.User_Pros.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        private bool UserExists(string id)
        {
            return context.User_Pros.Any(u => u.ID == id);
        }
    }
}
