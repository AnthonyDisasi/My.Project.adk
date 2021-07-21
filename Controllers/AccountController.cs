using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My.Project.adk.Models;
using My.Project.adk.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly UserManager<User_pro> userManager;

        public AccountController(IAccountService accountService_,
            UserManager<User_pro> usrMgr)
        {
            accountService = accountService_;
            userManager = usrMgr;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<IEnumerable<User_pro>>> GetUser()
        {
            return await accountService.Get();
        }

        [HttpGet("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<User_pro>> GetUser(string id)
        {
            return await accountService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostClasse(UserModel user_)
        {
            User_pro user = new User_pro
            {
                UserName = user_.Username,
                Email = user_.Email
            };
            await userManager.CreateAsync(user, user_.Password);

            return CreatedAtAction("GetClasse", new { id = user.Id }, user);
        }
    }
}
