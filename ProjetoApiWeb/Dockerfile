FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "ProjetoApiWeb.csproj"

WORKDIR "/src"
RUN dotnet build "ProjetoApiWeb.csproj" -c Release -o /app/build
RUN dotnet publish "ProjetoApiWeb.csproj" -c Release -o /app/publish

FROM base AS final
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add tzdata
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProjetoApiWeb.dll"]