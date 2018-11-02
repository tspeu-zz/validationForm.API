FROM microsoft/dotnet:2.2.0-preview2-35157-runtime
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet <pruebaJM.API>.dll

