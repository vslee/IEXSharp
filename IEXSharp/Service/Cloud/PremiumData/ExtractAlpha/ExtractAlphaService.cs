using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model;

namespace IEXSharp.Service.Cloud.PremiumData.ExtractAlpha
{
	public class ExtractAlphaService : IExtractAlphaService
	{
	private readonly ExecutorREST executor;

	internal ExtractAlphaService(ExecutorREST executor)
	{
		this.executor = executor;
	}

	public async Task<IEXResponse<IEnumerable<object>>> CrossAssetModelOneAsync(string symbol) =>
		await executor.NoParamExecute<IEnumerable<object>>($"time-series/PREMIUM_EXTRACT_ALPHA_CAM/{symbol}");

	public Task<IEXResponse<IEnumerable<object>>> EsgCpscComplaintsAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgCpscRecallsAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgDolVisaApplicationsAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgEpaEnforcementsAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgEpaMilestonesAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgFecIndividualCampaignContributionsAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgOshaInspectionsAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgSenateLobbyingAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgUsaSpendingAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> EsgUsptoPatentApplicationsAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}

	public Task<IEXResponse<IEnumerable<object>>> TacticalModelOneAsync(string symbol)
	{
		throw new System.NotImplementedException();
	}
	}
}