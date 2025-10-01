using AutoMapper;
using FluentValidation;
using MediatR;
using WebApp.Application.ApplicationUser;
using WebApp.Application.DSL.Commands.CreateDSL;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces;

public class CreateDSLCommandHandler : IRequestHandler<CreateDSLCommand>
{
    private readonly IDSLRepository repository;
    private readonly IMapper mapper;
    private readonly IUserContext userContext;
    private readonly IValidator<CreateDSLCommand> validator;

    public CreateDSLCommandHandler(
        IDSLRepository repository,
        IMapper mapper,
        IUserContext userContext,
        IValidator<CreateDSLCommand> validator)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.userContext = userContext;
        this.validator = validator;
    }

    public async Task<Unit> Handle(CreateDSLCommand request, CancellationToken cancellationToken)
    {
        var dsl = mapper.Map<DSL>(request);
        dsl.CreatedById = userContext.GetCurrentUser().UserId;

        await repository.Create(dsl);

        return Unit.Value;
    }
}
