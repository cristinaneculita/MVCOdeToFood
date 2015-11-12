using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        //
        // GET: /Reviews/

        public ActionResult Index()
        {
            var model = _reviews.OrderBy(it => it.Rating);
            return View(model);
           
        }

        //
        // GET: /Reviews/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Reviews/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Reviews/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Reviews/Edit/5

        public ActionResult Edit(int id)
        {
            var review = _reviews.Single(it => it.Id == id);
            return View(review);
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _reviews.Single(it => it.Id == id);
            if (TryUpdateModel(review))
            {
                //save into db
                return RedirectToAction("Index");
            }
            return View(review);

        }

        //
        // GET: /Reviews/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    var review = _reviews.Single(it => it.Id == id);
        //    return View(review);
        //}

        ////
        //// POST: /Reviews/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        private static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview
            {
                Id = 1,
                Name = "Buenavista",
                City = "Iasi",
                Country = "Romania",
                Rating = 7,
            },
            new RestaurantReview
            {
                Id = 2,
                Name = "Toujours",
                City = "Iasi",
                Country = "Usa",
                Rating = 10,
            },
            new RestaurantReview
            {
                Id = 3,
                Name = "McDonalds",
                City = "Iasi",
                Country = "France",
                Rating = 9,
            }
        };
        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var bestReview = _reviews.OrderByDescending(it=>it.Rating);
            return PartialView("_Review", bestReview.First());
        }
    }
}
