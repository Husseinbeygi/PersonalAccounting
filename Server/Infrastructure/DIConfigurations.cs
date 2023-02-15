using System.Reflection;
using Domain.AccountSides;
using Domain.BankAccounts;
using Domain.Banks;
using Domain.Categories;
using Domain.Currencies;
using Domain.Events;
using Domain.Projects;
using Domain.SeedWork;
using Domain.Transactions;
using Persistence.Repositories;

namespace Server.Infrastructure;

public static class DIConfigurations
{
	public static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddTransient(typeof(IRepository <,>),typeof(RepositoryBase <,>));


		services.AddTransient<IEventRepository, EventRepository>();
		services.AddTransient<ITransactionRepository, TransactionRepository>();
		services.AddTransient<IBankRepository, BankRepository>();
		services.AddTransient<IBankAccountRepository, BankAccountRepository>();
		services.AddTransient<IProjectRepository, ProjectRepository>();
		services.AddTransient<ICurrencyRepository, CurrencyRepository>();
		services.AddTransient<ICategoryRepository, CategoryRepository>();
		services.AddTransient<IAccountSideRepository, AccountSideRepository>();

		return services;
	}

}