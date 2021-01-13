using System;

namespace M3_HW1
{
    delegate double delegateConvertTemperature(double t);

    class TemperatureConvertInp
    {
        public double CelsiusToFahrenheit(double t)
        {
            return (double)9 / 5 * t + 32;
        }

        public double FahrenheitToCelsius(double t)
        {
            return (double)5 / 9 * (t - 32);
        }
    }

    static class StaticTempConverters
    {

        public static double CelsiusToKelvin(double t)
        {
            return t + 273.15;
        }

        public static double KelvinToCelsius(double t)
        {
            return t - 273.15;
        }
        public static double CelsiusToRankin(double t)
        {
            return (double)9 / 5 * t + 491.67;
        }

        public static double RankinToCelsius(double t)
        {
            return (double)5 / 9 * (t - 491.67);
        }
        public static double CelsiusToRéaumur(double t)
        {
            return t / 0.8;
        }

        public static double RéaumurToCelsius(double t)
        {
            return t * 0.8;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConvertInp obj = new TemperatureConvertInp();

            delegateConvertTemperature CtF = obj.CelsiusToFahrenheit;
            delegateConvertTemperature FtC = obj.FahrenheitToCelsius;

            Console.WriteLine($"0 C to F: {CtF?.Invoke(0)}; 0 F to C {FtC?.Invoke(0)}");

            delegateConvertTemperature CtK = StaticTempConverters.CelsiusToKelvin;
            delegateConvertTemperature KtC = StaticTempConverters.KelvinToCelsius;

            delegateConvertTemperature CtR = StaticTempConverters.CelsiusToRankin;
            delegateConvertTemperature RtC = StaticTempConverters.RankinToCelsius;

            delegateConvertTemperature CtRé = StaticTempConverters.CelsiusToRéaumur;
            delegateConvertTemperature RétC = StaticTempConverters.RéaumurToCelsius;

            delegateConvertTemperature[] converters = { CtF, CtK,
                                                        CtR, CtRé
                                                      };

            double t;
            Console.Write("Celsius: ");
            if (double.TryParse(Console.ReadLine(), out t))
            {
                foreach (delegateConvertTemperature cnv in converters)
                {
                    string str = cnv.Method.ToString();
                    Console.WriteLine($"{str.Substring(16, str.Length - 24)}: {cnv?.Invoke(t)}");
                }
            }
            else
            {
                Console.WriteLine("Incorrect Input");
            }
        }
    }
}
