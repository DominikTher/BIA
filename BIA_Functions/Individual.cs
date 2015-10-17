using System;

namespace BIA_Functions
{
    internal class Individual
    {
        public int Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Fitness { get; set; } // Fitness is equal to Z in 4th protocol
    }
}