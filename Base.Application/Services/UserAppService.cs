using AutoMapper;
using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Domain.Interface;
using Base.Shared.Domain.Bus;
using System;
using System.Collections.Generic;

namespace Base.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _prospectRepository;
        private readonly IMediatorHandler _bus;
        private readonly IConfigurationProvider _mapperConfigurationProvider;

        public UserAppService(
            IMapper mapper,
            IUserRepository prospectRepository,
            IMediatorHandler bus,
            IConfigurationProvider mapperConfigurationProvider)
        {
            _mapper = mapper;
            _prospectRepository = prospectRepository;
            _bus = bus;
            _mapperConfigurationProvider = mapperConfigurationProvider;
        }

        public void Create(UserViewModel viewModel) { }

        public IEnumerable<UserViewModel> GetAll()
        {
            return new List<UserViewModel>();
        }

        public UserViewModel GetById(Guid id)
        {
            return new UserViewModel();
        }

        public void Remove(Guid id) { }

        public void Update(UserViewModel viewModel) { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public UserViewModel GetByUserID(string userID)
        {
            return new UserViewModel
            {
                AccessKey = "123456",
                UserID = "cacaxiq"
            };
        }
    }
}
