using System;
using System.Collections.Generic;
using TestDrivenDevelopment;
using Xunit;

namespace TestDrivenDevelopmentTest
{
    public class TestDrivenDevelopment
    {
        [Fact]
        public void PrintCSVFormatOfTwoRanges()
        {
            var value = new List<int> { 4, 5 };
            var result = TestDrivenRanges.ProcessSamples(value);
            foreach (var item in result)
            {
                Assert.Equal("4-5, 2", item);
            }
        }

        [Fact]
        public void PrintCSVFormatFOrMultipleRanges()
        {
            var value = new List<int> { 3, 3, 5, 4, 10, 11, 12 };
            var result = TestDrivenRanges.ProcessSamples(value);
            Assert.Equal("3-5, 4", result[0]);
            Assert.Equal("10-12, 3", result[1]);
        }

        [Fact]
        public void GetRangeAndReadingsForTwoInputValues()
        {
            var value = new List<int> { 4,5 };
            var result = TestDrivenRanges.GetRangeAndReadings(value);
            foreach (var item in result)
            {
                Assert.Equal(4, item.LowerRange);
                Assert.Equal(5, item.UpperRange);
                Assert.Equal(2, item.Rating);
            }
        }

        [Fact]
        public void GetRangeAndReadingsForMultipleInputValues()
        {
            var value = new List<int> { 3, 3, 5, 4, 10, 11, 12 };
            var result = TestDrivenRanges.GetRangeAndReadings(value);
            Assert.Equal(2, result.Count);
            Assert.Equal(3, result[0].LowerRange);
            Assert.Equal(5, result[0].UpperRange);
            Assert.Equal(4, result[0].Rating);
            Assert.Equal(10, result[1].LowerRange);
            Assert.Equal(12, result[1].UpperRange);
            Assert.Equal(3, result[1].Rating);
        }

        [Fact]
        public void ThrowExceptionIfValueIsNegartive()
        {
            var value = new List<int> { 4, 5, -1 };

            Action act = () => TestDrivenRanges.ProcessSamples(value);
            //assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);

            Assert.Equal("Negative values cannot be processed", exception.Message);
        }

        [Fact]
        public void ThrowExceptionIfValueIsGreaterThan100()
        {
            var value = new List<int> { 4, 5, 3, 10, 15, 101 };

            Action act = () => TestDrivenRanges.ProcessSamples(value);
            //assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);

            Assert.Equal("sample values greater than 100 cannot be processed", exception.Message);
        }
    }
}
