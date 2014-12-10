namespace Foat.Puzzles.Configuration
{
    using System;
    using System.ComponentModel;
    using System.Configuration;

    public class ParallelIDAStarSettings : ConfigurationSection
    {
        #region Fields

        private const string SectionName = @"Foat.Puzzles.ConfigSection/ParallelIDAStar";
        private const string DefaultNumTasksPropertyName = "MinNumberOfTasks";

        private const int DefaultNumTasks = 1;

        private static readonly ParallelIDAStarSettings SharedDefault = new ParallelIDAStarSettings()
            {
                NumTasks = DefaultNumTasks,
            };

        private static readonly ParallelIDAStarSettings SharedCurrent = (ParallelIDAStarSettings)ConfigurationManager.GetSection(SectionName);

        #endregion

        #region Properties

        [ConfigurationProperty(DefaultNumTasksPropertyName, DefaultValue = DefaultNumTasks, IsRequired = false)]
        public int NumTasks
        {
            get
            {
                return (int)this[DefaultNumTasksPropertyName];
            }
            set
            {
                this[DefaultNumTasksPropertyName] = value;
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