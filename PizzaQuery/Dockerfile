# Stage 1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY /PizzaQuery /PizzaQuery
RUN dotnet build /PizzaQuery

# Stage 2
FROM build as publish
WORKDIR /app
RUN dotnet publish /PizzaQuery -c Release -o /app -r linux-x64

# Stage 3
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=publish /app .
CMD dotnet PizzaQuery.dll