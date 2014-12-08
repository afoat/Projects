namespace Foat.Puzzles.RubiksCube
{
    using Foat.Hashing;
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public sealed class RubiksCube : IHashKey, IXmlSerializable, IEquatable<RubiksCube>
    {
        #region Constants 

        private const byte CornerStartIx = 0;
        private const byte CornerEndIx = 6;
        private const byte EdgeStartIx = 7;
        private const byte EdgeEndIx = 18;
        private const byte NumCubies = EdgeEndIx + 1;

        #endregion

        #region Properties

        private byte[] Data { get; set; }

        internal byte this[int index]
        {
            get
            {
                return this.Data[index];
            }
        }

        #endregion

        #region Construction

        public RubiksCube()
        {
            this.Data = new byte[NumCubies];

            this.Data[0] = CornerPosition.TopBackLeftPrimaryTop;
            this.Data[1] = CornerPosition.TopBackRightPrimaryTop;
            this.Data[2] = CornerPosition.TopFrontRightPrimaryTop;
            this.Data[3] = CornerPosition.TopFrontLeftPrimaryTop;
            this.Data[4] = CornerPosition.BottomBackLeftPrimaryBottom;
            this.Data[5] = CornerPosition.BottomBackRightPrimaryBottom;
            this.Data[6] = CornerPosition.BottomFrontRightPrimaryBottom;

            this.Data[7] = EdgePosition.TopLeftPrimaryTop;
            this.Data[8] = EdgePosition.TopBackPrimaryTop;
            this.Data[9] = EdgePosition.TopRightPrimaryTop;
            this.Data[10] = EdgePosition.TopFrontPrimaryTop;
            this.Data[11] = EdgePosition.BottomLeftPrimaryBottom;
            this.Data[12] = EdgePosition.BottomBackPrimaryBottom;
            this.Data[13] = EdgePosition.BottomRightPrimaryBottom;
            this.Data[14] = EdgePosition.BottomFrontPrimaryBottom;
            this.Data[15] = EdgePosition.FrontLeftPrimaryFront;
            this.Data[16] = EdgePosition.BackLeftPrimaryBack;
            this.Data[17] = EdgePosition.BackRightPrimaryBack;
            this.Data[18] = EdgePosition.FrontRightPrimaryFront;
        }

        internal RubiksCube(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (data.Length != NumCubies)
                throw new ArgumentException(string.Format("Must have {0} cubies.", NumCubies));

            this.Data = data;
        }

        #endregion

        #region Public Methods

        public RubiksCube ApplyMask(RubiksCube mask)
        {
            byte[] newData = new byte[NumCubies];

            for (int cornerIx = CornerStartIx; cornerIx <= CornerEndIx; ++cornerIx)
            {
                newData[cornerIx] = CornerPosition.Mask(this.Data[cornerIx], mask.Data[cornerIx]);
            }

            for (int edgeIx = EdgeStartIx; edgeIx <= EdgeEndIx; ++edgeIx)
            {
                newData[edgeIx] = EdgePosition.Mask(this.Data[edgeIx], mask.Data[edgeIx]);
            }

            return new RubiksCube(newData);
        }

        public RubiksCube RotateTopCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateTopCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateTopCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateTopCCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateTopCCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateTopCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateTopHalf()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateTopHalf(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateTopHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBottomCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateBottomCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateBottomCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBottomCCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateBottomCCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateBottomCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBottomHalf()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateBottomHalf(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateBottomHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateLeftCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateLeftCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateLeftCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateLeftCCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateLeftCCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateLeftCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateLeftHalf()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateLeftHalf(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateLeftHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateRightCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateRightCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateRightCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateRightCCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateRightCCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateRightCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateRightHalf()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateRightHalf(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateRightHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateFrontCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateFrontCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateFrontCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateFrontCCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateFrontCCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateFrontCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateFrontHalf()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateFrontHalf(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateFrontHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBackCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateBackCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateBackCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBackCCW()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateBackCCW(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateBackCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBackHalf()
        {
            byte[] newData = new byte[NumCubies];
            ModifyEdgesIntoNewData(newData, edge => EdgePosition.RotateBackHalf(edge));
            ModifyCornersIntoNewData(newData, corner => CornerPosition.RotateBackHalf(corner));

            return new RubiksCube(newData);
        }

        #endregion

        #region Helpers

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ModifyEdgesIntoNewData(byte[] newData, Func<byte, byte> function)
        {
            for (int edgeIx = EdgeStartIx; edgeIx <= EdgeEndIx; ++edgeIx)
            {
                newData[edgeIx] = function(this.Data[edgeIx]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ModifyCornersIntoNewData(byte[] newData, Func<byte, byte> function)
        {
            for (int cornerIx = CornerStartIx; cornerIx <= CornerEndIx; ++cornerIx)
            {
                newData[cornerIx] = function(this.Data[cornerIx]);
            }
        }

        #endregion

        #region IHashKey

        public byte[] GetBytes()
        {
            return this.Data;
        }

        #endregion

        #region Object Overrides

        public override int GetHashCode()
        {
            FnvHash hash = new FnvHash();
            return hash.ComputeHash(this.Data);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as RubiksCube);
        }

        public bool Equals(RubiksCube otherCube)
        {
            if (otherCube == null)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.Data.Length; i++)
                {
                    if (this.Data[i] != otherCube.Data[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        #endregion

        #region IXmlSerializable

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (!reader.IsStartElement("RubiksCube"))
            {
                throw new InvalidOperationException();
            }
            else
            {
                reader.ReadStartElement("RubiksCube");
                XmlSerializer serializer = new XmlSerializer(typeof(byte[]));
                this.Data = (byte[])serializer.Deserialize(reader);
                reader.ReadEndElement();
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(byte[]));
            serializer.Serialize(writer, this.Data);
        }

        #endregion
    }
}
