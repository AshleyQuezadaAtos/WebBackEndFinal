#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 667
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebBackEndRepo.csproj", "."]
RUN dotnet restore "WebBackEndRepo.csproj"
COPY . .
RUN dotnet build "WebBackEndRepo.csproj" -c Release -o /app/build
#Setup db
#USER root
#ENV PATH $PATH:/root/.dotnet/tools
#RUN dotnet tool install --global dotnet-ef
#RUN dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.1
#CMD ["dotnet-ef", "migrations", "add", "Setup_database"]
#ENTRYPOINT ["dotnet-ef", "database", "update"]
FROM build AS publish
RUN dotnet publish "WebBackEndRepo.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebBackEndRepo.dll"]

