FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY PersonalNote/PersonalNote.csproj PersonalNote/
RUN dotnet restore PersonalNote/PersonalNote.csproj
COPY . .
WORKDIR /src/PersonalNote
RUN dotnet build PersonalNote.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PersonalNote.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PersonalNote.dll"]
