using System;
namespace Random
{
    public static class Normal
    {
        public static double getNormal(double mu, double sigmaSquared){
            return mu + sigmaSquared * Math.Sqrt(-2 * Math.Log(UniformDoublePRNG.NextDouble())) * Math.Cos(2 * Math.PI * UniformDoublePRNG.NextDouble());
        }
    }
}
