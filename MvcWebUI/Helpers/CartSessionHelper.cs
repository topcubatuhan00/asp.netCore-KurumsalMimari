using Entities.DomainModels;
using MvcWebUI.Extensions;

namespace MvcWebUI.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
        IHttpContextAccessor _contextAccessor;

        public CartSessionHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor= contextAccessor;
        }


        public void Clear()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }

        public Cart GetCart(string key)
        {
            Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(key);
            if(cartToCheck == null)
            {
                SetCart(key, new Cart());
                cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(key);
            }
            return cartToCheck;
        }

        public void SetCart(string key, Cart cart)
        {
            _contextAccessor.HttpContext.Session.SetObject(key, cart);
        }

        public void SetCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
