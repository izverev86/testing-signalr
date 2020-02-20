using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TickTock.Background;
using TickTock.Hubs;

namespace TickTock
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSignalR();
			services.AddSingleton<TikTokHub>();
			services.AddHostedService<TikSenderService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseFileServer();

			app.UseRouting();
			app.UseEndpoints(builder => { builder.MapHub<TikTokHub>("tik-tok"); });
			app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
		}
	}
}