using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rekrutacja_170125.DatabaseContext;

namespace Rekrutacja_170125.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        private readonly ShopContext _context;

        public OrderController(ShopContext context)
        {
            _context = context;
        }


    }
}
