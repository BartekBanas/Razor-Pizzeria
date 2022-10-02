using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Services
{
    public interface IOrdersService
    {
        public void AddOrder(PizzaOrder order);
        public void RemoveOrder(PizzaOrder order);
        public PizzaOrder GetOrder(int id);
    }

    public class OrderService : IOrdersService
    {
        private readonly ApplicationDbContext _dbContext;

        //public async Task<TEntity> GetAsync(params object[] guids)
        //{
        //    if (guids.Length == 0)
        //        throw new ArgumentException("No key provided");

        //    var entity = await _dbSet.FindAsync(guids);

        //    return entity;
        //}

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(PizzaOrder order)
        {
            _dbContext.Add(order);
        }

        public PizzaOrder GetOrder(int id)
        {
            //_dbContext.Find(OrderService.)
        }


        public void RemoveOrder(PizzaOrder order)
        {
            _dbContext.Remove(order);

        }
    }
}
