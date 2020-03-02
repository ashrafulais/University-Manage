FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["UniversityManage/*.csproj", "UniversityManage/"]
COPY ["UniversityManage.Data/*.csproj", "UniversityManage.Data/"]
COPY ["UniversityManage.Model/*.csproj", "UniversityManage.Model/"]

RUN dotnet restore "UniversityManage/UniversityManage.csproj"
COPY . .
WORKDIR "/src/UniversityManage"
RUN dotnet build "UniversityManage.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UniversityManage.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UniversityManage.dll"]