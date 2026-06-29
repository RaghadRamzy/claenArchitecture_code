
using Employee.Infrastructure.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Repository
{
    public class GenericRepository<T> where T : class
    {

        private readonly EmployeeDbContext Context;

        public GenericRepository(EmployeeDbContext Context)
        {
            this.Context = Context;
        }
        public async Task<int> ADD(T item)
        {
            await Context.Set<T>().AddAsync(item);
            return await Context.SaveChangesAsync();

        }

        public async Task<int> Delete(T item)
        {
            Context.Set<T>().Remove(item);
            return await Context.SaveChangesAsync();

        }

        public async Task<T> get(int? id)
           => await Context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll()
         => await Context.Set<T>().ToListAsync();

        public async Task<int> Update(T item)
        {
            Context.Set<T>().Update(item);
            return await Context.SaveChangesAsync();
        }
    }
}
