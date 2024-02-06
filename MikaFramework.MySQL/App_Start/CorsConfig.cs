using Microsoft.Extensions.DependencyInjection;

namespace MikaFramework.MySQL
{
    public static class CorsConfig
    {
        public static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
    }
}

