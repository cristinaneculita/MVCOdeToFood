using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult Index(string searchTerm = null)
        {
            var model = _db.Restaurants
                .OrderByDescending(it => it.Reviews.Average(review => review.Rating))
                .Where (r=> searchTerm==null || r.Name.StartsWith(searchTerm))
                .Select(rest => new RestaurantListViewModel
            {
                Id = rest.Id, Name = rest.Name, City = rest.City, Country = rest.Country, CountOfReviews = rest.Reviews.Count()
            }).ToList();


            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Scott";
            model.Location = "Maryland, USA";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
