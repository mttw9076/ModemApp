using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces;
using WebApp.Infrastructure.Persistance;

namespace WebApp.Infrastructure.Repositories
{
    internal class DSLRepository : IDSLRepository
    {
        private readonly WebAppDbContext dbContext;
        public DSLRepository(WebAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.DSL dsl)
        {
            dbContext.Add(dsl);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task<Domain.Entities.DSL?> GetByID(int Id)
        => await this.dbContext.DSLs.FirstOrDefaultAsync(m => m.Id == Id);

        public async Task<IEnumerable<Domain.Entities.DSL>> GetAll()
            => await this.dbContext.DSLs.ToListAsync();
        public async Task<Domain.Entities.DSL?> GetByShopID(int shopID)
            => await this.dbContext.DSLs.FirstOrDefaultAsync(m => m.ShopId == shopID);

        public async Task UpdateAsync(Domain.Entities.DSL dsl)
        {
            dbContext.Entry(dsl).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        public async Task AddAsync(DSL newDsl)
        {
            if (newDsl == null)
                throw new ArgumentNullException(nameof(newDsl));

            await dbContext.DSLs.AddAsync(newDsl);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var dsl = await GetByID(id);
            if (dsl != null)
            {
                dbContext.DSLs.Remove(dsl);
                await dbContext.SaveChangesAsync();
            }

        }        
    }
}