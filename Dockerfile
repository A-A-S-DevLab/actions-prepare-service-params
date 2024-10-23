FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env

COPY . ./
RUN dotnet publish ./GitHubAction/GitHubAction.csproj -c Release -o out --no-self-contained

FROM mcr.microsoft.com/dotnet/sdk:8.0
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "/GitHubAction.dll" ]
