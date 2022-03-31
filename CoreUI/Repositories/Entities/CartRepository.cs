using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUI.Models;
using CoreUI.Repositories.Abstract;
using CoreUI.Repositories.CartRepository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CoreUI.Repositories.CartRepository.Concrete
{
    public class CartRepository : GenericRepository<Cart, CoreDbContext>, ICartRepository
    {
        public Cart GetByUserId(string userId)
        {
            using (var context = new CoreDbContext())
            {
                return context.Carts
                            .Include(i => i.CartItems)
                            .ThenInclude(i => i.ProductNavigation)
                            .ThenInclude(i=>i.LaptopPictures)
                            .FirstOrDefault(i => i.UserId == userId);
            }
        }
           public override void Update(Cart entity)
        {
            using (var context = new CoreDbContext())
            {
               context.Carts.Update(entity);
               context.SaveChanges();
            }
        } 
       
    }
}