using AutoMapper;
using AutoMapper.QueryableExtensions;
using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Domain.Commands;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Application.Services
{
    public class IntentionAppService : IIntentionAppService
    {
        private readonly IMapper _mapper;
        private readonly IIntentionRepository _intentionRepository;
        private readonly IMediatorHandler _bus;
        private readonly IConfigurationProvider _mapperConfigurationProvider;

        public IntentionAppService(IMapper mapper, IIntentionRepository intentionRepository, IMediatorHandler bus, IConfigurationProvider mapperConfigurationProvider)
        {
            _mapper = mapper;
            _intentionRepository = intentionRepository;
            _bus = bus;
            _mapperConfigurationProvider = mapperConfigurationProvider;
        }

        public IEnumerable<IntentionViewModel> GetAll()
        {
            return _intentionRepository.GetAll().ProjectTo<IntentionViewModel>(_mapperConfigurationProvider);
        }

        public IntentionViewModel GetById(Guid id)
        {
            return _mapper.Map<IntentionViewModel>(_intentionRepository.Get(id));
        }

        public void Create(IntentionViewModel viewModel)
        {
            var command = _mapper.Map<CreateIntentionCommand>(viewModel);
            _bus.SendCommand(command);
        }

        public void Update(IntentionViewModel viewModel)
        {
            var updateCommand = _mapper.Map<UpdateIntentionCommand>(viewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveIntentionCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<IntentionViewModel> GetAllByProspect(Guid prospectId)
        {
            return _intentionRepository.FindAll(x => x.ProspectId == prospectId).ProjectTo<IntentionViewModel>(_mapperConfigurationProvider);
        }
    }
}
