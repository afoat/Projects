namespace RubiksCubePatternSetGenerator.Configuration
{
    using System.Configuration;

    public class RubiksCubePatternSetGeneratorSettings : ConfigurationSection
    {
        #region Fields

        private const string SectionName = @"RubiksCubePatternSetGenerator.ConfigSection/Settings";

        private const string PatternSetPathPropertyName = @"PatternSetPath";
        private const string NumberOfPatternGeneratingThreadsPropertyName = @"NumberOfPatternGeneratingThreads";

        private static readonly RubiksCubePatternSetGeneratorSettings SharedDefault = new RubiksCubePatternSetGeneratorSettings();

        private static readonly RubiksCubePatternSetGeneratorSettings SharedCurrent = (RubiksCubePatternSetGeneratorSettings)ConfigurationManager.GetSection(SectionName);

        #endregion

        #region Properties

        /// <summary>
        /// The pattern set path stores the path of the folder where all of the patterns will be stored and loaded from.
        /// </summary>
        [ConfigurationProperty(PatternSetPathPropertyName, DefaultValue = null, IsRequired = true)]
        public string PatternSetPath
        {
            get
            {
                return (string)this[PatternSetPathPropertyName];
            }
            set
            {
                this[PatternSetPathPropertyName] = value;
            }
        }

        [ConfigurationProperty(NumberOfPatternGeneratingThreadsPropertyName, DefaultValue = 1, IsRequired = true)]
        public int NumberOfPatternGeneratingThreads
        {
            get
            {
                return (int)this[NumberOfPatternGeneratingThreadsPropertyName];
            }
            set
            {
                this[NumberOfPatternGeneratingThreadsPropertyName] = value;
            }
        }
        
        #endregion

        #region Static Properties

        public static RubiksCubePatternSetGeneratorSettings Default
        {
            get
            {
                return SharedDefault;
            }
        }

        public static RubiksCubePatternSetGeneratorSettings Current
        {
            get
            {
                return SharedCurrent;
            }
        }

        #endregion
    }
}
