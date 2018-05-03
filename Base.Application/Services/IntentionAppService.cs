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

namespace Base.Application.Services
{
    public class IntentionAppService : IIntentionAppService
    {
        private readonly IMapper _mapper;
        private readonly IIntentionRepository _intentionRepository;
        private readonly IMediatorHandler _bus;

        public IntentionAppService(IMapper mapper, IIntentionRepository intentionRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _intentionRepository = intentionRepository;
            _bus = bus;
        }

        public IEnumerable<IntentionViewModel> GetAll()
        {
            return _intentionRepository.GetAll().ProjectTo<IntentionViewModel>();
        }

        public IntentionViewModel GetById(Guid id)
        {
            return _mapper.Map<IntentionViewModel>(_intentionRepository.Get(id));
        }

        public void Create(IntentionViewModel intentionViewModel)
        {
            var command = _mapper.Map<CreateIntentionCommand>(intentionViewModel);
            _bus.SendCommand(command);
        }

        //public void Update(IntentionViewModel customerViewModel)
        //{
        //    var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
        //    Bus.SendCommand(updateCommand);
        //}

        //public void Remove(Guid id)
        //{
        //    var removeCommand = new RemoveCustomerCommand(id);
        //    Bus.SendCommand(removeCommand);
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
