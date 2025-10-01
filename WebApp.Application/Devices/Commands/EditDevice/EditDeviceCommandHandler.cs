using AutoMapper;
using MediatR;
using WebApp.Application.ApplicationUser;
using WebApp.Application.Device.Commands.EditDevice;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces;

public class EditDeviceCommandHandler : IRequestHandler<EditDeviceCommand>
{
    private readonly IDeviceRepository repository;
    private readonly IMapper mapper;
    private readonly IUserContext userContext;

    public EditDeviceCommandHandler(IDeviceRepository repository, IMapper mapper , IUserContext userContext)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.userContext = userContext;
    }


    public async Task<Unit> Handle(EditDeviceCommand request, CancellationToken cancellationToken)
    {
        Modem modem = null;
        SIMCard simCard = null;

        // Edycja modemu
        if (request.Modem?.ModemId > 0)
        {
            modem = await repository.GetModemByRU(request.Modem.RU);
            if (modem == null)
                throw new InvalidOperationException($"Modem o ID '{request.Modem.ModemId}' nie został znaleziony.");

            // Zapamiętaj aktualne ShopID przed mapowaniem
            var currentShopID = modem.ShopID;

            // Mapowanie danych z requestu
            mapper.Map(request.Modem, modem);

            // Jeśli ShopID się zmieniło, zapisz poprzednie
            if (!string.Equals(currentShopID, modem.ShopID, StringComparison.OrdinalIgnoreCase))
            {
                modem.PrevShopID = currentShopID;
            }
            modem.ModifiedAt = DateTime.UtcNow;
            modem.ModifiedById = userContext.GetCurrentUser().UserId;
            await repository.UpdateModem(modem);
        }

        // Obsługa karty SIM
        if (request.SimCard != null)
        {
            if (request.SimCard.SIMId is > 0)
            {
                // Edycja istniejącej karty SIM
                simCard = await repository.GetSIMCardById(request.SimCard.SIMId.Value);
                if (simCard == null)
                    throw new InvalidOperationException($"Karta SIM o ID '{request.SimCard.SIMId}' nie została znaleziona.");

                mapper.Map(request.SimCard, simCard);
                await repository.UpdateSIMCard(simCard);
            }
            else if (request.SimCard.SIMId == 0 && modem != null)
            {
                // Dodanie nowej karty SIM
                simCard = mapper.Map<SIMCard>(request.SimCard);
                simCard.ModemId = modem.ModemId;
                simCard.Modem = modem;
                modem.SIMCard = simCard;

                await repository.AddSIMCard(simCard);
                await repository.UpdateModem(modem);
            }
        }

        // Przypisanie istniejącej karty SIM do modemu (jeśli obie istnieją)
        if (modem != null && simCard != null && simCard.ModemId != modem.ModemId)
        {
            simCard.ModemId = modem.ModemId;
            simCard.Modem = modem;
            modem.SIMCard = simCard;
            modem.ModifiedAt = DateTime.UtcNow;
            modem.ModifiedById = userContext.GetCurrentUser().UserId;
            await repository.UpdateSIMCard(simCard);
            await repository.UpdateModem(modem);
        }

        return Unit.Value;
    }
}
