using BlazorVideoClient.Client.Contracts;
using BlazorVideoClient.Client.Mapings.Map;
using BlazorVideoClient.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("BlazorVideoClient.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorVideoClient.ServerAPI"));

            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IVideoService, VideoService>();

            builder.Services.AddAutoMapper(typeof(Map));

            await builder.Build().RunAsync();
        }
    }
}
