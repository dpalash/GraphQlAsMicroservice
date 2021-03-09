using BlogPostMicroService.Interfaces.Repositories;
using BlogPostMicroService.Interfaces.Services;
using BlogPostMicroService.Models;
using BlogPostMicroService.Repositories;
using BlogPostMicroService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogPostMicroService
{
    public class Startup
    {
        private readonly string AllowedOrigin = "allowedOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInMemorySubscriptions();

            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IBlogPostService, BlogPostService>();

            services.AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                .AddMutationType(d => d.Name("Mutation"))
                .AddSubscriptionType(d => d.Name("Subscription"))
                .AddType<BlogPostQuery>()
                .AddType<BlogPostMutation>()
                .AddType<BlogPostSubscription>()
                .PublishSchemaDefinition(c => c
                .SetName("blogPosts"));

            services.AddCors(option =>
            {
                option.AddPolicy(AllowedOrigin,
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowedOrigin);

            app.UseWebSockets();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
