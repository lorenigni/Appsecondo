using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AppProva.Entities;
using AppProva.Repository;
using AppProva.Repository.Impl;

namespace AppProvaTest
{
    public class ProductRepositoryServiceTest
    {
        [Fact]
        public void Delete_ShouldWork()
        {
            Product product = new Product() {Id = Guid.NewGuid()};    
            List<Product> products = new List<Product>() { product };
            ProductRepository p = new ProductRepository(products);
            p.Delete(product.Id);
            Assert.True(p._products.Count == 0);
        }



        [Fact]
        public void Update_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            List<Product> products = new List<Product>() { product };
            ProductRepository p = new ProductRepository(products);
            p.Update(product.Id);
            Assert.True(product.Cost == 10);


        }



        [Fact]
        public void Insert_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            List<Product> products = new List<Product>() {};
            ProductRepository p = new ProductRepository(products);
            p.Insert(product);
            Assert.Contains<Product>(product, p._products);

        }


        [Fact]
        public void getAll_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            List<Product> products = new List<Product>() { product};
            ProductRepository p = new ProductRepository(products);
            Assert.Contains(product, (p.GetAll()));

        }

        [Fact]
        public void GetProduct_ShouldWork()
        {
            Product product = new Product() { Id = Guid.NewGuid() };
            List<Product> products = new List<Product>() { product };
            ProductRepository productRepository = new ProductRepository(products);
            Assert.NotNull(productRepository.GetProduct(product.Id));

        }
    }
}
