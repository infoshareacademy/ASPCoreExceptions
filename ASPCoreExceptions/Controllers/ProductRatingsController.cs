using ASPCoreExceptions.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreExceptions.Controllers
{
    public class ProductRatingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RateProduct(int productId, int rating = 6, int userId = 1)
        {
            if (rating < 1 || rating > 5)
            {
                var error = new InvalidRatingException(rating, userId);
                TempData["Error"] = error;
                throw error;
            }

            return View("index");
        }
    }
}
