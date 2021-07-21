using Microsoft.AspNetCore.Mvc;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public interface IAccountService
    {
        public Task<ActionResult<IEnumerable<User_pro>>> Get();
        public Task<User_pro> Get(string id);
        public Task<User_pro> GetByUsername(string Username);
        public Task<User_pro> GetByEmail(string email);
        public Task Update(string id, UserModel user);
        public Task<User_pro> Create(UserModel user);
        public Task Delete(string id);
    }
}
