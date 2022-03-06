using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstituteApi.Model
{
    public static class Intialize
    {
        public static IApplicationBuilder IntializeDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<DataContext>(); //Service locator
            dbContext.Database.Migrate();
            return app;
        }
    }
}
