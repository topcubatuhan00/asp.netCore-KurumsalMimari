using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null) {
                cartLine.quantity++;
                return;
            }
            else
            {
                cart.CartLines.Add(new CartLine { Product = product, quantity = 1 });
            }
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            
            if(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId).quantity == 1)
                cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
            else
                cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId).quantity -= 1;
        }
    }
}
