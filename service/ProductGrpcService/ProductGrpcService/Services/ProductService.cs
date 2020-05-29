using Grpc.Core;
using System.Threading.Tasks;

namespace ProductGrpcService
{
    public class ProductService : ProductServiceDefinition.ProductServiceDefinitionBase
    {
        private readonly ProductDatastore _inMemoryDatastore;

        public ProductService(ProductDatastore inMemoryDatastore)
        {
            _inMemoryDatastore = inMemoryDatastore;
        }

        public override Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {
            var productId = _inMemoryDatastore.Create(request.Product);

            return Task.FromResult(new CreateResponse
            {
                Id = productId
            });
        }

        public override Task<ReadResponse> Read(ReadRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ReadResponse
            {
                Product = _inMemoryDatastore.Read(request.Id)
            });
        }

        public override Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
        {
            var result = _inMemoryDatastore.Update(request.Product);

            return Task.FromResult(new UpdateResponse
            {
                Updated = result == true ? 1 : 0
            });
        }

        public override Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            var result = _inMemoryDatastore.Delete(request.Id);

            return Task.FromResult(new DeleteResponse
            {
                Deleted = result == true ? 1 : 0
            });
        }

        public override Task<ReadAllResponse> ReadAll(ReadAllRequest request, ServerCallContext context)
        {
            var products = _inMemoryDatastore.ReadAll();
            return Task.FromResult(new ReadAllResponse
            {
                Products = { products }
            });
        }
    }
}
