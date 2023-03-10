using Microsoft.AspNetCore.Components.Authorization;
using ServerUI.Services;

namespace ServerUI.Pages.BankAccount.Services
{
	public class BankAccountService : ServiceBase
	{

		public BankAccountService(HttpClient http,
			AuthenticationStateProvider authenticationStateProvider)
			: base(http, authenticationStateProvider)
		{
			BaseUrl = "/api/v1/BankAccount";
		}
	}
}
