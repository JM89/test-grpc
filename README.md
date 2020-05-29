# TEST gRPC

## Getting Started

Start the gRPC service:
```
dotnet build ./service/ProductGrpcService/ProductGrpcService/ProductGrpcService.csproj
dotnet run -p ./service/ProductGrpcService/ProductGrpcService/ProductGrpcService.csproj
```

Start the gRPC consumer example:
```
dotnet build ./client/ProductGrpcClient/ProductGrpcClient/ProductGrpcClient.csproj
dotnet run -p ./client/ProductGrpcClient/ProductGrpcClient/ProductGrpcClient.csproj
```
