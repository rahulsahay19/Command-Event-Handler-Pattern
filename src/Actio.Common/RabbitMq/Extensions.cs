﻿using System.Reflection;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe.Middleware;

namespace Actio.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient busClient,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
          return busClient.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(cfg => cfg.FromQueue(GetQueueName<TCommand>())));
        }

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient busClient,
            IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            return busClient.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(cfg => cfg.FromQueue(GetQueueName<TEvent>())));
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("RabbitMQ");
            section.Bind(options);

            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            //RawRabbit library manage the connection, that's why its singleton
            services.AddSingleton<IBusClient>(_ => client);
        }

        private static string GetQueueName<T>()
        {
            return $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
        }
    }
}
