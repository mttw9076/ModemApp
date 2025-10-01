using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces
{
    public interface IDeviceRepository
    {
        // Tworzenie
        Task CreateModem(Domain.Entities.Modem modem);
        Task CreateSIMCard(Domain.Entities.SIMCard simCard);

        // Aktualizacja
        Task UpdateAsync(Domain.Entities.Modem modem);
        Task UpdateSIMCard(SIMCard simCard);
        Task UpdateModem(Modem modem);
        // Pobieranie
        Task<Modem?> GetModemByRU(string ru);
        Task<SIMCard?> GetSIMCardById(int simId);
        Task<IEnumerable<Modem>> GetAllModemsWithSIMCards();
        Task AddSIMCard(SIMCard simCard);
        Task AddModem(Modem modem);
        Task DeleteModemByRU(string ru);

        Task DeleteSIMCardById(int simId);
        Task<Modem?> GetSIMcardByIP(string SerialNumber);
        Task<Modem?> GetModemByRUValidation(string RU);
        Task<SIMCard?> GetSIMByUSIM(string USIM);
        Task<SIMCard?> GetSIMByIP(string IP);
        Task<SIMCard?> GetSIMByPhoneNumber(string PhoneNumber);
    }
}
