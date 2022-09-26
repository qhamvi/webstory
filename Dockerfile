FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
RUN mkdir /app/Images
RUN mkdir /app/Photos
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["webstory.csproj", "./"]
RUN dotnet restore "webstory.csproj"
COPY . .
RUN dotnet publish "webstory.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "webstory.dll"]
