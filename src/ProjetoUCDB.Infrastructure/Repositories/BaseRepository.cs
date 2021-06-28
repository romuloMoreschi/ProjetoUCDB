using System.Linq;
using System.Threading.Tasks;
using ProjetoUCDB.Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoUCDB.Infrastructure.Context;
using ProjetoUCDB.Infrastructure.Interfaces;

namespace ProjetoUCDB.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ProjetoUCDBContext _context;

        public BaseRepository(ProjetoUCDBContext context)
        {
            _context = context;
        }
        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task Remove(long id)
        {
            var obj = await _context.Set<T>()
                                    .Where(x => x.Id == id)
                                    .SingleOrDefaultAsync();
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        public virtual async Task<T> Get(long id)
        {
            return await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .SingleOrDefaultAsync();
        }
        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                    .AsNoTracking()
                                    .ToListAsync();
        }
    }
}
