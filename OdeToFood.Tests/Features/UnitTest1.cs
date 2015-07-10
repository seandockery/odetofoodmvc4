using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//
// A restaurant's overall rating can be calculating using various methods.
// For this application we'll want to try different methods over time,
// but for starters we'll allow an administrator to toggle between two
// different techniques.
//
// 1. Simple mean of the "rating" value for the most recent n reviews
//    (the admin can configure the value n).
//
// 2. Weighted mean of the last n reviews.  The most recent n/2 reviews
//    will be weighted twice as much as the oldest n/2 reviews.
//
// Overall rating should be a whole number.

namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
