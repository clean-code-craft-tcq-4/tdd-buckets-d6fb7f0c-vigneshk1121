using System;
using System.Collections.Generic;

namespace TestDrivenDevelopment
{
    public class A2DConverter
    {
        public readonly int _minimumDigitalReading;
        public readonly int _maximumDigitalReading;
        public readonly int _minimumAnalogReading;
        public readonly int _maximumAnalogReading;


        public A2DConverter(int bitType, int minumumDigitalReading, int maximumDigitalReading)
        {
            _minimumDigitalReading = Math.Abs(minumumDigitalReading);
            _maximumDigitalReading = Math.Abs(maximumDigitalReading);

            _minimumAnalogReading = 0;
            _maximumAnalogReading = Math.Abs(GetMaximumAnalogReading(bitType));
        }

        public int GetMaximumAnalogReading(int bitType)
        {
            return (int)Math.Pow(2, bitType) - 2;
        }

        public A2DConversionResult ConvertAnalogToDigital(List<int> analogReadings)
        {
            var conversionResult = new A2DConversionResult();
            conversionResult.PositiveReadings = new List<int>();
            conversionResult.ErrorReadings = new List<int>();

            if (analogReadings != null)
            {
                foreach (var reading in analogReadings)
            {
                    GetDigitalReadingsList(reading, conversionResult);
                }
            }
            return conversionResult;
        }

        private void GetDigitalReadingsList(int analogReading, A2DConversionResult conversionResult)
        {

            if (IsValueWithinRange(analogReading))
            {
                conversionResult.PositiveReadings.Add(GetDigitalReading(analogReading));
            }
            else
            {
                conversionResult.ErrorReadings.Add(analogReading);
            }
        }

        public bool IsValueWithinRange(int inputValue)
        {
            if (inputValue >= _minimumAnalogReading && inputValue <= _maximumAnalogReading)
            {
                return true;
            }
            return false;
        }

        private int GetDigitalReading(int analogReading)
        {
            float digitalReading = ((analogReading / GetTotalAnalogReading()) * GetTotalDigitalReading()) - _minimumDigitalReading;
            return (int)Math.Round(digitalReading);
        }

        private float GetTotalAnalogReading()
        {
            return _maximumAnalogReading + _minimumAnalogReading;
        }

        private float GetTotalDigitalReading()
        {
            return _minimumDigitalReading + _maximumDigitalReading;
        }
    }
}
