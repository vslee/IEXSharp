# IEXDotNetWrapper

This is an unofficial .Net Wrapper for IEX API V2

# Usage

## V1

```c#
IEXRestV1Client iexClient = new IEXRestV1Client();
```

## V2
```c#
//For FREE and LAUNCH users
IEXRestV2Client iexClient = new IEXRestV2Client("publishToken", "secretToken", false, false); 

//For SCALE and GROW users
IEXRestV2Client iexClient = new IEXRestV2Client("publishToken", "secretToken", true, false); 

//Sandbox
IEXRestV2Client iexClient = new IEXRestV2Client("publishToken", "secretToken", false, true); 
```

# Disclaimer
Data provided for free by [IEX](https://iextrading.com/developer/). View [IEX’s Terms of Use](https://iextrading.com/api-exhibit-a/)