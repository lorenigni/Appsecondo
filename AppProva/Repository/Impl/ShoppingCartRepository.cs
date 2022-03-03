using AppProva.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProva.Repository.Impl
{
    public class ShoppingCartRepository : IShoppinCartRepository
    {

        public List<ShoppingCart> _shoppincharts;

        public ShoppingCartRepository()
        {
            _shoppincharts = new List<ShoppingCart>();
        }

        public ShoppingCartRepository(List<ShoppingCart> shoppincharts)
        {
            _shoppincharts = shoppincharts;
        }

        public List<ShoppingCart> GetAll()
        {
            return _shoppincharts;
        }


        public ShoppingCart Creat(Guid userId)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.UserId = userId;
            cart.Id = Guid.NewGuid();
            _shoppincharts.Add(cart);
            return cart;
        }


        public void Delete(Guid userId)
        {
            try
            {
                if (_shoppincharts.Count > 0)
                {
                    _shoppincharts = _shoppincharts.Where(ShoppingCart => ShoppingCart.UserId != userId).ToList();
                }

            }
            catch (InvalidIdException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        public ShoppingCart GetShoppingcart(Guid userId)
        {

            try
            {
                _shoppincharts = _shoppincharts.Where(x => x.UserId == userId).ToList();
                if (_shoppincharts.Count > 0) { return _shoppincharts[0]; }

            }


            catch (Exception)
            {

            }
            return null;

        }


        public ShoppingCart GetShoppingcartById(Guid shoppincgartId)
        {

            try
            {
                _shoppincharts = _shoppincharts.Where(x => x.Id == shoppincgartId).ToList();
                if (_shoppincharts.Count > 0) { return _shoppincharts[0]; }

            }


            catch (Exception)
            {

            }
            return null;

        }

    }
}
