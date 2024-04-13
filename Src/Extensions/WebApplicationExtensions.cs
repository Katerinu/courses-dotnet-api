using courses_dotnet_api.Src.Data;
using Microsoft.EntityFrameworkCore;

namespace courses_dotnet_api.Src.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureApp(this WebApplication app)
    {
        app.MapControllers();
        app.UseAuthentication();
        app.UseAuthorization();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<DataContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<WebApplication>>();
            logger.LogError(ex, "An error occurred during migration");
        }
    }
}
