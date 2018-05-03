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
using Base.Domain.Handler;
using Base.ExternalData.Repository.EventSourcing;
using Base.Shared.Domain.Event;
using Base.ExternalData.EventSourcing;

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

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<CreateIntentionCommand>, IntentionHandler>();

            // ExternalData
            services.AddScoped<IIntentionRepository, IntentionRepository>();
            services.AddScoped<IProspectRepository, ProspectRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<BaseContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();
        }
    }
}
