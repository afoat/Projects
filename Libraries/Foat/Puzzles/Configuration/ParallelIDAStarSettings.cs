namespace Foat.Puzzles.Configuration
{
    using System;
    using System.ComponentModel;
    using System.Configuration;

    public class ParallelIDAStarSettings : ConfigurationSection
    {
        #region Fields

        private const string SectionName = @"Foat.Puzzles.ConfigSection/ParallelIDAStar";
        private const string DefaultMinNumberOfTasksPropertyName = "MinNumberOfTasks";

        private const int DefaultNumTasks = 1;

        private static readonly ParallelIDAStarSettings SharedDefault = new ParallelIDAStarSettings()
            {
                MinNumberOfTasks = DefaultNumTasks,
            };

        private static readonly ParallelIDAStarSettings SharedCurrent = (ParallelIDAStarSettings)ConfigurationManager.GetSection(SectionName);

        #endregion

        #region Properties

        [ConfigurationProperty(DefaultMinNumberOfTasksPropertyName, DefaultValue = DefaultNumTasks, IsRequired = false)]
        public int MinNumberOfTasks
        {
            get
            {
                return (int)this[DefaultMinNumberOfTasksPropertyName];
            }
            set
            {
                this[DefaultMinNumberOfTasksPropertyName] = value;
            }
        }

        #endregion

        #region Static Properties

        public static ParallelIDAStarSettings Default
        {
            get
            {
                return SharedDefault;
            }
        }

        public static ParallelIDAStarSettings Current
        {
            get
            {
                return SharedCurrent;
            }
        }

        #endregion
    }
}