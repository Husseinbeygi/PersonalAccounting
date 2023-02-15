using Domain.AccountSides;
using Domain.BankAccounts;
using Domain.Banks;
using Domain.Categories;
using Domain.Currencies;
using Domain.Events;
using Domain.Projects;
using Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransactionConfigurations).Assembly);
		}


		public DbSet<AccountSide> AccountSide { get; set; }
		public DbSet<Bank> Bank { get; set; }
		public DbSet<BankAccount> BankAccount { get; set; }
		public DbSet<Currency> Currency { get; set; }
		public DbSet<Event> Event { get; set; }
		public DbSet<Project> Project { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Transaction> Transaction { get; set; }




	}
}