#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["netcore/tests/Koralium.WebTests/Koralium.WebTests.csproj", "tests/Koralium.WebTests/"]
COPY ["netcore/src/Koralium.Transport.LegacyGrpc/Koralium.Transport.LegacyGrpc.csproj", "src/Koralium.Transport.LegacyGrpc/"]
COPY ["netcore/src/Koralium.Transport/Koralium.Transport.csproj", "src/Koralium.Transport/"]
COPY ["netcore/src/Koralium.SqlParser/Koralium.SqlParser.csproj", "src/Koralium.SqlParser/"]
COPY ["netcore/src/Koralium.Shared/Koralium.Shared.csproj", "src/Koralium.Shared/"]
COPY ["netcore/src/Koralium.Transport.LegacyGrpc.Abstractions/Koralium.Transport.LegacyGrpc.Abstractions.csproj", "src/Koralium.Transport.LegacyGrpc.Abstractions/"]
COPY ["netcore/src/Koralium/Koralium.csproj", "src/Koralium/"]
COPY ["netcore/src/Koralium.Transport.ArrowFlight/Koralium.Transport.ArrowFlight.csproj", "src/Koralium.Transport.ArrowFlight/"]
COPY ["netcore/src/Koralium.Transport.RowLevelSecurity/Koralium.Transport.RowLevelSecurity.csproj", "src/Koralium.Transport.RowLevelSecurity/"]
COPY ["netcore/src/Koralium.Core/Koralium.Core.csproj", "src/Koralium.Core/"]
COPY ["netcore/src/Koralium.SqlToExpression/Koralium.SqlToExpression.csproj", "src/Koralium.SqlToExpression/"]
COPY ["netcore/src/Koralium.SqlParser.ANTLR/Koralium.SqlParser.ANTLR.csproj", "src/Koralium.SqlParser.ANTLR/"]
COPY ["netcore/src/Koralium.Transport.Json/Koralium.Transport.Json.csproj", "src/Koralium.Transport.Json/"]
RUN dotnet restore "tests/Koralium.WebTests/Koralium.WebTests.csproj"
COPY ./netcore .
WORKDIR "/src/tests/Koralium.WebTests"
RUN dotnet build "Koralium.WebTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Koralium.WebTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY TestData /app/Data 
ENTRYPOINT ["dotnet", "Koralium.WebTests.dll"]