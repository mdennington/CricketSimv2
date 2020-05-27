using CricketSimv2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CricketSimv2Tests
{
    /// <summary>
    /// Tests for Random Number Singleton
    /// </summary>
    public class testRandom
    {
        [Fact]
        public void test_random_number_range()
        {
            // Test random number generator is in specified range
            IRandomNumberGenerator randomNumberGenerator = new GetRandomNumber();
            var returnNumber = randomNumberGenerator.GetRandomNumber(0, 100);
            Assert.InRange(returnNumber, 0, 100);
        }
    }
}
