# TEST gRPC

## TODO

[x] Setup a basic implementation for a gRPC service and client applications
[ ] Use Stream Request/Response: [Example](https://github.com/grpc/grpc-dotnet/tree/master/examples/Mailer)
[ ] Create a Python client [Example](https://github.com/grpc/grpc/tree/master/examples/python/helloworld)

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
