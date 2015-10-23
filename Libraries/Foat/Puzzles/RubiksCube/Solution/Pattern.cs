namespace Foat.Puzzles.RubiksCube.Solution
{
    using Foat.Puzzles.RubiksCube;
    using System;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A pattern contains the information necesssary to generate a pattern set. This includes a 
    /// rubiks cube with some stickers taken off (the mask) and some information about the 
    /// expected size and shape of the set that this mask generates.
    /// </summary>
    public sealed class Pattern : IXmlSerializable
    {
        public Pattern()
        {
        }

        public Pattern(string name, int groupSize, int maxDepth, RubiksCube mask)
        {
            this.Name = name;
            this.GroupSize = groupSize;
            this.Mask = mask;
            this.MaxDepth = maxDepth;
        }

        /// <summary>
        /// The name of the pattern set.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The size of the PatternSet that would be defined by twisting the original
        /// masked RubiksCube until all possible cubes in the set have been found.
        /// </summary>
        public Int32 GroupSize { get; private set; }

        /// <summary>
        /// The masked RubiksCube that defines the Pattern.
        /// </summary>
        public RubiksCube Mask { get; private set; }

        /// <summary>
        /// The maximum solution depth of any possible cube in this pattern.
        /// </summary>
        public int MaxDepth { get; private set; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Reads the pattern from the given XmlReader.
        /// </summary>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (!reader.IsStartElement("Pattern"))
            {
                throw new InvalidOperationException();
            }
            else
            {
                Name = reader.GetAttribute("Name");
                GroupSize = int.Parse(reader.GetAttribute("GroupSize"));
                MaxDepth = int.Parse(reader.GetAttribute("MaxDepth"));
                reader.ReadStartElement("Pattern");

                XmlSerializer serializer = new XmlSerializer(typeof(RubiksCube));
                this.Mask = (RubiksCube)serializer.Deserialize(reader);
                reader.ReadEndElement();
            }
        }

        /// <summary>
        /// Writes the pattern to the given XmlWriter
        /// </summary>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("Name", this.Name);
            writer.WriteAttributeString("GroupSize", this.GroupSize.ToString());
            writer.WriteAttributeString("MaxDepth", this.MaxDepth.ToString());

            XmlSerializer serializer = new XmlSerializer(typeof(RubiksCube));
            serializer.Serialize(writer, this.Mask);
        }
    }
}
