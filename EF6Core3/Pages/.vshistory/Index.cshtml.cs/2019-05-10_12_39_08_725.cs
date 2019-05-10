using EF6Core3.Data;

using Microsoft.AspNetCore.Mvc.RazorPages;

using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace EF6Core3.Pages
{
	public class IndexModel : PageModel
	{
		public void OnGet()
		{
			var cs = @"server=(localdb)\mssqllocaldb; database=AppDbContext; Integrated Security=true";

			// workaround:
			DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

			using (var db = new AppDbContext(cs))
			{
				db.Database.CreateIfNotExists();
				db.People.Add(new Person { Age = 27, CreateDate = DateTimeOffset.UtcNow, FullName = "SinjulMSBH" });
				db.SaveChanges();
			}

			using AppDbContext context = new AppDbContext(cs)
			Console.WriteLine($"{context.People.First()?.FullName} wrote this sample");
		}
	}
}
