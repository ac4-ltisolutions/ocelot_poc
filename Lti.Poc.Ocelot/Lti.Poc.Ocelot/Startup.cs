using Lti.Poc.Ltid.Client;
using Lti.Poc.Ocelot.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Lti.Poc.Ocelot
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot()
                .AddLtidForOcelotAutorouting();
            services.AddControllers();;
            services.AddSwaggerForOcelot(this.Configuration);

            services.AddScoped<ILtidClient, LtidClient>();
            services.AddSingleton(serviceProvider => new LtidClientConfig());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILtidClient ltidClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseLtidDebugMiddleware(ltidClient);
            }


            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
                opt.ReConfigureUpstreamSwaggerJson = AlterUpstreamSwaggerJson;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            await app.UseOcelot().ConfigureAwait(false);

            app.UseEndpoints(endpoints => endpoints.MapControllers());

        }

        private string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson)
        {
            var swagger = JObject.Parse(swaggerJson);
            // ... alter upstream json
            // TODO: parse returning swagger and add bearer addresses
            return swagger.ToString(Formatting.Indented);
        }

    }
}
