namespace Foat.Hashing.Configuration
{
    using System;
    using System.ComponentModel;
    using System.Configuration;

    public class HashFunctionFactorySettings : ConfigurationSection
    {
        #region Fields

        private const string SectionName = @"Foat.Hashing.ConfigSection/HashFunctionFactory";
        private const string Default32BitHashFunctionTypePropertyName = "HashFunction32BitType";

        private static readonly Type DefaultHashFunction32BitType = typeof(FnvHash);

        private static readonly HashFunctionFactorySettings SharedDefault = new HashFunctionFactorySettings()
            {
                HashFunction32BitType = DefaultHashFunction32BitType,
            };

        private static readonly HashFunctionFactorySettings SharedCurrent = (HashFunctionFactorySettings)ConfigurationManager.GetSection(SectionName);

        #endregion

        #region Properties

        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty(Default32BitHashFunctionTypePropertyName, DefaultValue = null, IsRequired = false)]
        public Type HashFunction32BitType
        {
            get
            {
                return (Type)this[Default32BitHashFunctionTypePropertyName];
            }
            set
            {
                this[Default32BitHashFunctionTypePropertyName] = value;
            }
        }

        #endregion

        #region Static Properties

        public static HashFunctionFactorySettings Default
        {
            get
            {
                return SharedDefault;
            }
        }

        public static HashFunctionFactorySettings Current
        {
            get
            {
                return SharedCurrent;
            }
        }

        #endregion
    }
}