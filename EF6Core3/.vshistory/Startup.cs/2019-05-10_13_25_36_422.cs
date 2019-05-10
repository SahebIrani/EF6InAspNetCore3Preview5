using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EF6Core3
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services) => services.AddControllers.AddRazorPages();
		public void Configure(IApplicationBuilder app)
		{
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
