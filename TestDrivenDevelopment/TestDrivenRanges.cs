using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDrivenDevelopment
{
    public static class TestDrivenRanges
    {
        private static SampleValue InitializeValues(List<int> inputs, int index, SampleValue sampleRange)
        {
            sampleRange.LowerRange = sampleRange.UpperRange = inputs[index];
            sampleRange.Rating = 1;
            return sampleRange;
        }

        public static List<string> ProcessSamples(List<int> inputSamples)
        {
            ValidateInputSamples(inputSamples);
            var rangeRatingList = GetRangeAndReadings(inputSamples);
            var output = ProcessCSVOutput(rangeRatingList);
            return PrintOutputSamples(output);
        }

        public static void ValidateInputSamples(List<int> inputSamples)
        {
            if (inputSamples.Any((e) => e < 0))
            {
                throw new InvalidOperationException("Negative values cannot be processed");
            }
            if (inputSamples.Any((e) => e > 100))
            {
                throw new InvalidOperationException("sample values greater than 100 cannot be processed");
            }
        }

        private static List<string> PrintOutputSamples(Dictionary<string, int> output)
        {
            Console.WriteLine("Range", "Ratings");
            var result = new List<string>();
            foreach (var item in output)
            {
                var value = item.Key + ", " + item.Value;
                result.Add(value);
                Console.WriteLine(value);
            }
            return result;
        }

        private static Dictionary<string, int> ProcessCSVOutput(List<SampleValue> sampleValues)
        {
            var value = new Dictionary<string, int>();
            foreach (var item in sampleValues)
            {
                Console.WriteLine(item.LowerRange + "-" + item.UpperRange + ", " + item.Rating);
                value.Add(item.LowerRange + "-" + item.UpperRange, item.Rating);
            }

            return value;
        }

        public static List<SampleValue> GetRangeAndReadings(List<int> inputSample)
        {
            inputSample.Sort();

            var outputSample = new List<SampleValue>();
            var sampleValues = InitializeValues(inputSample, 0, new SampleValue());

           var finalSampleValues = CalculateRangeAndRating(inputSample, sampleValues, outputSample);

            AddSampleRangeAndRatings(outputSample, finalSampleValues);

            return outputSample;
        }

        private static bool CheckIfSampleToBeIncremented(List<int> inputSample, int index, SampleValue sampleValues)
        {
            return inputSample[index] == sampleValues.UpperRange || inputSample[index] == sampleValues.UpperRange + 1;
        }

        private static SampleValue CalculateRangeAndRating(List<int> inputSample, SampleValue sampleValues, List<SampleValue> output)
        {
            for (int index = 1; index < inputSample.Count; index++)
            {
                if (CheckIfSampleToBeIncremented(inputSample, index, sampleValues))
                {
                    sampleValues.UpperRange = inputSample[index];
                    sampleValues.Rating += 1;
                    continue;
                }
                AddSampleRangeAndRatings(output, sampleValues);
                sampleValues = InitializeValues(inputSample, index, new SampleValue());
            }

            return sampleValues;
        }

        private static void AddSampleRangeAndRatings(List<SampleValue> existingSampleRangeList, SampleValue inputElements)
        {
            existingSampleRangeList.Add(new SampleValue
            {
                LowerRange = inputElements.LowerRange,
                UpperRange = inputElements.UpperRange,
                Rating = inputElements.Rating
            });
        }
    }
}
