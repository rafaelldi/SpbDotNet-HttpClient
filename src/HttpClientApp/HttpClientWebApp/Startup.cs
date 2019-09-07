using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;

namespace HttpClientWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //using Named client
            services.AddHttpClient("some-site", c =>
                {
                    c.BaseAddress = new Uri("https://some-site.com");
                    c.DefaultRequestHeaders.Add("Accept", "application/json");
                })
                .AddHttpMessageHandler<SomeHandler>()
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddTransientHttpErrorPolicy(p => p.CircuitBreaker(5, TimeSpan.FromSeconds(5)))
                .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            //using Typed client
            services.AddHttpClient<SomeSiteClient>();

            //using Refit
            services.AddRefitClient<ISomeSiteApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://some-site.com"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
        }
    }
}