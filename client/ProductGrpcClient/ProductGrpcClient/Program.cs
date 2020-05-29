using Grpc.Net.Client;
using ProductGrpcService;
using System;
using System.Threading.Tasks;

namespace ProductGrpcClient
{
    class Program
    {
        const string GrpcServerUrl = "https://localhost:5001";
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress(GrpcServerUrl);
            var client = new ProductServiceDefinition.ProductServiceDefinitionClient(channel);
            var productA = new Product()
            {
                Id = 1,
                Description = "Description Product A",
                Name = "Product A"
            };
            await client.CreateAsync(new CreateRequest() { Product = productA });

            var productB = new Product()
            {
                Id = 2,
                Description = "Description Product B",
                Name = "Product B"
            };
            await client.CreateAsync(new CreateRequest() { Product = productB });

            var productResponse = await client.ReadAllAsync(new ReadAllRequest());
            foreach (var product in productResponse.Products)
            {
                Console.WriteLine("Updated Product: " + product.Name + " Description:" + product.Description);
            }

            productB.Description = "Description Product C";
            productB.Name = "Product C";

            await client.UpdateAsync(new UpdateRequest() { Product = productB });
            var updatedProductB = await client.ReadAsync(new ReadRequest() { Id = 2 });
            Console.WriteLine("Updated Product: " + updatedProductB.Product.Name + " Description:" + updatedProductB.Product.Description);

            await client.DeleteAsync(new DeleteRequest() { Id = productA.Id });
            await client.DeleteAsync(new DeleteRequest() { Id = productB.Id });

            productResponse = await client.ReadAllAsync(new ReadAllRequest());
            foreach (var product in productResponse.Products)
            {
                Console.WriteLine("Updated Product: " + product.Name + " Description:" + product.Description);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
