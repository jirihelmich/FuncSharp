﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IEnumerationExtensions
    {
        /// <summary>
        /// Returns all values in the specified bounded interval.
        /// </summary>
        public static IEnumerable<A> Values<A>(this IEnumeration<A> enumeration, Interval<A> interval)
        {
            if (!interval.IsBounded)
            {
                throw new ArgumentException("The specified interval has to be bounded.");
            }
            if (interval.IsEmpty)
            {
                return Enumerable.Empty<A>();
            }

            var values = new List<A>();
            var max = interval.UpperLimit.IsOpen ? interval.UpperBound.Get() : enumeration.Successor(interval.UpperBound.Get());
            var value = interval.LowerLimit.IsOpen ? enumeration.Successor(interval.LowerBound.Get()) : interval.LowerBound.Get();
            while (enumeration.NonEqual(value, max))
            {
                values.Add(value);
                value = enumeration.Successor(value);
            }
            return values;
        }
    }
}
