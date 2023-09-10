using Microsoft.AspNetCore.Mvc;

namespace CookiesAndMilk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        [HttpGet("FavoriteMilkshake")]
        public string Get(string favoriteMilkshake)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddMinutes(20);
            Response.Cookies.Append("favoriteMilkshake", favoriteMilkshake, cookieOptions);
            return favoriteMilkshake;
        }

        [HttpPost]
        [Route("[action]")]
        public string GetFromCookie()
        {
            if (Request.Cookies["favoriteMilkshake"] != null)
            {
                return Request.Cookies["favoriteMilkshake"];
            }
            else
                return "unknown";
        }

        [HttpGet]
        [Route("[action]")]
        public void DeleteCookie()
        {
            if (Request.Cookies["favoriteMilkshake"] != null)
            {
                Response.Cookies.Delete("favoriteMilkshake");
            }
        }
    }
}
