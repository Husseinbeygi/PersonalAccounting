using Crm.FrontEnd.Blazor.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServerUI;

namespace ServerUI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			var services = builder.Services;
			services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			services.AddAntDesign();

			services.AddOidcAuthentication(options =>
			{
				// Configure your authentication provider options here.
				// For more information, see https://aka.ms/blazor-standalone-auth
				builder.Configuration.Bind("Local", options.ProviderOptions);
			});

			Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa-IR");
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");

			services.AddLocalization();

            var host = builder.Build();

            await Culture.SetUserCulture(host);

            await host.RunAsync();
		}
	}
}