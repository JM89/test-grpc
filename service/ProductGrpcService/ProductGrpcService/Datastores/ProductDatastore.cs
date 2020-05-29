using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductGrpcService
{
    public class ProductDatastore
    {
        private IList<Product> _inMemoryProductList;

        public ProductDatastore()
        {
            _inMemoryProductList = new List<Product>();
        }

        public long Create(Product createdProduct)
        {
            if (_inMemoryProductList.Any(x => x.Id == createdProduct.Id))
            {
                throw new InvalidOperationException("Product already created!");
            }

            _inMemoryProductList.Add(createdProduct);

            return createdProduct.Id;
        }

        public Product Read(long id)
        {
            var existingProduct = _inMemoryProductList.SingleOrDefault(x => x.Id == id);
            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product does not exist!");
            }

            return existingProduct;
        }

        public bool Update(Product updatedProduct)
        {
            var existingProduct = _inMemoryProductList.SingleOrDefault(x => x.Id == updatedProduct.Id);
            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product does not exist!");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;

            return true;
        }

        public bool Delete(long id)
        {
            var existingProduct = _inMemoryProductList.SingleOrDefault(x => x.Id == id);
            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product does not exist!");
            }
            _inMemoryProductList.Remove(existingProduct);

            return true;
        }

        public IList<Product> ReadAll()
        {
            return _inMemoryProductList;
        }
    }
}
