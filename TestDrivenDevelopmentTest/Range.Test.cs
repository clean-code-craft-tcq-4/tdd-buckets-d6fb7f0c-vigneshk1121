using System;
using System.Collections.Generic;
using System.Text;
using TestDrivenDevelopment;
using Xunit;

namespace TestDrivenDevelopmentTest
{
    public class RangeTest
    {
        [Fact]
        public void GetCurrentRangeFromAnalogInput()
        {
            RangeCalculator range = new RangeCalculator();
            var result = range.GetCurrentRanges(new List<int>{ 0, 1, 1146, 3127, 4000, 4093, 4094});
            Assert.Equal("0-0, 2", result[0]);
            Assert.Equal("3-3, 1", result[1]);
            Assert.Equal("8-8, 1", result[2]);
            Assert.Equal("10-10, 3", result[3]);
        }
    }
}
