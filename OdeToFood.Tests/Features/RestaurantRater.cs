using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests.Features
{
    public class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }

        public RatingResult ComputeResult(IRatingAlgorithm algortithm, int numberOfReviews)
        {
            var filteredReviews = _restaurant.Reviews.Take(numberOfReviews);
            return algortithm.Compute(filteredReviews.ToList());
        }
    }
}
