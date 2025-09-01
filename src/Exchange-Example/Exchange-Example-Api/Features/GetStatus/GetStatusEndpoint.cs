namespace Exchange_Example_Api.Features.GetStatus;

public static class GetStatusEndpoint
{
    public static void MapGetStatusEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/status", () =>
        {
            return Results.Ok(new { Status = "Running", Timestamp = DateTime.UtcNow });
        })
        .WithName("GetStatus")
        .WithTags("Status");
    }
}
