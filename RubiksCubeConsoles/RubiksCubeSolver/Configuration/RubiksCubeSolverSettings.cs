namespace RubiksCubeSolver.Configuration
{
    using System.Configuration;

    public class RubiksCubeSolverSettings : ConfigurationSection
    {
        private const string SectionName = @"RubiksCubeSolver.ConfigSection/Settings";
        private const string PatternSetPathPropertyName = "PatternSetPath";

        private static readonly RubiksCubeSolverSettings SharedCurrent = (RubiksCubeSolverSettings)ConfigurationManager.GetSection(SectionName);

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

        public static RubiksCubeSolverSettings Current
        {
            get
            {
                return SharedCurrent;
            }
        }
    }
}
