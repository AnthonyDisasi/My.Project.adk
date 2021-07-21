using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Project.adk.DataContext;
using My.Project.adk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.Project.adk.Services
{
    public class EcoleService : IEcoleService
    {
        private readonly ProjectDbContext _context;

        public EcoleService(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Ecole> Create(Ecole ecole)
        {
            _context.Ecoles.Add(ecole);
            await _context.SaveChangesAsync();
            return ecole;
        }

        public async Task Delete(string id)
        {
            var ecole = await _context.Ecoles.FindAsync(id);
            _context.Ecoles.Remove(ecole);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Ecole>>> Get()
        {
            return await _context.Ecoles.ToListAsync();
        }

        public async Task<Ecole> Get(string id)
        {
            return await _context.Ecoles.FindAsync(id);
        }

        public async Task Update(Ecole ecole)
        {
            _context.Entry(ecole).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
