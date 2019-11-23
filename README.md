# IEXSharp

IEX Cloud API for C# and other .net languages. Supports SSE streaming

## Prerequisites

 This library currently targets `netstandard20`. Thus, it can be used with `.net framework 4.6.1`+ and `.net core 2.0`+

## Usage
![](https://github.com/vslee/iexsharp/workflows/prerelease%20NuGet/badge.svg) Prerelease packages are on [GH Packages](https://github.com/vslee/IEXSharp/packages). 

Releases are on [NuGet](https://www.nuget.org/packages/IEXSharp/)

### IEX Cloud
```c#
//For FREE and LAUNCH users
IEXCloudClient iexClient = new IEXCloudClient("publishToken", "secretToken", false, false); 

//For SCALE and GROW users
IEXCloudClient iexClient = new IEXCloudClient("publishToken", "secretToken", true, false); 

//Sandbox
IEXCloudClient iexClient = new IEXCloudClient("publishToken", "secretToken", false, true); 
```
To use SSE streaming (only included with paid IEX subscription plans)
```c#
using (var sseClient = iexClient.SSE.SubscribeStockQuoteUSSSE(symbols: new string[] { "spy", "aapl" }, 
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
	await sseClient.StartAsync(); // this will block until cancelled
}

```
Additional usage examples are illustrated in the test project: [`IEXSharpTest`](https://github.com/vslee/IEXSharp/tree/master/IEXSharpTest/Cloud(V2))

### Legacy (V1)

IEX has deprecated most of their legacy API. However, some functions are still active and you can access them via:
```c#
IEXV1RestClient iexClient = new IEXV1RestClient();
```

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Disclaimers

Data provided for free by [IEX](https://iextrading.com/developer/) via their [IEX Cloud API](https://iexcloud.io/docs/api/)
Per their [guidelines](https://iexcloud.io/docs/api/#disclaimers):
- Required: If you display any delayed price data, you must display “15 minute delayed price” as a disclaimer.
- Required: If you display latestVolume you must display “Consolidated Volume in Real-time” as a disclaimer.
- Note on pricing data: All CTA and UTP pricing data is delayed at least 15 minutes.
- This project is not related to the similarly named [IEX-Sharp](https://iexsharp.pythonanywhere.com/)

## Acknowledgments

* Thanks to [Zhirong Huang (ZHCode)](https://zh-code.com/) for his great foundational work on this library
