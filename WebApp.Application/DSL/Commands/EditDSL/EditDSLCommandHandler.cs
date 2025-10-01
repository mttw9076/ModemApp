using AutoMapper;
using MediatR;
using WebApp.Application.ApplicationUser;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.DSL.Commands.EditDSL
{
    public class EditDSLCommandHandler : IRequestHandler<EditDSLCommand>
    {
        private readonly IDSLRepository repository;
        private readonly IUserContext userContext;

        public IMapper Mapper { get; }

        public EditDSLCommandHandler(IDSLRepository repository, IMapper mapper, IUserContext userContext)
        {
            this.repository = repository;
            Mapper = mapper;
            this.userContext = userContext;
        }

        public async Task<Unit> Handle(EditDSLCommand request, CancellationToken cancellationToken)
        {
            var dsl = await repository.GetByID(request.Id);

            if (dsl != null)
            {
                // aktualizacja istniejącego rekordu
                Mapper.Map(request, dsl);
                dsl.ModifiedById = userContext.GetCurrentUser().UserId;
                dsl.ModifiedAt = DateTime.UtcNow;
                await repository.UpdateAsync(dsl);
            }
            else
            {
                // tworzenie nowego rekordu
                var newDsl = Mapper.Map<Domain.Entities.DSL>(request);
                newDsl.ModifiedById = userContext.GetCurrentUser().UserId;
                newDsl.ModifiedAt = DateTime.UtcNow;
                await repository.AddAsync(newDsl);
            }

            return Unit.Value;
        }
    }
}
