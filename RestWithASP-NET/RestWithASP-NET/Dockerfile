#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/aspnetcore:2.0-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1803 AS build
WORKDIR /src
COPY RestWithASP-NET/RestWithASP_NET.csproj RestWithASP-NET/
RUN dotnet restore RestWithASP-NET/RestWithASP_NET.csproj
COPY . .
WORKDIR /src/RestWithASP-NET
RUN dotnet build RestWithASP_NET.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RestWithASP_NET.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RestWithASP_NET.dll"]
