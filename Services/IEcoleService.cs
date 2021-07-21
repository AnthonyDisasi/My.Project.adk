using Microsoft.AspNetCore.Mvc;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public interface IEcoleService
    {
        public Task<ActionResult<IEnumerable<Ecole>>> Get();
        public Task<Ecole> Get(string id);
        public Task Update(Ecole ecole);
        public Task<Ecole> Create(Ecole ecole);
        public Task Delete(string id);
    }
}
