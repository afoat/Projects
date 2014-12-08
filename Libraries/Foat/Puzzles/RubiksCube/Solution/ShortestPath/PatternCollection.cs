namespace Foat.Puzzles.RubiksCube.Solution.ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines a collection of patterns that can be serialized to and from XML.
    /// </summary>
    public sealed class PatternCollection: List<Pattern>, IXmlSerializable
    {
        #region Constructors

        public PatternCollection() 
            : base()
        {
        }

        public PatternCollection(int capacity)
            : base(capacity)
        {
        }

        public PatternCollection(IEnumerable<Pattern> patterns)
        {
            this.AddRange(patterns);
        }

        #endregion

        #region Public Methods
        
        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (!reader.IsStartElement("PatternCollection"))
            {
                throw new InvalidOperationException();
            }
            else
            {
                reader.ReadStartElement("PatternCollection");
                XmlSerializer serializer = new XmlSerializer(typeof(Pattern));
                do
                {
                    Pattern pattern = (Pattern)serializer.Deserialize(reader);
                    this.Add(pattern);
                } while (reader.NodeType != XmlNodeType.EndElement);

                reader.ReadEndElement();
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Pattern));
            foreach (Pattern pattern in this)
            {
                serializer.Serialize(writer, pattern);
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        #endregion
    }
}
