namespace Foat.Puzzles.RubiksCube
{
    using Foat.Hashing;
    using Foat.Puzzles.Solutions;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;

    public sealed partial class RubiksCube : IPuzzle<RubiksCube>, IXmlSerializable, IEquatable<RubiksCube>, IEnumerable<byte>, IComparable<RubiksCube>
    {

        #region Constants

        private const byte CornerStartIx = 0;
        private const byte CornerEndIx = 6;
        private const byte EdgeStartIx = 7;
        private const byte EdgeEndIx = 18;
        private const byte NumCubies = EdgeEndIx + 1;

        private static readonly FnvHash Hash = new FnvHash();

        #endregion

        #region Properties

        public bool IsMasked
        {
            get
            {
                return this.Data.Length != NumCubies;
            }
        }

        private byte[] Data;

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

            this.Data[0] = Position.TopBackLeftPrimaryTop;
            this.Data[1] = Position.TopBackRightPrimaryTop;
            this.Data[2] = Position.TopFrontRightPrimaryTop;
            this.Data[3] = Position.TopFrontLeftPrimaryTop;
            this.Data[4] = Position.BottomBackLeftPrimaryBottom;
            this.Data[5] = Position.BottomBackRightPrimaryBottom;
            this.Data[6] = Position.BottomFrontRightPrimaryBottom;

            this.Data[7] = Position.TopLeftPrimaryTop;
            this.Data[8] = Position.TopBackPrimaryTop;
            this.Data[9] = Position.TopRightPrimaryTop;
            this.Data[10] = Position.TopFrontPrimaryTop;
            this.Data[11] = Position.BottomLeftPrimaryBottom;
            this.Data[12] = Position.BottomBackPrimaryBottom;
            this.Data[13] = Position.BottomRightPrimaryBottom;
            this.Data[14] = Position.BottomFrontPrimaryBottom;
            this.Data[15] = Position.FrontLeftPrimaryFront;
            this.Data[16] = Position.BackLeftPrimaryBack;
            this.Data[17] = Position.BackRightPrimaryBack;
            this.Data[18] = Position.FrontRightPrimaryFront;
        }

        public RubiksCube(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (data.Length > NumCubies)
                throw new ArgumentException("Data too long");

            for (int i = 0; i < data.Length; i++)
            {
                if (!Position.IsValidPosition(data[i]))
                    throw new ArgumentException("Invalid data.");
            }

            this.Data = data;
        }

        #endregion

        #region Public Methods

        public RubiksCube ApplyMask(RubiksCube mask)
        {
            if (mask == null)
                throw new NullReferenceException("mask");

            if (this.IsMasked)
                throw new InvalidOperationException("Rubiks cube is already masked.");
                        
            List<byte> maskedBytes = new List<byte>(RubiksCube.NumCubies);
            for (int i = 0; i < this.Data.Length; i++)
            {
                if (mask[i] != Position.Masked)
                {
                    if (mask[i] != Position.Unmasked)
                    {
                        throw new ArgumentException("Bad mask");
                    }

                    maskedBytes.Add(this.Data[i]);
                }
            }

            return new RubiksCube(maskedBytes.ToArray());
        }
        
        public RubiksCube GetFullRubiksCube(RubiksCube mask)
        {
            if (mask == null)
                throw new NullReferenceException("mask");

            if (!this.IsMasked)
                throw new InvalidOperationException("Rubiks cube is already full.");
            
            byte[] rubiksBytes = new byte[RubiksCube.NumCubies];
            int currentRubiksByte = 0;
            int currentMaskedByte = 0;

            for (int i = 0; i < this.Data.Length; i++)
            {
                if (mask[i] == Position.Masked)
                {
                    rubiksBytes[currentRubiksByte++] = Position.Masked;
                }
                else
                {
                    rubiksBytes[currentRubiksByte++] = this.Data[currentMaskedByte++];
                }
            }
            
            return new RubiksCube(rubiksBytes);
        }

        public int GetNumBytes()
        {
            return this.Data.Length;
        }

        public byte[] GetBytes()
        {
            return this.Data;
        }

        public RubiksCube RotateTopCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateTopCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateTopCCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateTopCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateTopHalf()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateTopHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBottomCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateBottomCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBottomCCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateBottomCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBottomHalf()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateBottomHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateLeftCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateLeftCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateLeftCCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateLeftCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateLeftHalf()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateLeftHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateRightCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateRightCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateRightCCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateRightCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateRightHalf()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateRightHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateFrontCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateFrontCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateFrontCCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateFrontCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateFrontHalf()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateFrontHalf(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBackCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateBackCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBackCCW()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateBackCCW(corner));

            return new RubiksCube(newData);
        }

        public RubiksCube RotateBackHalf()
        {
            byte[] newData = new byte[this.Data.Length];
            ModifyPositionsIntoNewData(newData, corner => Position.RotateBackHalf(corner));

            return new RubiksCube(newData);
        }

        public Move<RubiksCube>[] GetAllMoves()
        {
            return AllMoves;
        }

        public Move<RubiksCube>[] GetValidMoves()
        {
            return AllMoves;
        }

        #endregion

        #region Helpers
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ModifyPositionsIntoNewData(byte[] newData, Func<byte, byte> function)
        {
            for (int i = 0; i < this.Data.Length; ++i)
            {
                newData[i] = function(this.Data[i]);
            }
        }

        #endregion


        #region Object Overrides

        public override int GetHashCode()
        {
            return Hash.ComputeHash(this.Data);
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

        #region IEnumerable

        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < this.Data.Length; ++i)
            {
                yield return this.Data[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        public int CompareTo(RubiksCube other)
        {
            int minLength = Math.Min(this.Data.Length, other.Data.Length);
            for (int i = 0; i < minLength; ++i)
            {
                int compareTo = this.Data[i].CompareTo(other.Data[i]);
                if (compareTo != 0)
                    return compareTo;
            }

            if (this.Data.Length == other.Data.Length)
                return 0;
            else if (this.Data.Length == minLength)
                return 1;
            else 
                return -1;
        }
    }
}
