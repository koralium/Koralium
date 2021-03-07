
<br />
<p align="center">
  <h3 align="center">Koralium, .NET SQL API</h3>

  <p align="center">
    .NET SQL Data Service & Apache Arrow Flight API Framework
  </p>
</p>



<!-- ABOUT THE PROJECT -->
## About The Project

Koralium is a framework to help build data services that can recieve SQL statements to query data. The aim of Koralium is to help developers to easily expose data from different sources that can be consumed by for example an API gateway, graphQL and Presto/TrinoDB.

Koralium supports multiple different transport protocols, the two implemented at this time is:

* Apache Arrow Flight
* Json over http(s)

If Koralium is used with the json transport protocol, it can be called by any http client, but there is official clients for:

* Presto/TrinoDB over Apache Arrow Flight
* ADO.NET provider for C# over Apache Arrow Flight
* Entity Framework Core provider for C# over Apache Arrow Flight
* Javascript client for the Json protocol
