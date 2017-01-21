using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericTypeExtensions
{
    public static class Extensions
    {
        public static float Remap(this float value, float oldMin, float oldMax, float newMin, float newMax) {
            var rel = (value - oldMin) / (oldMax - oldMin);
            return newMin + (newMax - newMin) * rel;
        }
    }
}
