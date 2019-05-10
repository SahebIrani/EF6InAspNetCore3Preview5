using System.Data.Entity;

namespace EF6Core3.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
		{
		}

		public DbSet People { get; set; }
	}

	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
