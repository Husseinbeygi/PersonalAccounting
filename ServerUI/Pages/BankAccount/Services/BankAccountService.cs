using Framework.HttpServices;
using Microsoft.AspNetCore.Components.Authorization;

namespace ServerUI.Pages.BankAccount.Services
{
	public class BankAccountService : ServiceBase
	{

		public BankAccountService(HttpClient http,
			AuthenticationStateProvider authenticationStateProvider)
			: base(http, authenticationStateProvider)
		{
			BaseUrl = "/BankAccount";
		}
	}
}
