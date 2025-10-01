using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces
{
    public interface IDSLRepository
    {
        Task Create(Domain.Entities.DSL dsl);
        Task<Domain.Entities.DSL?>GetByID(int Id);

        Task<IEnumerable<Domain.Entities.DSL>>GetAll();

        Task<Domain.Entities.DSL?>GetByShopID(int shopID);

        Task UpdateAsync(Domain.Entities.DSL dsl);
        Task AddAsync(DSL newDsl);
        Task DeleteAsync(int id);

    }
}
