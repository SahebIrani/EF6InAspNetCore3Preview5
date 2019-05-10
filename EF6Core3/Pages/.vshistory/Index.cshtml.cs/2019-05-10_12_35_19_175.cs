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
			var cs = @"server=(localdb)\mssqllocaldb; database=MyContext; Integrated Security=true";

			// workaround:
			DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

			using (var db = new AppDbContext(cs))
			{

				db.Database.CreateIfNotExists();
				db.People.Add(new Person { Name = "Diego" });
				db.SaveChanges();
			}

			using (var db = new AppDbContext(cs))
			{
				Console.WriteLine($"{db.People.First()?.Name} wrote this sample");
			}
		}
	}
}
