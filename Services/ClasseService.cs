using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.DataContext;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public class ClasseService : IClasseService
    {
        private readonly ProjectDbContext _context;

        public ClasseService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<Classe> Create(Classe classe)
        {
            _context.Classes.Add(classe);
            await _context.SaveChangesAsync();
            return classe;
        }

        public async Task Delete(string id)
        {
            var classe = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Classe>>> Get()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Classe> Get(string id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task Update(Classe classe)
        {
            _context.Entry(classe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
