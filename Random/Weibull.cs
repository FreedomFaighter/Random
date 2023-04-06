using System;

namespace Random
{
    [Source.Source("https://en.wikipedia.org/wiki/Weibull_distribution")]
    public static class Weibull
    {
        public static double getWeibull(double lambda, double gamma)
        {
            double u = UniformDoublePRNG.NextDouble();

            while (u == Convert.ToDouble(0) || u == Convert.ToDouble(1))
            {
                u = UniformDoublePRNG.NextDouble();
            }

            return Math.Pow(-Math.Log(u), 1 / gamma) / lambda;
        }
    }
}
