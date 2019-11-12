# IEXSharp

IEX Cloud API for C# and other .net languages

## Prerequisites

 This library currently targets `netstandard20`. Thus, it can be used with .net framework 4.6.1+ and .net core 2.0+

## Usage

Package is available at [Nuget](https://www.nuget.org/packages/IEXSharp/)

### V1

```c#
IEXRestV1Client iexClient = new IEXRestV1Client();
```

### V2
```c#
//For FREE and LAUNCH users
IEXRestV2Client iexClient = new IEXRestV2Client("publishToken", "secretToken", false, false); 

//For SCALE and GROW users
IEXRestV2Client iexClient = new IEXRestV2Client("publishToken", "secretToken", true, false); 

//Sandbox
IEXRestV2Client iexClient = new IEXRestV2Client("publishToken", "secretToken", false, true); 
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

## Acknowledgments

* Thanks to [Zhirong Huang (ZHCode)](https://zh-code.com/) for his great foundational work on this library