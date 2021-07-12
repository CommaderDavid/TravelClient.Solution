
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace TravelClient.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            List<Review> allReviews = Review.GetReviews();
            return View(allReviews);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Review review)
        {
            await Review.Post(review);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Review review = Review.GetDetails(id);
            return View(review);
        }

        public IActionResult Edit(int id)
        {
            // Review reviewToEdit = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
            // //Grabs the Review in the database by Id
            // if (review.UserName == reviewToEdit.UserName)
            Review review = Review.GetDetails(id);
            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id, Review review)
        {
            review.ReviewId = id;
            await Review.Put(review);
            return RedirectToAction("Details", id);
        }

        public async Task<IActionResult> Delete(int id)
        {
            // Review reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
            // if (reviewToDelete.UserName == review.UserName)
            await Review.Delete(id);
            return RedirectToAction("Index");
        }
    }
}