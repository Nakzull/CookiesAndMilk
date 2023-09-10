using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookiesAndMilk.Controllers
{
    [Route("shopping/[controller]")]
    [ApiController]
    public class ShoppingCartContoller : Controller
    {
        [HttpPost("AddProduct")]
        public ActionResult Add([FromBody] Product product)
        {
            if (product.Price >= 0 && product.Price < 10)
            {
                List<Product> cart = HttpContext.Session.GetObjectFromJson<List<Product>>("Cart") ?? new List<Product>();
                cart.Add(product);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                return Ok();
            }
            return BadRequest("You need to enter a price in numbers");
        }

        [HttpGet("GetCart")]
        public List<Product> Get()
        {
            return HttpContext.Session.GetObjectFromJson<List<Product>>("Cart");
        }

        [HttpPost("RemoveProduct")]
        public void SetSession([FromBody] Product product)
        {
            List<Product> cart = HttpContext.Session.GetObjectFromJson<List<Product>>("Cart");
            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].Name == product.Name && cart[i].Price == product.Price)
                    {
                        cart.RemoveAt(i);
                    }
                    HttpContext.Session.SetObjectAsJson("Cart", cart);
                }
            }
        }
    }
}

