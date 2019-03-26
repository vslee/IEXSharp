using IEX.V2.Model.Stock.Requests;
using IEX.V2.Model.Stock.Response;
using System.Threading.Tasks;

namespace IEX.V2.Service.Stock
{
    public interface IStockService
    {
        BalanceSheetResponse BalanceSheet(string symbol, Period period, int last = 1);

        Task<BalanceSheetResponse> BalanceSheetAsync(string symbol, Period period, int last = 1);

        string BalanceSheetField(string symbol, Period period, string field, int last = 1);

        Task<string> BalanceSheetFieldAsync(string symbol, Period period, string field, int last = 1);
    }
}