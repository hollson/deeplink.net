﻿using Microsoft.Extensions.DependencyInjection;

namespace Deeplink.Helpers
{
    public static class CorsExtension
    {
        public static void AddCustomCors(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}
