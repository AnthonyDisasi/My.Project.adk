using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.DataContext;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public class EleveService : IEleveService
    {
        private readonly ProjectDbContext _context;

        public EleveService(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Eleve> Create(Eleve eleve)
        {
            _context.Eleves.Add(eleve);
            await _context.SaveChangesAsync();
            return eleve;
        }

        public async Task Delete(string id)
        {
            var eleve = await _context.Eleves.FindAsync(id);
            _context.Eleves.Remove(eleve);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Eleve>>> Get()
        {
            return await _context.Eleves.ToListAsync();
        }

        public async Task<Eleve> Get(string id)
        {
            return await _context.Eleves.FindAsync(id);
        }

        public async Task Update(Eleve eleve)
        {
            _context.Entry(eleve).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
