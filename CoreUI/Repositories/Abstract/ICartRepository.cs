using CoreUI.Models;
using CoreUI.Repositories.Abstract;

namespace CoreUI.Repositories.CartRepository.Abstract
{

    public interface ICartRepository : IGenericRepository<Cart>
    {
        Cart GetByUserId(string userId);
        void DeleteFromCart(int cartId, int productId);
    }
}