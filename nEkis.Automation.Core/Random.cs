using System;
using System.Security.Cryptography;

namespace nEkis.Automation.Core
{
    public class SafeRandom
    {
        private static RNGCryptoServiceProvider CryptoProvider { get; set; } = new RNGCryptoServiceProvider();

        /// <summary>
        /// Generates randomly 0 or 1
        /// </summary>
        /// <returns>Number 0 or 1</returns>
        public static int Next()
        {
            var data = new byte[sizeof(int)];
            CryptoProvider.GetBytes(data);
            return BitConverter.ToInt32(data, 0) & (int.MaxValue - 1);
        }

        /// <summary>
        /// Generates random number between 0 and given value
        /// </summary>
        /// <param name="max">Maximum value (exclusive)</param>
        /// <returns>Number between 0 and given value</returns>
        public static int Next(int max)
        {
            return Next(0, max);
        }

        /// <summary>
        /// Generates random number between given values
        /// </summary>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (exclusive)</param>
        /// <returns>Number between given values</returns>
        public static int Next(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException("Min value has to be smaller than max value");
            }
            return (int)Math.Floor((min + ((double)max - min) * NextDouble()));
        }

        /// <summary>
        /// Generates random number between 0 and 1
        /// </summary>
        /// <returns>Number between 0.0 and 1.0</returns>
        public static double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            CryptoProvider.GetBytes(data);
            var randUint = BitConverter.ToUInt32(data, 0);
            return randUint / (uint.MaxValue + 1.0);
        }

        // Thank you Eldar Agalarov @ https://stackoverflow.com/users/2449744/eldar-agalarov
    }
}
