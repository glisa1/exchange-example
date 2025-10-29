using Exchange_Example_Api.Utils.Request;
using Microsoft.AspNetCore.Mvc;

namespace Exchange_Example_Api.Features.SearchStocks;

public static class SearchStockEndpoint
{
    public static void MapSearchStockEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/search-stocks", async (
            IQueryRequestHandler<SearchStockQuery, SearchStockResult> queryHandler,
            [FromQuery] string searchTerm,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken) =>
        {
            var query = new SearchStockQuery
            {
                SearchTerm = searchTerm,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            if (!query.IsValid())
            {
                return Results.BadRequest(new { Message = "Invalid query parameters." });
            }

            var result = await queryHandler.Handle(query, cancellationToken);
            return Results.Ok(result);
        })
        .WithTags("Stocks")
        .WithName("SearchStocks")
        .WithSummary("Search for stocks by ticker or name with pagination.")
        .WithDescription("Provides a paginated list of stocks matching the search term in their ticker or name.");
    }
}
