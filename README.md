# TEST gRPC

## TODO

* [x] Setup a basic implementation for a gRPC service and client applications
* [ ] Use Stream Request/Response: [Example](https://github.com/grpc/grpc-dotnet/tree/master/examples/Mailer)
* [ ] Create a Python client [Example](https://github.com/grpc/grpc/tree/master/examples/python/helloworld)

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

## Core Concepts

There are 4 types of gRPC services:
- **Unary RPCs**: client sends a request, server returns a response
- **Server streaming RPCs**: client sends a request, server returns a stream (message order guaranteed). The client reads the sequence of messages until there is no more messages. 
- **Client streaming RPCs**: client writes a stream / sequence of messages and sends them to the server (message order guaranteed). When the client has finished sending messages, it waits for the response.
- **Bidirectional streaming RPCs**: client and server send a sequence of messages using a read-write stream (message order guaranteed). The two streams operate independently. 
