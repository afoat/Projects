﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Foat.Puzzles {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Logging {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Logging() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Foat.Puzzles.Logging", typeof(Logging).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Searching to a maximum depth of - {0:N0}. Last Depth Took: {1} ms..
        /// </summary>
        internal static string IDAStarDepthUpdate {
            get {
                return ResourceManager.GetString("IDAStarDepthUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating new Pattern Set..
        /// </summary>
        internal static string RubiksCreatingPatternSet {
            get {
                return ResourceManager.GetString("RubiksCreatingPatternSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finished generating minimal perfect hash..
        /// </summary>
        internal static string RubiksFinishedGeneratingMPH {
            get {
                return ResourceManager.GetString("RubiksFinishedGeneratingMPH", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finished reading in pattern {0}..
        /// </summary>
        internal static string RubiksFinishedReadingPattern {
            get {
                return ResourceManager.GetString("RubiksFinishedReadingPattern", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found a set of {0:N0} Rubik&apos;s Cubes,  Longest solution is {1:N0}..
        /// </summary>
        internal static string RubiksPatternGenerationFinished {
            get {
                return ResourceManager.GetString("RubiksPatternGenerationFinished", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to W{3:N0} - Cubes: {0:N0} Queue: {1:N0} Max Depth: {2:N0}..
        /// </summary>
        internal static string RubiksPatternGenerationUpdate {
            get {
                return ResourceManager.GetString("RubiksPatternGenerationUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reading in distance map..
        /// </summary>
        internal static string RubiksReadingDistanceMap {
            get {
                return ResourceManager.GetString("RubiksReadingDistanceMap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reading in minimal perfect hash..
        /// </summary>
        internal static string RubiksReadingMPH {
            get {
                return ResourceManager.GetString("RubiksReadingMPH", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reading In Pattern From {0}..
        /// </summary>
        internal static string RubiksReadingPatternFromDisk {
            get {
                return ResourceManager.GetString("RubiksReadingPatternFromDisk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Task {0:N0} Ending..
        /// </summary>
        internal static string TaskEnding {
            get {
                return ResourceManager.GetString("TaskEnding", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Task {0:N0} Starting..
        /// </summary>
        internal static string TaskStarting {
            get {
                return ResourceManager.GetString("TaskStarting", resourceCulture);
            }
        }
    }
}
