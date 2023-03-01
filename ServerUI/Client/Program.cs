using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServerUI.Infrastructure;

namespace ServerUI.Client
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

			ServiceBootstrapper.Register(services);

			services.AddSingleton
				(current => new HttpClient
				{
					BaseAddress =
						new Uri("https://localhost:7289"),
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