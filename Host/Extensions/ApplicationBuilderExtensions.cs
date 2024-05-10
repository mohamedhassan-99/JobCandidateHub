using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Host.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetRequiredService<CandidateContext>();

        dbContext.Database.Migrate();
    }
}
