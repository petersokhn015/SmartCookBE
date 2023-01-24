using AutoMapper;
using MediatR;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DTO;
using SmartCook.Application.Mediator.Commands.DBManipulation;
using SmartCook.Application.Mediator.Queries.DBManipulation;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Services
{
    public class PreferencesService : IPreferencesService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PreferencesService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<PreferencesDTO> GetUserPreferences(string email)
        {
            Preferences preferences = await _mediator.Send(new GetUserPreferencesQuery(email));
            if(preferences == null )
            {
                return null;
            }
            return _mapper.Map<PreferencesDTO>(preferences);
        }

        public async Task<bool> ModifyPreferences(PreferencesDTO preferencesDTO, string email)
        {
            Preferences preferences = _mapper.Map<Preferences>(preferencesDTO);
            bool isModifiedSuccess = await _mediator.Send(new ModifyPreferencesCommand(email, preferences));
            return isModifiedSuccess;
        }
    }
}
