using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index([Bind(Prefix="id")]int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.Find(id);
            if (review != null)
            {
                var model = new ReviewEditViewModel
                {
                    Id = review.Id,
                    Rating = review.Rating,
                    Body = review.Body,
                    RestaurantId = review.RestaurantId
                };
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(ReviewEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var review = _db.Reviews.Find(model.Id);
            if (review == null)
            {
                return HttpNotFound();
            }

            review.Rating = model.Rating;
            review.Body = model.Body;
            _db.SaveChanges();

            return RedirectToAction("Index", new { id = review.RestaurantId });
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
