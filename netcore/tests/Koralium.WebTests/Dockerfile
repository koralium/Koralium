#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["tests/Koralium.WebTests/Koralium.WebTests.csproj", "tests/Koralium.WebTests/"]
COPY ["src/Koralium.Json/Koralium.Json.csproj", "src/Koralium.Json/"]
COPY ["src/Koralium/Koralium.csproj", "src/Koralium/"]
COPY ["src/Koralium.SqlToExpression/Koralium.SqlToExpression.csproj", "src/Koralium.SqlToExpression/"]
COPY ["src/Koralium.Shared/Koralium.Shared.csproj", "src/Koralium.Shared/"]
RUN dotnet restore "tests/Koralium.WebTests/Koralium.WebTests.csproj"
COPY . .
WORKDIR "/src/tests/Koralium.WebTests"
RUN dotnet build "Koralium.WebTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Koralium.WebTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Koralium.WebTests.dll"]