#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#timezone env with default
ENV TZ America/La_Paz

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Functions/ControlGifts/ControlGifts.MicroService/ControlGifts.MicroService.csproj", "Functions/ControlGifts/ControlGifts.MicroService/"]
RUN dotnet restore "Functions/ControlGifts/ControlGifts.MicroService/ControlGifts.MicroService.csproj"
COPY . .
WORKDIR "/src/Functions/ControlGifts/ControlGifts.MicroService"
RUN dotnet build "ControlGifts.MicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ControlGifts.MicroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControlGifts.MicroService.dll"]