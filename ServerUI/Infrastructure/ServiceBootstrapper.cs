using ServerUI.Pages.Bank.Services;
using ServerUI.Pages.BankAccount.Services;

namespace ServerUI.Infrastructure
{
	public class ServiceBootstrapper
	{
		public static void Register(IServiceCollection service)
		{
			service.AddScoped<BankAccountService>();
			service.AddScoped<BankService>();
			
		}
	}
}
