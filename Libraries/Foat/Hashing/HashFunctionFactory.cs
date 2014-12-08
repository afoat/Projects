namespace Foat.Hashing
{
    using Foat.Hashing.Configuration;
    using System;

    public static class HashFunctionFactory
    {
        private static IHashFunction32Bit Shared32BitHashFunction;

        public static IHashFunction32Bit Default32BitHashFunction
        {
            get
            {
                if (Shared32BitHashFunction == null)
                {
                    Type hashFunctionType;
                    if (HashFunctionFactorySettings.Current != null)
                    {
                        hashFunctionType = HashFunctionFactorySettings.Current.HashFunction32BitType;
                    }
                    else
                    {
                        hashFunctionType = HashFunctionFactorySettings.Default.HashFunction32BitType;
                    }

                    Shared32BitHashFunction = (IHashFunction32Bit)Activator.CreateInstance(hashFunctionType);
                }

                return Shared32BitHashFunction;
            }
        }
    }
}
