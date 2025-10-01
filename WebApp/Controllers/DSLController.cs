using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.DSL.Commands.CreateDSL;
using WebApp.Application.DSL.Commands.EditDSL;
using WebApp.Application.DSL.Queries.GetAllDSL;
using WebApp.Application.DSL.Queries.GetDSLByShopID;
using WebApp.Domain.Interfaces;
using WebApp.Infrastructure.Persistance;

namespace WebApp.Controllers;
[Authorize]
public class DSLController : Controller
{
    private readonly IMediator mediator;
    private readonly IDSLRepository repository;
    private readonly WebAppDbContext dbContext;

    public IMapper Mapper { get; }
    [ActivatorUtilitiesConstructor]
    public DSLController(IMediator mediator, IMapper mapper, IDSLRepository repository, WebAppDbContext dbContext)
    {
        this.mediator = mediator;
        Mapper = mapper;
        this.repository = repository;
        this.dbContext = dbContext;
    }
    public IActionResult Create()
    {
        return View();

    }

    public async Task<IActionResult> Index()
    {
        var dsls = await mediator.Send(new GetAllDSLQuery());
        return View(dsls);
    }

    public async Task<IActionResult> Details(int ShopID)
    {
        var dto = await mediator.Send(new GetDSLByShopIDQuery(ShopID));
        return View(dto);
    }



    [HttpPost]
    public async Task<IActionResult> Create(CreateDSLCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
            await mediator.Send(command);
            return RedirectToAction(nameof(Index));
    }

    
    [HttpPost]
    public async Task<IActionResult> Delete(int shopId)
    {
        var dsl = await dbContext.DSLs.FirstOrDefaultAsync(d => d.ShopId == shopId);
        if (dsl == null)
            return NotFound();

        dbContext.Remove(dsl);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [Route("DSL/Details/{ShopID}/Edit")]
    public async Task<IActionResult> Edit(EditDSLCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("DSL/Details/{ShopID}/Edit")]
    public async Task<IActionResult> Edit(int ShopID)
    {
        var dto = await mediator.Send(new GetDSLByShopIDQuery(ShopID));
        EditDSLCommand model = Mapper.Map<EditDSLCommand>(dto);
        return View(model);
    }
}




