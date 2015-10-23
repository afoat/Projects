namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Hashing;
    using Foat.Puzzles.RubiksCube;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A PatternSet is the set of all cubes that can be reached by twisting an initial cube which
    /// may or may not be masked (i.e. it may or may not have some stickers removed).
    /// </summary>
    public sealed class PatternSet : IXmlSerializable
    {
        #region Fields

        /// <summary>
        /// This is the pattern that the set is based off of. 
        /// 
        /// When the pattern is applied to the solved state we can use the resulting cube
        /// to generate every cube in this pattern set. Alternatively you can apply the
        /// pattern to a random cube in order to project it into this pattern set and do
        /// a lookup.
        /// </summary>
        private Pattern Pattern { get; set; }

        /// <summary>
        /// The minimal perfect hash generated for cubes in this set. This hash can map, in O(1) time,
        /// any cube in this set to an index in the range of 0...N-1 where there are N cubes in the set.
        /// </summary>
        private MinimalPerfectHash<FnvHash> MinimalPerfectHash { get; set; }

        /// <summary>
        /// An array indexed from 0...N-1 that stores the minimum solution distance for the cubes in this set.
        /// </summary>
        private byte[] MinimumSolutionLength { get; set; }

        /// <summary>
        /// The name of this pattern set.
        /// </summary>
        public string Name
        {
            get
            {
                return this.Pattern.Name;
            }
        }

        #endregion

        #region Construction

        public PatternSet()
        {
        }

        public PatternSet(ConcurrentDictionary<RubiksCube, byte> cubeSolutionDistanceMap, MinimalPerfectHash<FnvHash> minimalPerfectHash, Pattern pattern)
        {
            if (cubeSolutionDistanceMap == null)
            {
                throw new ArgumentNullException("cubeSolutionDistanceMap");
            }

            if (minimalPerfectHash == null)
            {
                throw new ArgumentNullException("minimalPerfectHash");
            }

            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            this.Pattern = pattern;
            this.MinimalPerfectHash = minimalPerfectHash;
            this.MinimumSolutionLength = new byte[cubeSolutionDistanceMap.Count];

            foreach (KeyValuePair<RubiksCube, byte> rubiksCubeAndDepth in cubeSolutionDistanceMap)
            {
                this.MinimumSolutionLength[this.MinimalPerfectHash.GetHashCode(rubiksCubeAndDepth.Key.GetBytes())] = rubiksCubeAndDepth.Value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method provides an estimated number of moves to solve the given cube. The estimate is
        /// a lower bound in that the actual number of moves required to solve the cube will always
        /// be at least this much.
        /// </summary>
        /// <param name="cube">The RubiksCube that we would like to have an estimated solution length for.</param>
        /// <returns></returns>
        public byte GetEstimatedSolutionLength(RubiksCube cube)
        {
            RubiksCube maskedCube = cube.ApplyMask(this.Pattern.Mask);
            int index = this.MinimalPerfectHash.GetHashCode(maskedCube.GetBytes());
            return this.MinimumSolutionLength[index];
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Reads the PatternSet from the given XmlReader
        /// </summary>
        public void ReadXml(XmlReader reader)
        {
            if (!reader.IsStartElement("PatternSet"))
            {
                throw new InvalidOperationException();
            }
            else
            {
                reader.ReadStartElement("PatternSet");

                XmlSerializer serializer = new XmlSerializer(typeof(Pattern));
                this.Pattern = (Pattern)serializer.Deserialize(reader);

                serializer = new XmlSerializer(typeof(byte[]));
                reader.ReadStartElement("DistanceMap");
                this.MinimumSolutionLength = (byte[])serializer.Deserialize(reader);
                reader.ReadEndElement();

                DataContractSerializer contractSerializer = new DataContractSerializer(typeof(MinimalPerfectHash<FnvHash>));
                this.MinimalPerfectHash = (MinimalPerfectHash<FnvHash>)contractSerializer.ReadObject(reader);

                reader.ReadEndElement();
            }
        }

        /// <summary>
        /// Writes the PatternSet to the given XmlWriter.
        /// </summary>
        public void WriteXml(XmlWriter writer)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Pattern));
            serializer.Serialize(writer, this.Pattern);
            
            serializer = new XmlSerializer(typeof(byte[]));
            writer.WriteStartElement("DistanceMap");
            serializer.Serialize(writer, this.MinimumSolutionLength);
            writer.WriteEndElement();

            serializer = null;

            DataContractSerializer contractSerializer = new DataContractSerializer(typeof(MinimalPerfectHash<FnvHash>));
            contractSerializer.WriteObject(writer, this.MinimalPerfectHash);
        }

        /// <summary>
        /// Saves the PatternSet to the provided path in XML format.
        /// </summary>
        public void Save(string outputFolder)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PatternSet));

            string file = string.Format(@"{0}\{1}.xml", outputFolder, this.Name);

            using (StreamWriter writer = new StreamWriter(file))
            {
                serializer.Serialize(writer, this);
            }
        }

        #endregion
    }
}
