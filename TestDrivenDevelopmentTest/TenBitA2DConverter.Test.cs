using System;
using System.Collections.Generic;
using System.Text;
using TestDrivenDevelopment;
using Xunit;

namespace TestDrivenDevelopmentTest
{
    public class TenBitA2DConverter : A2DConverterTests, IA2DConverter
    {
        public A2DConverter GetInstance()
        {
            return new A2DConverter(10, -15, 15);
        }

        [Fact]
        public void GetMaximumAnalogReadingShouldReturn2squareofBitTypeminus2()
        {
            A2DConverter instance = GetInstance();
            Assert.Equal(1022, instance._maximumAnalogReading);
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
        public void TestErrorValues()
        {
            TestA2DConversion(GetInstance(), new List<int> { 0, 1, 120, 240, 300, 400, 1022, 1365, 3836 }, new A2DConversionResult()
            {
                PositiveReadings = new List<int> { -15, -15, -11, -8, -6, -3, 15 },
                ErrorReadings = new List<int> {  1365, 3836}
            });
        }

        [Fact]
        public void TestValidValues()
        {
            TestA2DConversion(GetInstance(), new List<int> { 0, 1 },
                            new A2DConversionResult()
                            {
                                PositiveReadings = new List<int> { -15, -15 },
                                ErrorReadings = new List<int>()
                            });
            TestA2DConversion(GetInstance(), new List<int> { 0, 0, 1, 15, 1000, 1022 },
                new A2DConversionResult()
                {
                    PositiveReadings = new List<int> { -15, -15, -15, -15, 14, 15 },
                    ErrorReadings = new List<int>()
                });

            TestA2DConversion(GetInstance(), new List<int> { 0, 1, 120, 240, 300, 400, 1022 }, new A2DConversionResult()
            {
                PositiveReadings = new List<int> { -15, -15, -11, -8, -6, -3, 15 },
                ErrorReadings = new List<int>()
            });
        }
    }
}
