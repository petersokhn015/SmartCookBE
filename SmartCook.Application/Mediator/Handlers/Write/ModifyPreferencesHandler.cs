using MediatR;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.Mediator.Commands.DBManipulation;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Write
{
    public class ModifyPreferencesHandler : IRequestHandler<ModifyPreferencesCommand, bool>
    {
        private readonly IPreferencesRepository _preferencesRepository;

        public ModifyPreferencesHandler(IPreferencesRepository preferencesRepository)
        {
            _preferencesRepository = preferencesRepository;
        }

        public Task<bool> Handle(ModifyPreferencesCommand request, CancellationToken cancellationToken)
        {
            return _preferencesRepository.ModifyPreferences(request.userPreferences, request.email);
        }
    }
}
