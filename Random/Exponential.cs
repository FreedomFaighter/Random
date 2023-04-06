using System;
namespace Random
{
    public static class Exponential
    {
        public static double getExponentialPRNG(double lambda)
        {
            if (lambda <= 0.0)
                return 0.0;

            double next = UniformDoublePRNG.NextDouble();

            while (next == 1.0)
            {
                next = UniformDoublePRNG.NextDouble();
            } 

            return Math.Log(1 - next) / -lambda;
        }
    }
}
