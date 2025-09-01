using Exchange_Example_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Exchange_Example_Api.Configuration;

public static class ApDbContextConfiguration
{
    public static void RunMigrationsOnStartup(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}
