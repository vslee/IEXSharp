using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.AuditAnalytics.Response;

namespace IEXSharp.Service.Cloud.PremiumData.AuditAnalytics
{
	public interface IAuditAnalyticsService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#audit-analytics-director-and-officer-changes"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<DirectorAndOfficerChangesResponse>>> DirectorAndOfficerChangesAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#audit-analytics-accounting-quality-and-risk-matrix"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<AccountingQualityAndRiskMatrixResponse>>> AccountingQualityAndRiskMatrixAsync(string symbol);
	}
}
