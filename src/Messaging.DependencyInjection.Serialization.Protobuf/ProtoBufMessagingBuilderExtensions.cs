﻿using System;
using Messaging.DependencyInjection;
using Microsoft.Extensions.Options;
using Serialization.ProtoBuf;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProtoBufMessagingBuilderExtensions
    {
        public static MessagingBuilder AddProtoBuf(this MessagingBuilder builder)
        {
            builder.AddSerializer<ProtoBufSerializer>();
            builder.Services.AddSingleton(c => c.GetRequiredService<IOptions<ProtoBufOptions>>().Value);
            return builder;
        }

        public static MessagingBuilder AddProtoBuf(this MessagingBuilder builder, Action<ProtoBufOptions> setupAction)
        {
            builder.Services.Configure(setupAction);
            return builder.AddProtoBuf();
        }
    }
}