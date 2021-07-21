using Microsoft.AspNetCore.Mvc;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public interface IClasseService
    {
        public Task<ActionResult<IEnumerable<Classe>>> Get();
        public Task<Classe> Get(string id);
        public Task Update(Classe classe);
        public Task<Classe> Create(Classe classe);
        public Task Delete(string id);
    }
}
