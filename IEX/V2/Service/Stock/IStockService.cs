using IEX.V2.Model.Stock.Request;
using IEX.V2.Model.Stock.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEX.V2.Service.Stock
{
    public interface IStockService
    {
        BalanceSheetResponse BalanceSheet(string symbol, Period period, int last = 1);
        Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period, int last = 1);
        string BalanceSheetField(string symbol, Period period, string field, int last = 1);
        Task<string> BalanceSheetFieldAsync(string symbol, Period period, string field, int last = 1);

        BatchBySymbolResponse BatchBySymbol(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);
        Task<BatchBySymbolResponse> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);
        Dictionary<string, BatchBySymbolResponse> BatchByMarket(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);
        Task<Dictionary<string, BatchBySymbolResponse>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);

        BookResponse Book(string symbol);
        Task<BookResponse> BookAsync(string symbol);
    }
}