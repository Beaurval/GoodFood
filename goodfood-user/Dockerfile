FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /goodfood-user

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /goodfood-user
COPY --from=build-env /goodfood-user/out .
ENTRYPOINT ["dotnet", "goodfood-user.dll"]
