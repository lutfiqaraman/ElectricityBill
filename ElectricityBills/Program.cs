using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBills
{
    class Program
    {
        static void Main(string[] args)
        {
            const double meterFee = 0.2;
            const double tvFee    = 1.000;

            double numberofRanges;
            double consumptionValue = 0;
            double fuelDiff         = 0;
            
            double ruralFees;
            double wasteFees;
            double total;

            string reading = Console.ReadLine();
            int meter      = Convert.ToInt32(reading);


            List<KeyValuePair<int, int>> slides = new List<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int>(1, 160),
                new KeyValuePair<int, int>(161, 300),
                new KeyValuePair<int, int>(301, 500),
                new KeyValuePair<int, int>(501, 600),
                new KeyValuePair<int, int>(601, 750),
                new KeyValuePair<int, int>(751, 1000)
            };

            List<int> ranges = new List<int>();

            foreach (var item in slides)
            {
                ranges.Add((item.Value - item.Key) + 1);
            }

            List<int> fees = new List<int>() { 33, 72, 86, 114, 158, 188 };

            ruralFees = (double)(meter * 1) / 1000;
            numberofRanges = ranges.Count();

            if (meter <= 200)
            {
                wasteFees = (double)20.0 / 12.0;
            }
            else
            {
                double factor1 = (double)(20.0 / 12.0);
                double factor2 = (double)((meter - 200) * 5) / 1000;

                wasteFees = factor1 + factor2;
            }

            if (meter > 300)
            {
                fuelDiff = (double)(meter * 10) / 1000;
            }

            
            if (meter <= ranges[0])
            {
                consumptionValue = (double)(meter * fees[0]) / 1000;

                if (meter <= 53)
                    consumptionValue = 1.75;
                
                meter = 0;
            }

            if (meter > 1000)
            {
                int extraMeter = meter - 1000;
                consumptionValue = (extraMeter * 265) / 1000;
            }

            if (meter != 0)
            {
                for (int i = 0; i < numberofRanges; i++)
                {
                    if (meter >= ranges[i])
                    {
                        meter -= ranges[i];
                        consumptionValue += (double)(ranges[i] * fees[i]) / 1000;
                    }
                    else
                    {
                        consumptionValue += (double)(meter * fees[i]) / 1000;
                        break;
                    }
                }
            }


            total = (double) consumptionValue + tvFee + meterFee + ruralFees + fuelDiff +  wasteFees;

            Console.WriteLine("Consumption Value: {0}", Math.Round(consumptionValue, 3));
            Console.WriteLine("Fuel Difference: {0}", Math.Round(fuelDiff, 3));
            Console.WriteLine("Meter Fees: {0}", Math.Round(meterFee,3));
            Console.WriteLine("Rural Fees: {0}", Math.Round(ruralFees,3));
            Console.WriteLine("TV Fees: {0}", Math.Round(tvFee,3));
            Console.WriteLine("Waste Fees: {0}", Math.Round(wasteFees,3));
            Console.WriteLine("Total: {0}", Math.Round(total,3));

            Console.ReadKey();
        }
    }
}
