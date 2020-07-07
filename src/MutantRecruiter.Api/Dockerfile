# RUN COMMAND
# docker build -t ml-mutant-recruiter -f src/MutantRecruiter.Api/Dockerfile .
# docker run -d -p 5160:80 --name ml ml-mutant-recruiter
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY *.sln .
COPY . .
WORKDIR /app/src/MutantRecruiter.Api
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/src/MutantRecruiter.Api/out ./

# Optional: Set this here if not setting it from docker-compose.yml
# ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "MutantRecruiter.Api.dll"]