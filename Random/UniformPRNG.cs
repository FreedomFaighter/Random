using System;

namespace Random
{
    public static class UniformDoublePRNG
    {
        private static System.Random PRNGUni = new System.Random();

        [Source.Source("https://docs.microsoft.com/en-us/dotnet/api/system.random?view=net-5.0")]
        [Source.Source("https://docs.microsoft.com/en-us/dotnet/api/system.random.nextdouble?view=net-5.0")]
        public static double NextDouble()
        {
            return UniformDoublePRNG.PRNGUni.NextDouble();
        }
    }
}
