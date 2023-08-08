# .NET Core HTTP client library

This package contains a set of functionalities to use http client for microservice, the library is designed by Genocs even thought a lot of insight came from community.
First of all I have to say thanks to devmentors

The libraries are built using .NET7.


## Description

Core NuGet package http client implementation useful for for microservice architecture.


## Support

Please check the GitHub repository getting more info.


### DataProvider Settings
Following are the project settings needed to enable monitoring

``` json
  "AppSettings": {
    "ServiceName": "Demo WebApi",
  },
  "ConnectionStrings": {
    "ApplicationInsights": ""
  },
  "Monitoring": {
    "Jaeger": "localhost",
  }
```

## Release notes

### [2023-03-24] 5.0.0
- First release