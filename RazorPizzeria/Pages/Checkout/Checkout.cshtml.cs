using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;
using RazorPizzeria.Services;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string ImageTitle { get; set; }

        private readonly ApplicationDbContext _context;
        private readonly IOrdersService _ordersService;
        public CheckoutModel(ApplicationDbContext context, IOrdersService ordersService)
        {
            _context = context;
            _ordersService = ordersService;
        }


        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom";
            }
            if(string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.BasePrice = PizzaPrice;

            //_context.PizzaOrders.Add(pizzaOrder);
            //_context.SaveChanges();

            _ordersService.AddOrder(pizzaOrder);

            _context.SaveChanges();
        }
    }
}
