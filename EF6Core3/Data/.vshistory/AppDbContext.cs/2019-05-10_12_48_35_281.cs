using System;
using System.Data.Entity;

namespace EF6Core3.Data
{
	public class AppDbContext : DbContext
	{
		const string connectionString = @"server=(localdb)\mssqllocaldb; database=AppDbContext; Integrated Security=true";

		public AppDbContext(string connectionString) : base(connectionString)
		{
		}

		public DbSet<Person> People { get; set; }
	}

	public class Person
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public short Age { get; set; }
		public DateTimeOffset CreateDate { get; set; }
	}
}
