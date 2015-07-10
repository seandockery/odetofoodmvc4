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

        public RatingResult ComputeRating(int numberOfReviews)
        {
            var result = new RatingResult();
            result.Rating = (int)_restaurant.Reviews.Average(r => r.Rating);
            return result;
        }

        public RatingResult ComputeWeightedRate(int p)
        {
            var reviews = _restaurant.Reviews.ToArray();
            var result = new RatingResult();
            var counter = 0;
            var total = 0;
            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count() / 2)
                {
                    counter += 2;
                    total += reviews[i].Rating * 2;
                }
                else
                {
                    counter += 1;
                    total += reviews[i].Rating;
                }
            }

            result.Rating = total / counter;
            return result;
        }
    }
}
