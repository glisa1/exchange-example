namespace Exchange_Example_Api.Services;

public sealed record ExchangePriceChangeModel(int StockId, string Ticker, string StockName, double Price);
