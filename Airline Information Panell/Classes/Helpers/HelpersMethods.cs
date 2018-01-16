using System;
using System.Collections.Generic;

namespace AirlineInformationPanell.Classes.Helpers
{
    public sealed class HelpersMethods
    {
        private readonly Random _rundom = new Random();

        public bool StringToDateTime(string value, out DateTime dateTime) => DateTime.TryParse(value, out dateTime);

        private int NumberGenerator() => _rundom.Next(10000, 99999);

        public int NumberGenerator<T>(IDictionary<int, T> type) 
        {
            var genNumber = default(int);
            while (true)
            {
                genNumber = NumberGenerator();
                if (!type.ContainsKey(genNumber))
                    break;
            }

            return genNumber;
        }

    }
}