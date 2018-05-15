using AutoMapper;
using AutoMapper.QueryableExtensions;
using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Domain.Commands.User;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using Base.Shared.Domain.Notification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler _bus;
        private readonly IConfigurationProvider _mapperConfigurationProvider;
        private readonly DomainNotificationHandler _notifications;

        public UserAppService(
            IMapper mapper,
            IUserRepository userRepository,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IConfigurationProvider mapperConfigurationProvider)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _bus = bus;
            _mapperConfigurationProvider = mapperConfigurationProvider;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<UserViewModel> Create(UserViewModel viewModel)
        {
            var command = _mapper.Map<CreateUserCommand>(viewModel);
            await _bus.SendCommand(command);

            if (!_notifications.HasNotifications())
                viewModel = _mapper.Map<UserViewModel>(_userRepository.GetByUserID(viewModel.UserID));

            return viewModel;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().ProjectTo<UserViewModel>(_mapperConfigurationProvider);
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.Get(id));
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Update(UserViewModel viewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(viewModel);
            _bus.SendCommand(updateCommand);
        }

        public UserViewModel GetByUserID(string userID)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetByUserID(userID));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
