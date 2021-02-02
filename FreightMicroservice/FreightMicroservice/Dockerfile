#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
COPY ["./bin/Debug/netcoreapp3.1", "./bin/"]
ENV ASPNETCORE_URLS http://localhost:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "./bin/FreightMicroservice.dll"]

#
#WORKDIR /src
#COPY ["FreightMicroservice.csproj", "./FreightMicroservice/"]
#RUN dotnet restore "FreightMicroservice/FreightMicroservice.csproj"
#COPY . .
#WORKDIR "/src/FreightMicroservice"
#RUN dotnet build "FreightMicroservice.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "FreightMicroservice.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "FreightMicroservice.dll"]

