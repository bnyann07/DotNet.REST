FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ENV ASPNETCORE_URLS http://*:5152
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5152

WORKDIR /app/api/
# EXPOSE 80
# EXPOSE 443

COPY /api/*.csproj .

WORKDIR /app/

COPY . .
# COPY /api .
# COPY . /app/api
# COPY . /app/api

WORKDIR /app/api/

RUN dotnet restore "api.csproj"

# RUN dotnet publish -c Release -o out
# ENTRYPOINT ["dotnet", "api.dll"]
ENTRYPOINT ["dotnet", "watch", "run", "--project", "api.csproj", "--urls", "http://0.0.0.0:5152"]
# ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]