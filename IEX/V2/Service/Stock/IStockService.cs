using IEX.V2.Model.Stock.Request;
using IEX.V2.Model.Stock.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEX.V2.Service.Stock
{
    public interface IStockService
    {
        Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period, int last = 1);
        Task<string> BalanceSheetFieldAsync(string symbol, Period period, string field, int last = 1);

        Task<BatchBySymbolResponse> BatchBySymbolAsync(string symbol, IEnumerable<BatchType> types, string range = "", int last = 1);
        Task<Dictionary<string, BatchBySymbolResponse>> BatchByMarketAsync(IEnumerable<string> symbols, IEnumerable<BatchType> types, string range = "", int last = 1);

        Task<BookResponse> BookAsync(string symbol);

        Task<CashFlowResponse> CashFlowAsync(string symbol, Period period, int last = 1);
        Task<string> CashFlowFieldAsync(string symbol, Period period, string field, int last = 1);

        Task<object> CollectionsAsync(CollectionType collection, string collectionName);
    }
}