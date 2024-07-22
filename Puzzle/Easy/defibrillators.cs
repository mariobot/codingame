using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
     static void Main(string[] args)
        {
            string LON = Console.ReadLine();
            double Longitude = Convert.ToDouble(LON.Replace(',', '.'));
            string LAT = Console.ReadLine();
            double Latitude = Convert.ToDouble(LAT.Replace(',', '.'));
            int N = int.Parse(Console.ReadLine());
            string closestDefib = String.Empty;
            double closestDistance =  double.MaxValue;
            for (int i = 0; i < N; i++)
            {
                string DEFIB = Console.ReadLine();
                string address;
                double distance = closestAddress(Longitude, Latitude, DEFIB, out address);
                if (i == 0)
                {
                    closestDistance = distance;
                    closestDefib = address;
                }
                else if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestDefib = address;
                }
                
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("{0}", closestDefib);
        }

        public static double closestAddress(double ULongitude, double ULatitude, string s, out string address)
        {
            string[] splitAddressandCoords = s.Split(';');
            address = splitAddressandCoords[1];
            double ALongitude = Convert.ToDouble(splitAddressandCoords[splitAddressandCoords.Length - 2].Replace(',', '.'));
            double ALatitude = Convert.ToDouble(splitAddressandCoords[splitAddressandCoords.Length - 1].Replace(',', '.'));
            double distance = findDistance(ULongitude, ULatitude, ALongitude, ALatitude);
            return distance;
        }

        private static double findDistance(double Ulong, double Ulat, double ALong, double ALat)
        {
            double x = (ALong - Ulong) * Math.Cos((Ulat + ALat) / 2);
            double y = (ALat - Ulat);
            double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
            return d;
        }
}