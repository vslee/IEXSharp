# IEX.API.V2.Signer

Sign request for IEX API V2
Only available to Grow and Scale users

# Usage

```c#
string host = "sandbox.iexapis.com"; //Sandbox host
//string host = "cloud.iexapis.com" //Production host
string pk = "PublishToken";
string sk = "SecretToken";

IEXSigner.Init(host, sk);

/*
 * If run separately
IEXSigner.SetHost(host);
IEXSigner.SetSecretToken(sk);
*/

string method = "GET";
string url = "/account/metadata"; // "/" is required at the beginning
string queryString = "namea=1&nameb=2";
string payload = "{\"test\":123,\"obj\":456}";

//For GET requests
(string iexdate, string authorization_header) headers = Sign(pk, method, url, queryString);

//For POST requests
(string iexdate, string authorization_header) headers = Sign(pk, method, url, queryString, payload);
```

Set request header [Read More](https://iexcloud.io/docs/api/#signed-requests)

# To IEX Benjamin and Ryan

Thank you so much for helping me understand the requirement.