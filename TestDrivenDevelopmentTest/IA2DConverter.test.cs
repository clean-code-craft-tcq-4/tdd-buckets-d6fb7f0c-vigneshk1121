using System;
using System.Collections.Generic;
using System.Text;
using TestDrivenDevelopment;

namespace TestDrivenDevelopmentTest
{
    public interface IA2DConverter
    {
        A2DConverter GetInstance();

        void GetMaximumAnalogReadingShouldReturn2squareofBitTypeminus2();

        void TestEmptyValues();

        void TestNullValues();

        void TestValidValues();

        void TestErrorValues();

    }
}
