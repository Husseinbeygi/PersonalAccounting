using Microsoft.AspNetCore.Components.Authorization;
using ServerUI.Services;

namespace ServerUI.Pages.Bank.Services
{
	public class BankService : ServiceBase
	{

		public BankService(HttpClient http,
			AuthenticationStateProvider authenticationStateProvider)
			: base(http, authenticationStateProvider)
		{
			BaseUrl = "/api/v1/Bank";
		}
	}
}
