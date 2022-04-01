using CoreUI.Models;
using CoreUI.Repositories.Abstract;

namespace CoreUI.Repositories.CartRepository.Abstract
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);
        }
        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new Cart() { UserId = userId });
        }

        public void AddToCart(string userId, int productId, byte quantity,int itemPicId)
        {
            var cart = GetCartByUserId(userId);

            if (cart != null)
            {
                // eklenmek isteyen ürün sepette varmı (güncelleme)
                // eklenmek isteyen ürün sepette var ve yeni kayıt oluştur. (kayıt ekleme)
                var index = cart.CartItems.FindIndex(i => i.ProductId==productId);
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id,
                        ItemPicId=itemPicId
                        
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                _cartRepository.Update(cart);

            }
        }

         public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if(cart!=null)
            {
                _cartRepository.DeleteFromCart(cart.Id,productId);
            }   
        }
    }
}