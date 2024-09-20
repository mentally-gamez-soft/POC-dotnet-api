# Multi stage build. Deletion of sddk around 600MB of data

# Stage 1: Build the application
# Use the .NET SDK image to build and run the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build  
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
# Set the working directory
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/out .

# Ensure we listen on any IP Address 
ENV DOTNET_URLS=http://+:5000
ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000
# Set the entry point to the published app
ENTRYPOINT ["dotnet", "MyApi.dll"]