using Exchange_Example_Api.Endpoints.Status;

namespace Exchange_Example_Api.Endpoints;

public static class CustomEndpointBuilder
{
    public static void MapAllCustomEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetStatusEndpoint();
    }
}
