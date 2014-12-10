namespace Foat.Hashing.Configuration
{
    using System.Configuration;

    public class Settings : ConfigurationSectionGroup
    {
        private const string ConfigSectionName = "Foat.Hashing.ConfigSection";
        private const string MinimalPerfectHashSettingsPropertyName = "MinimalPerfectHash";
        private const string HashFunctionFactorySettingsPropertyName = "HashFunctionFactory";

        #region Singleton Members

        private static Settings ConfigurationSettings;

        /// <summary>
        /// A singleton constructor that returns a reference to the settings class
        /// </summary>
        /// <returns>A reference to the settings class</returns>
        public static Settings CreateSettings()
        {
            if (ConfigurationSettings == null)
            {
                ConfigurationSettings = (Settings)ConfigurationManager.AppSettings.GetSection(ConfigSectionName);
            }

            if (ConfigurationSettings == null)
            {
                ConfigurationSettings = new Settings();
            }

            return ConfigurationSettings;
        }

        #endregion
        
        [ConfigurationProperty(HashFunctionFactorySettingsPropertyName, DefaultValue=null)]
        public HashFunctionFactorySettings HashFunctionFactorySettings
        {
            get
            {
                return (HashFunctionFactorySettings)base.Sections[HashFunctionFactorySettingsPropertyName];
            }
        }

        [ConfigurationProperty(MinimalPerfectHashSettingsPropertyName, DefaultValue = null)]
        public MinimalPerfectHashSettings MinimalPerfectHashSettings
        {
            get
            {
                return (MinimalPerfectHashSettings)base.Sections[MinimalPerfectHashSettingsPropertyName];
            }
        }
    }
}
