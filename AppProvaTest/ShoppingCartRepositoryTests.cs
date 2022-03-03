using AppProva.Entities;
using AppProva.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppProvaTest
{
    public class ShoppingCartRepositoryTests
    {
        [Fact]
        public void Insert_ShouldWork()
        {
            ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() {};
            ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository(shoppingcarts);
            shoppingCartRepository.Creat(s.UserId);
            Assert.True(shoppingCartRepository._shoppincharts.Count > 0);
        }
      
        [Fact]
        public void Delete_ShouldWork()
        {
            ShoppingCart s = new ShoppingCart() { UserId = Guid.NewGuid() };
            List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() {s};
            ShoppingCartRepository shop = new ShoppingCartRepository(shoppingcarts);
            shop.Delete(s.UserId);
            Assert.True(shop._shoppincharts.Count == 0);

        }

        [Fact]
        public void Get_ShouldGet()
        {
            ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() { s };
            ShoppingCartRepository shop = new ShoppingCartRepository(shoppingcarts);
            shop.GetShoppingcart(s.UserId);
            Assert.NotNull(shop.GetShoppingcart(s.UserId));

        }


        [Fact]
        public void GetShoppinCartById_ShouldWork()
        {
            ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() { s };
            ShoppingCartRepository shop = new ShoppingCartRepository(shoppingcarts);
            shop.GetShoppingcartById(s.Id);
            Assert.NotNull(shop.GetShoppingcartById(s.Id));
        }


        [Fact]
        public void GetShoppinCartById_ShouldFail()
        {
            ShoppingCart s = new ShoppingCart() { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            List<ShoppingCart> shoppingcarts = new List<ShoppingCart>() { s };
            ShoppingCartRepository shop = new ShoppingCartRepository(shoppingcarts);
            shop.GetShoppingcartById(Guid.NewGuid());
            Assert.Null(shop.GetShoppingcartById(s.Id));
        }




    }
}
