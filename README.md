# QueryStringBuilder
Simple query string builder

# Usage
```c#
var qsb = new QueryStringBuilder();
qsb.Add("name", "value");
qsb.Add("name1", "value1");
qsb.Build(); // returns "?name=value&name1=value1"
```

# Available Functions
```c#
void Add(string key, object value);
bool TryAdd(string key, object value);
string Get(string key);
bool Exist(string key);
void Remove(string key);
int Count();
string Build();
```