using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Base.Application.Services;
using Base.Application.Interfaces;
using Base.Domain.Interface;
using Base.ExternalData.Repository;
using Base.ExternalData.Context;
using Base.Application.AutoMapper;
using MediatR;
using Base.Shared.Domain.Notification;
using Base.ExternalData.UoW;
using Base.Shared.Domain.Bus;
using Base.Bus;
using Base.Domain.Commands;
using Base.ExternalData.Repository.EventSourcing;
using Base.Shared.Domain.Event;
using Base.ExternalData.EventSourcing;
using Base.Domain.CommandHandlers;
using Base.Domain.Commands.Prospect;

namespace Base.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IIntentionAppService, IntentionAppService>();
            services.AddScoped<IProspectAppService, ProspectAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<CreateIntentionCommand>, IntentionHandler>();
            services.AddScoped<INotificationHandler<UpdateIntentionCommand>, IntentionHandler>();
            services.AddScoped<INotificationHandler<RemoveIntentionCommand>, IntentionHandler>();
            services.AddScoped<INotificationHandler<CreateProspectCommand>, ProspectHandler>();
            services.AddScoped<INotificationHandler<UpdateProspectCommand>, ProspectHandler>();
            services.AddScoped<INotificationHandler<RemoveProspectCommand>, ProspectHandler>();

            // ExternalData
            services.AddScoped<IIntentionRepository, IntentionRepository>();
            services.AddScoped<IProspectRepository, ProspectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<BaseContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();
        }
    }
}
