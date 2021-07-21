using Microsoft.AspNetCore.Mvc;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public interface IEleveService
    {
        public Task<ActionResult<IEnumerable<Eleve>>> Get();
        public Task<Eleve> Get(string id);
        public Task Update(Eleve eleve);
        public Task<Eleve> Create(Eleve eleve);
        public Task Delete(string id);
    }
}
