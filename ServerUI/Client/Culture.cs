using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace Crm.FrontEnd.Blazor.Infrastructure;

public class Culture
{
	public static async Task SetUserCulture(WebAssemblyHost host)
	{
		CultureInfo culture;
		var js = host.Services.GetRequiredService<IJSRuntime>();
		//var result = await js.InvokeAsync<string>("window.blazorCulture.get");

		//if (result != null)
		//{
		//	culture = new CultureInfo(result);
		//}
		//else
		//{
		//	culture = new CultureInfo("fa-IR");
		//	await js.InvokeVoidAsync("window.blazorCulture.set", "fa-IR");
		//}

		CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fa-IR");
		CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fa-IR");
    }
}
