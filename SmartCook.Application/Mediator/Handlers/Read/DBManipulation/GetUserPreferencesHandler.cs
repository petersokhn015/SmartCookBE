using MediatR;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.Mediator.Queries.DBManipulation;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Read.DBManipulation
{
    public class GetUserPreferencesHandler : IRequestHandler<GetUserPreferencesQuery, Preferences>
    {
        private readonly IPreferencesRepository _preferencesRepository;

        public GetUserPreferencesHandler(IPreferencesRepository preferencesRepository)
        {
            _preferencesRepository = preferencesRepository;
        }

        public Task<Preferences> Handle(GetUserPreferencesQuery request, CancellationToken cancellationToken)
        {
            return _preferencesRepository.GetUserPreferences(request.email);
        }
    }
}
