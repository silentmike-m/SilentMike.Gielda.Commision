namespace SilentMike.Gielda.Commision.WebApi.Controllers;

internal static class CustomersController
{
    private static string URL_PATTERN = "/customers";

    public static IEndpointRouteBuilder MapCustomers(this IEndpointRouteBuilder app)
        => app
            .MapGetCustomers();

    private static IEndpointRouteBuilder MapGetCustomers(this IEndpointRouteBuilder app)
    {
        app.MapGet(URL_PATTERN, () => new List<string>())
            .WithName("GetCustomers")
            .WithOpenApi();

        return app;
    }
}
