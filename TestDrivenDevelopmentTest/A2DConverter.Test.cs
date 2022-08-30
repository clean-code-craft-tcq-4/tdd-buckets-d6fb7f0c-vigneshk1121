using System;
using System.Collections.Generic;
using System.Text;
using TestDrivenDevelopment;
using Xunit;

namespace TestDrivenDevelopmentTest
{
   public class A2DConverterTests
    {
        public void TestA2DConversion(A2DConverter a2dConverter, List<int> inputValues, A2DConversionResult expectedResults)
        {
            A2DConversionResult a2dConversionResult = a2dConverter.ConvertAnalogToDigital(inputValues);

            Assert.Equal(a2dConversionResult.PositiveReadings, expectedResults.PositiveReadings);
            Assert.Equal(a2dConversionResult.ErrorReadings, expectedResults.ErrorReadings);
        }
    }
}
