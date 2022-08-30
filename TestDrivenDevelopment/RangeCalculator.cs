using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopment
{
    public class RangeCalculator
    {
        public List<string> GetCurrentRanges(List<int> analogReadings)
        {
            A2DConverter converter = new A2DConverter(12, 0, 10);
            var result = converter.ConvertAnalogToDigital(analogReadings);
            result.PositiveReadings.ForEach((e) => Math.Abs(e));
            return TestDrivenRanges.ProcessSamples(result.PositiveReadings);
        }
    }
}
