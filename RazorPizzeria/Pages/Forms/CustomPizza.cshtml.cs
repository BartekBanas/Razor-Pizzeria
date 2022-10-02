using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Forms
{
    public class CustomPizzaModel : PageModel
    {
        [BindProperty]
        public PizzasModel Pizza { get; set; }
        public float PizzaPrice { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            PizzaPrice = Pizza.BasePrice;

            if (Pizza.TomatoSauce) PizzaPrice++;
            if (Pizza.Cheese) PizzaPrice++;
            if (Pizza.Pepperoni) PizzaPrice++;
            if (Pizza.Tuna) PizzaPrice++;
            if (Pizza.Pineapple) PizzaPrice += 5;
            if (Pizza.Ham) PizzaPrice++;
            if (Pizza.Beef) PizzaPrice++;

            return RedirectToPage("/Checkout/Checkout", new { Pizza.PizzaName, PizzaPrice });
        }
    }
}
