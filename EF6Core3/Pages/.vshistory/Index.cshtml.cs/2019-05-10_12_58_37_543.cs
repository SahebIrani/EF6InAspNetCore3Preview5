using EF6Core3.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EF6Core3.Pages
{
	public class IndexModel : PageModel
	{
		public async Task<IActionResult> OnGetAsync(CancellationToken cancellationToken)
		{
			const string connectionString = @"server=(localdb)\mssqllocaldb; database=AppDbContext; Integrated Security=true";

			DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

			using (var db = new AppDbContext(connectionString))
			{
				db.Database.CreateIfNotExists();

				IList<Person> lst = new List<Person>();

				for (int i = 1; i < 13; i++)
					lst.Add(new Person { Age = 27, CreateDate = DateTimeOffset.UtcNow, FullName = $"SinjulMSBH {i}" });

				db.People.AddRange(lst);
				await db.SaveChangesAsync(cancellationToken);
			}

			using AppDbContext context = new AppDbContext(connectionString);
			Console.WriteLine($"{await context.People.FirstAsync(cancellationToken)?.FullName} write this sample .. !!!!");

			IReadOnlyList<Person> people = await context.People.ToListAsync(cancellationToken);

			return new JsonResult(people);
		}
	}
}