using WebApp.Infrastructure.Persistance;

namespace WebApp.Infrastructure.Seeders
{
    public class DSLSeeder
    {
        private readonly WebAppDbContext _dbContext;

        public DSLSeeder(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SeedDSL()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.DSLs.Any())
                {
                    var first = new Domain.Entities.DSL()
                    {
                        Id = 1,
                        ShopId = 1,
                        ServiceName = "Internet",
                        ServiceType = "DHCP",
                        IP = "192.168.1.10",
                        Mask = "255.255.255.0",
                        Gateway = "192.168.1.1",
                        DNS1 = "8.8.8.8",
                        DNS2 = "8.8.4.4",
                        Login = "user123",
                        Password = "securepass"
                    };
                    _dbContext.DSLs.Add(first);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Seeder uruchomiony");

                }
            }
        }

    }
}



