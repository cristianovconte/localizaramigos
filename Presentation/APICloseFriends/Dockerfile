FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY LocalizarAmigos.sln ./
COPY Presentation/APICloseFriends/APICloseFriends.csproj Presentation/APICloseFriends/
COPY ApplicationServices/ApplicationServices.CalcLog/ApplicationServices.CalcLog.csproj ApplicationServices/ApplicationServices.CalcLog/
COPY ApplicationServices/ApplicationServices.Authentication/ApplicationServices.Authentication.csproj ApplicationServices/ApplicationServices.Authentication/
COPY Domain/Entities.Authentication/CrossCutting.Authentication.csproj Domain/Entities.Authentication/
COPY Application/Application.CloseFriends/Application.CloseFriends.csproj Application/Application.CloseFriends/
COPY Infra/RepositoriesServices.CloseFriends/RepositoriesServices.CloseFriends.csproj Infra/RepositoriesServices.CloseFriends/
COPY Domain/Entities.Person/Entities.CloseFriends.csproj Domain/Entities.Person/
COPY ApplicationServices/ApplicationServices.CloseFriends/ApplicationServices.CloseFriends.csproj ApplicationServices/ApplicationServices.CloseFriends/
COPY Infra/Repositories.CloseFriends/Repositories.CloseFriends.csproj Infra/Repositories.CloseFriends/
COPY Infra/Repositories.CalcLog/Repositories.CalcLog.csproj Infra/Repositories.CalcLog/
COPY Infra/RepositoriesService.CalcLog/RepositoriesService.CalcLog.csproj Infra/RepositoriesService.CalcLog/
COPY Infra/Repositories.Authentication/Repositories.Authentication.csproj Infra/Repositories.Authentication/
COPY Infra/RepositoriesServices.Authentication/RepositoriesServices.Authentication.csproj Infra/RepositoriesServices.Authentication/
COPY Application/Application.Authentication/Application.Authentication.csproj Application/Application.Authentication/
COPY Application/Application.CalcLog/Application.CalcLog.csproj Application/Application.CalcLog/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Presentation/APICloseFriends
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "APICloseFriends.dll"]
