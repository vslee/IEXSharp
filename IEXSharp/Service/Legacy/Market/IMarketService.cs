using IEXSharp.Model.InvestorsExchangeData.Response;
using IEXSharp.Model.Market.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.MarketInfo.Response;

namespace IEXSharp.Service.Legacy.Market
{
	public interface IMarketService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#tops"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<TOPSResponse>>> TOPSAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#last"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<LastResponse>>> LastAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#hist"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, IEnumerable<HISTResponse>>>> HISTAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#hist"/>
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<HISTResponse>>> HISTByDateAsync(DateTime date);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#deep"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<DeepResponse>> DeepAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#book60"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<DeepBookResponse>> DeepBookAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#trades"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, IEnumerable<DeepTradeResponse>>>> DeepTradeAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#system-event"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<DeepSystemEventResponse>> DeepSystemEventAsync();

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#operational-halt-status"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepOperationalHaltStatusResponse>>> DeepOperationHaltStatusAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#short-sale-price-test-status"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepShortSalePriceTestStatusResponse>>> DeepShortSalePriceTestStatusAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#security-event"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepSecurityEventResponse>>> DeepSecurityEventAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#auction"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepAuctionResponse>>> DeepAuctionAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#official-price"/>
		/// </summary>
		/// <param name="symbols"></param>
		/// <returns></returns>
		Task<IEXResponse<Dictionary<string, DeepOfficialPriceResponse>>> DeepOfficialPriceAsync(IEnumerable<string> symbols);

		/// <summary>
		/// <see cref="https://iextrading.com/developer/docs/#markets"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<MarketVolumeUSResponse>>> MarketVolumeUSAsync();
	}
}