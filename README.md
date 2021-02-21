# IEXSharp

IEX Cloud API for C# and other .net languages. Supports SSE streaming.

## Prerequisites

 This library currently targets `netstandard20`. Thus, it can be used with `.net framework 4.6.1`+ or `.net core 2.0`+

## Usage
![](https://github.com/vslee/iexsharp/workflows/prerelease%20NuGet/badge.svg) Prereleases are on [GH Packages](https://github.com/vslee/IEXSharp/packages). A new prerelease is built automatically after every commit. 

[![NuGet Badge](https://buildstats.info/nuget/VSLee.IEXSharp)](https://www.nuget.org/packages/VSLee.IEXSharp/) Releases are on [NuGet](https://www.nuget.org/packages/VSLee.IEXSharp/)

### IEX Cloud
```c#
public IEXCloudClient(string publishableToken, string secretToken, bool signRequest, bool useSandBox,
	APIVersion version = APIVersion.stable, RetryPolicy retryPolicy = RetryPolicy.Exponential)
```
First, create an instance of `IEXCloudClient`
```c#
// For FREE and LAUNCH users
IEXCloudClient iexCloudClient = 
	new IEXCloudClient("publishableToken", "secretToken", signRequest: false, useSandBox: false); 

// For SCALE and GROW users
IEXCloudClient iexCloudClient = 
	new IEXCloudClient("publishableToken", "secretToken", signRequest: true, useSandBox: false); 

// Sandbox
IEXCloudClient iexCloudClient = 
	new IEXCloudClient("publishableToken", "secretToken", signRequest: false, useSandBox: true); 
```
To display historical prices. Read more about [DateTime in the wiki](https://github.com/vslee/IEXSharp/wiki/DateTime).
```c#
using (var iexCloudClient = 
	new IEXCloudClient("publishableToken", "secretToken", signRequest: false, useSandBox: false))
{
	var response = await iexCloudClient.StockPrices.HistoricalPriceAsync("AAPL", ChartRange.OneMonth);
	if (response.ErrorMessage != null)
	{
		Console.WriteLine(response.ErrorMessage);
	}
	else
	{
	   foreach (var ohlc in response.Data)
	   {
	      var dt = ohlc.GetTimestampInEST(); // note use of the extension method instead of ohlc.date
	      Console.WriteLine(
	   	  $"{dt} Open: {ohlc.open}, High: {ohlc.high}, Low: {ohlc.low}, Close: {ohlc.close}, Vol: {ohlc.volume}");
	   }
	}
}

```
To use SSE streaming (only included with paid IEX subscription plans). Extended [example in the wiki](https://github.com/vslee/IEXSharp/wiki/SSE-Streaming-Example).
```c#
using (var sseClient = iexCloudClient.StockPrices.QuoteStream(symbols: new string[] { "spy", "aapl" }, 
	UTP: false, interval: StockQuoteSSEInterval.OneSecond))
{
	sseClient.Error += (s, e) =>
	{
		Console.WriteLine("Error Occurred. Details: {0}", e.Exception.Message);
	};
	sseClient.MessageReceived += m =>
	{
		Console.WriteLine(m.ToString());
	};
	await sseClient.StartAsync(); // this will block until Stop() is called
}

```
Additional usage examples are illustrated in the test project: [`IEXSharpTest`](https://github.com/vslee/IEXSharp/tree/master/IEXSharpTest/Cloud)

### Legacy

IEX has deprecated most of their [legacy API](https://iextrading.com/developers/docs/). However, some functions are still active and you can access them via:
```c#
IEXLegacyClient iexLegacyClient = new IEXLegacyClient();
```

## Contributing

We welcome pull requests! See [CONTRIBUTING.md](CONTRIBUTING.md).

## License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.md)

## Disclaimers

Data provided for free by [IEX](https://iextrading.com/) via their [IEX Cloud API](https://iexcloud.io/docs/api/)
Per their [guidelines](https://iexcloud.io/docs/api/#disclaimers):
- Required: If you display any delayed price data, you must display “15 minute delayed price” as a disclaimer.
- Required: If you display latestVolume you must display “Consolidated Volume in Real-time” as a disclaimer.
- Required: If you use cash flow, income statement, balance sheet, financials, or fundamentals endpoints, use must display “Data provided by New Constructs, LLC © All rights reserved.”
- Note on pricing data: All CTA and UTP pricing data is delayed at least 15 minutes.

This project is not related to the similarly named [IEX-Sharp](https://iexsharp.com/)

## Acknowledgments

* Thanks to [Zhirong Huang (ZHCode)](https://zh-code.com/) for his great foundational work on this library
