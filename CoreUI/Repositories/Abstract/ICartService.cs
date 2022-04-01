using CoreUI.Models;

namespace CoreUI.Repositories.CartRepository.Abstract
{
    public interface ICartService
    {


        void InitializeCart(string userId);
        Cart GetCartByUserId(string userId);
        void AddToCart(string userId, int productId, byte quantity,int itemPicId);
        void DeleteFromCart(string userId, int productId);

    }
}