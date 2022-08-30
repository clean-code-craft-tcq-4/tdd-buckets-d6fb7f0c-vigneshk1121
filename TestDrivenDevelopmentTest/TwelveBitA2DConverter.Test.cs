using System;
using System.Collections.Generic;
using System.Text;
using TestDrivenDevelopment;
using Xunit;

namespace TestDrivenDevelopmentTest
{
    public class TwelveBitA2DConverter : A2DConverterTests, IA2DConverter
    {
        public A2DConverter GetInstance()
        {
            return new A2DConverter(12, 0, 10);
        }

        [Fact]
        public void GetMaximumAnalogReadingShouldReturn2squareofBitTypeminus2()
        {
            A2DConverter instance = GetInstance();
            Assert.Equal(4094, instance._maximumAnalogReading);
        }

        [Fact]
        public void TestEmptyValues()
        {
            var expectedResult = new A2DConversionResult()
            {
                PositiveReadings = new List<int>(),
                ErrorReadings = new List<int>()
            };
            TestA2DConversion(GetInstance(), new List<int>(), expectedResult);
        }

        [Fact]
        public void TestNullValues()
        {
            var expectedResult = new A2DConversionResult()
            {
                PositiveReadings = new List<int>(),
                ErrorReadings = new List<int>()
            };
            TestA2DConversion(GetInstance(), null, expectedResult);
        }

        [Fact]
        public void TestValidValues()
        {

            TestA2DConversion(GetInstance(), new List<int> { 0, 1 },
                new A2DConversionResult()
                {
                    PositiveReadings = new List<int> { 0, 0 },
                    ErrorReadings = new List<int>()
                });
            TestA2DConversion(GetInstance(), new List<int> { 4081, 4094 },
                new A2DConversionResult()
                {
                    PositiveReadings = new List<int> { 10, 10 },
                    ErrorReadings = new List<int>()
                });

            TestA2DConversion(GetInstance(), new List<int> { 0, 1, 1146, 3127, 4000, 4093, 4094 }, new A2DConversionResult()
            {
                PositiveReadings = new List<int> { 0, 0, 3, 8, 10, 10, 10 },
                ErrorReadings = new List<int>()
            });
        }

        [Fact]
        public void TestErrorValues()
        {
            TestA2DConversion(GetInstance(), new List<int> { 0, 1, 1146, 3127, 4000, 4093, 4094, 4095, 4857 }, new A2DConversionResult()
            {
                PositiveReadings = new List<int> { 0, 0, 3, 8, 10, 10, 10 },
                ErrorReadings = new List<int> { 4095, 4857 }
            });
        }

        [Fact]
        public void CheckIfInputValueIsWithinRange()
        {
            A2DConverter instance = GetInstance();
            Assert.True(instance.IsValueWithinRange(100));
            Assert.False(instance.IsValueWithinRange(4957));
        }
    }
}
