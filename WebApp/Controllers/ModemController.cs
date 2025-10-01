using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.Device.Commands.EditDevice;
using WebApp.Application.Devices;
using WebApp.Application.Devices.Commands.CreateModem;
using WebApp.Application.Devices.Commands.CreateSimCard;
using WebApp.Application.Modem.Queries.GetModemByRU;
using WebApp.Application.SIMCard.Queries.GetSIMCardById;
using WebApp.Domain.Interfaces;
using WebApp.Infrastructure.Persistance;

namespace WebApp.Controllers;
[Authorize]
public class ModemController : Controller
{
    private readonly IMediator mediator;
    private readonly WebAppDbContext dbcontext;
    private readonly IDeviceRepository repository;

    public IMapper Mapper { get; }

    public ModemController(IMediator mediator , IMapper mapper ,WebAppDbContext dbcontext , IDeviceRepository repository)
    {
        this.mediator = mediator;
        Mapper = mapper;
        this.dbcontext = dbcontext;
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult CreateModem()
    {
        return View();
    }
    [HttpGet]
    public IActionResult CreateSIMCard()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> CreateModem(CreateModemCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> CreateSIMCard(CreateSimCardCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var modemsWithSim = await dbcontext.Modems
            .Include(m => m.SIMCard)
            .Where(m => m.SIMCard != null)
            .ToListAsync();

        var modemsWithoutSim = await dbcontext.Modems
            .Include(m => m.SIMCard)
            .Where(m => m.SIMCard == null)
            .ToListAsync();

        var simCardsWithoutModem = await dbcontext.SIMCards
            .Where(s => s.ModemId == null)
            .ToListAsync();

        var model = new DeviceIndexViewModel
        {
            ModemsWithSim = modemsWithSim,
            ModemsWithoutSim = modemsWithoutSim,
            SimCardsWithoutModem = simCardsWithoutModem
        };

        return View(model);
    }
        [HttpGet]
        [Route("Device/EditDevice")]
        public async Task<IActionResult> EditDevice(string? ru, int? simCardId)
        {
            if (!string.IsNullOrWhiteSpace(ru))
            {
                var dto = await mediator.Send(new GetModemByRUQuery(ru));
                if (dto == null)
                    return NotFound($"Nie znaleziono modemu o RU: {ru}");

                var model = Mapper.Map<EditDeviceCommand>(dto);
                return View("EditDevice", model);
            }

            if (simCardId.HasValue)
            {
                var dto = await mediator.Send(new GetSIMCardByIdQuery(simCardId.Value));
                if (dto == null)
                    return NotFound($"Nie znaleziono karty SIM o ID: {simCardId}");

                var model = Mapper.Map<EditDeviceCommand>(dto);
                return View("EditDevice", model);
            }

            return BadRequest("Nie podano identyfikatora modemu ani karty SIM.");
        }

        [HttpPost]
        [Route("Device/EditDevice")]
        public async Task<IActionResult> EditDevice(EditDeviceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
 
    [HttpGet]
    public async Task<IActionResult> DetailsCombined(string RU, int simCardID)
    {
        if (string.IsNullOrWhiteSpace(RU) || simCardID <= 0)
            return BadRequest("Brak wymaganych identyfikatorów.");

        var modemResult = await mediator.Send(new GetModemByRUQuery(RU));
        var simResult = await mediator.Send(new GetSIMCardByIdQuery(simCardID));

        if (modemResult?.Modem == null || simResult?.SimCard == null)
            return NotFound("Nie znaleziono modemu lub karty SIM.");

        var viewModel = new DeviceDto
        {
            Modem = modemResult.Modem,
            SimCard = simResult.SimCard
        };

        return View("DetailsCombined", viewModel); // Widok: DetailsCombined.cshtml
    }







    [HttpGet]
    public async Task<IActionResult> DetailsModem(string RU)
    {
        if (string.IsNullOrWhiteSpace(RU))
            return BadRequest("Nie podano identyfikatora RU.");

        var device = await mediator.Send(new GetModemByRUQuery(RU));
        if (device == null || device.Modem == null)
            return NotFound("Nie znaleziono modemu.");

        return View("DetailsModem", device.Modem); // Widok: DetailsModem.cshtml z @model ModemDTO
    }
    [HttpGet]
    public async Task<IActionResult> DetailsSimCard(int simCardID)
    {
        if (simCardID <= 0)
            return BadRequest("Nieprawidłowy identyfikator karty SIM.");

        var device = await mediator.Send(new GetSIMCardByIdQuery(simCardID));
        if (device == null || device.SimCard == null)
            return NotFound("Nie znaleziono karty SIM.");

        return View("DetailsSimCard", device.SimCard); // Widok: DetailsSimCard.cshtml
    }


    [HttpPost]
    public async Task<IActionResult> DisconnectSimFromModem(string ru)
    {
        if (string.IsNullOrWhiteSpace(ru))
            return BadRequest("Nie podano identyfikatora RU.");

        var modem = await dbcontext.Modems
            .Include(m => m.SIMCard)
            .FirstOrDefaultAsync(m => m.RU == ru);

        if (modem == null || modem.SIMCard == null)
            return NotFound("Modem lub karta SIM nie istnieje.");

        modem.SIMCard.ModemId = null;

        await dbcontext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ConnectSimToModem(string ru, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(ru))
            return BadRequest("Nie podano identyfikatora RU.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            return BadRequest("Nie podano numeru telefonu.");

        var allModems = await dbcontext.Modems.ToListAsync();
        var modem = allModems.FirstOrDefault(m => m.RU == ru);

        var allSims = await dbcontext.SIMCards.ToListAsync();
        var simCard = allSims.FirstOrDefault(s => s.PhoneNumber == phoneNumber);


        if (modem == null || simCard == null)
            return NotFound("Modem lub karta SIM nie istnieje.");

        simCard.ModemId = modem.ModemId;

        await dbcontext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteModem(string ru)
    {
        if (string.IsNullOrWhiteSpace(ru))
            return BadRequest("Nie podano identyfikatora RU.");

        var modem = await repository.GetModemByRU(ru);
        if (modem == null)
            return NotFound($"Nie znaleziono modemu o RU: {ru}");

        await repository.DeleteModemByRU(ru);
        return RedirectToAction("Index", "Modem");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteSimCard(int SIMId)
    {
        if (SIMId <= 0)
            return BadRequest("Nieprawidłowy identyfikator karty SIM.");

        var simCard = await repository.GetSIMCardById(SIMId);
        if (simCard == null)
            return NotFound($"Nie znaleziono karty SIM o ID: {SIMId}");

        await repository.DeleteSIMCardById(SIMId);
        return RedirectToAction("Index", "Modem");
    }



}

