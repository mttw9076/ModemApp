using WebApp.Domain.Entities;
using WebApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

public class ModemSeeder
{
    private readonly WebAppDbContext _dbContext;

    public ModemSeeder(WebAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedModem()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            if (!await _dbContext.Modems.AnyAsync())
            {
                var simCard = new SIMCard
                {
                    PhoneNumber = "123456789",
                    USIM = "1234556789",
                    PIN = "1234",
                    PUK = "12345678",
                    IP = "10.10.10.10",
                    Op = "plus"
                };

                await _dbContext.SIMCards.AddAsync(simCard);
                await _dbContext.SaveChangesAsync();

                var modem = new Modem
                {
                    Model = "Rut240",
                    SerialNumber = "191919191919",
                    PrevShopID = "1234",
                    ShopID = "5678",
                    RU = "13456789",
                    Place = "kasa 21",
                    Description = "ua",
                    SIMCard = simCard,
                };

                await _dbContext.Modems.AddAsync(modem);
                await _dbContext.SaveChangesAsync();

                Console.WriteLine("Seeder uruchomiony");
            }
        }
    }
}
