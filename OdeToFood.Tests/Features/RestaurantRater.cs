using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Tests.Features
{
    public class RestaurantRater
    {
        private Restaurant data;

        public RestaurantRater(Restaurant data)
        {
            // TODO: Complete member initialization
            this.data = data;
        }

        public RatingResult ComputeRating(int p)
        {
            var result = new RatingResult();
            result.Rating = 4;
            return result;
        }
    }
}
