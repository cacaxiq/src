using AutoMapper;
using AutoMapper.QueryableExtensions;
using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Domain.Commands;
using Base.Domain.Commands.Prospect;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using MediatR;
using System;
using System.Collections.Generic;

namespace Base.Application.Services
{
    public class ProspectAppService : IProspectAppService
    {
        private readonly IMapper _mapper;
        private readonly IProspectRepository _prospectRepository;
        private readonly IMediatorHandler _bus;
        private readonly IConfigurationProvider _mapperConfigurationProvider;

        public ProspectAppService(
            IMapper mapper,
            IProspectRepository prospectRepository,
            IMediatorHandler bus,
            IConfigurationProvider mapperConfigurationProvider)
        {
            _mapper = mapper;
            _prospectRepository = prospectRepository;
            _bus = bus;
            _mapperConfigurationProvider = mapperConfigurationProvider;
        }

        public IEnumerable<ProspectViewModel> GetAll()
        {
            return _prospectRepository.GetAll().ProjectTo<ProspectViewModel>(_mapperConfigurationProvider);
        }

        public ProspectViewModel GetById(Guid id)
        {
            return _mapper.Map<ProspectViewModel>(_prospectRepository.Get(id));
        }

        public void Create(ProspectViewModel viewModel)
        {
            var command = _mapper.Map<CreateProspectCommand>(viewModel);
            _bus.SendCommand(command);
        }

        public void Update(ProspectViewModel viewModel)
        {
            var updateCommand = _mapper.Map<UpdateProspectCommand>(viewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProspectCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
