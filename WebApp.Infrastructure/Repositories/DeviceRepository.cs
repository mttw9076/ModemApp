using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces;
using WebApp.Infrastructure.Persistance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly WebAppDbContext dbContext;

        public DeviceRepository(WebAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateModem(Modem modem)
        {
            await dbContext.Modems.AddAsync(modem);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateSIMCard(SIMCard simCard)
        {
            await dbContext.SIMCards.AddAsync(simCard);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Modem?> GetModemByRU(string ru)
        {
            return await dbContext.Modems
                .Include(m => m.SIMCard)
                .FirstOrDefaultAsync(m => m.RU == ru);
        }

        public async Task<SIMCard?> GetSIMCardById(int simId)
        {
            return await dbContext.SIMCards
                .Include(s => s.Modem)
                .FirstOrDefaultAsync(s => s.SIMId == simId);
        }
        public async Task<IEnumerable<Modem>> GetAllModemsWithSIMCards()
        {
            return await dbContext.Modems
                .Include(m => m.SIMCard)
                .ToListAsync();
        }


        public async Task UpdateAsync(Modem modem)
        {
            dbContext.Modems.Attach(modem);
            dbContext.Entry(modem).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateModem(Modem modem)
        {
            dbContext.Modems.Update(modem);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdateSIMCard(SIMCard simCard)
        {
            dbContext.SIMCards.Update(simCard);
            await dbContext.SaveChangesAsync();
        }
        public async Task AddSIMCard(SIMCard simCard)
        {
            dbContext.SIMCards.Add(simCard);
            await dbContext.SaveChangesAsync();
        }
        public async Task AddModem(Modem modem)
        {
            dbContext.Modems.Add(modem);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteModemByRU(string ru)
        {
            var modem = await dbContext.Modems.FirstOrDefaultAsync(m => m.RU == ru);
            if (modem != null)
            {
                dbContext.Modems.Remove(modem);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSIMCardById(int simId)
        {
            var simCard = await dbContext.SIMCards.FirstOrDefaultAsync(s => s.SIMId == simId);
            if (simCard != null)
            {
                dbContext.SIMCards.Remove(simCard);
                await dbContext.SaveChangesAsync();
            }
        }


        public async Task<Domain.Entities.Modem?> GetSIMcardByIP(string SerialNumber)
    => await this.dbContext.Modems.FirstOrDefaultAsync(m => m.SerialNumber == SerialNumber);
        public async Task<Domain.Entities.Modem?> GetModemByRUValidation(string RU)
    => await this.dbContext.Modems.FirstOrDefaultAsync(m => m.RU == RU);
        public async Task<Domain.Entities.SIMCard?> GetSIMByUSIM(string USIM)
    => await this.dbContext.SIMCards.FirstOrDefaultAsync(m => m.USIM == USIM);
        public async Task<Domain.Entities.SIMCard?> GetSIMByIP(string IP)
=> await this.dbContext.SIMCards.FirstOrDefaultAsync(m => m.IP == IP);
        public async Task<Domain.Entities.SIMCard?> GetSIMByPhoneNumber(string PhoneNumber)
=> await this.dbContext.SIMCards.FirstOrDefaultAsync(m => m.PhoneNumber == PhoneNumber);

    }
}
