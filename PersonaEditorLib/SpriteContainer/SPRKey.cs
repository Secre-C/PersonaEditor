using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PersonaEditorLib.SpriteContainer
{
    public class SPRKey
    {
        public int _unk0x00;
        public string Comment { get; private set; }
        public byte[] CommentByte;
        public int TextureIndex;
        public RotationMask RotMask;
        public int _unk0x1C;
        public int _unk0x20;
        public int _unk0x24;
        public int _unk0x28;
        public int _unk0x2C;
        public int _unk0x30;
        public int _unk0x34;
        public int _unk0x38;
        public int _unk0x3C;
        public int _unk0x40;
        public int XOffset;
        public int YOffset;
        public int _unk0x4C;
        public int _unk0x50;
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;
        public int ColorA;
        public int ColorR;
        public int ColorG;
        public int ColorB;
        public int _unk0x74;
        public int _unk0x78;
        public int _unk0x7C;
        public int Index;

        public SPRKey(byte[] key, int index)
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(key)))
            {
                _unk0x00 = reader.ReadInt32();
                CommentByte = reader.ReadBytes(16);
                Comment = Encoding.GetEncoding("shift-jis").GetString(CommentByte.Where(x => x != 0x00).ToArray());
                TextureIndex = reader.ReadInt32();
                RotMask = new RotationMask { data = reader.ReadInt32() };
                _unk0x1C = reader.ReadInt32();
                _unk0x20 = reader.ReadInt32();
                _unk0x24 = reader.ReadInt32();
                _unk0x28 = reader.ReadInt32();
                _unk0x2C = reader.ReadInt32();
                _unk0x30 = reader.ReadInt32();
                _unk0x34 = reader.ReadInt32();
                _unk0x38 = reader.ReadInt32();
                _unk0x3C = reader.ReadInt32();
                _unk0x40 = reader.ReadInt32();
                XOffset = reader.ReadInt32();
                YOffset = reader.ReadInt32();
                _unk0x4C = reader.ReadInt32();
                _unk0x50 = reader.ReadInt32();
                X1 = reader.ReadInt32();
                Y1 = reader.ReadInt32();
                X2 = reader.ReadInt32();
                Y2 = reader.ReadInt32();
                ColorA = reader.ReadInt32();
                ColorR = reader.ReadInt32();
                ColorG = reader.ReadInt32();
                ColorB = reader.ReadInt32();
                _unk0x74 = reader.ReadInt32();
                _unk0x78 = reader.ReadInt32();
                _unk0x7C = reader.ReadInt32();
                Index = index;
            }
        }

        public int Size
        {
            get { return 0x80; }
        }

        public void Get(BinaryWriter writer)
        {
            writer.Write(_unk0x00);
            writer.Write(CommentByte);
            writer.Write(TextureIndex);
            writer.Write(RotMask.data);
            writer.Write(_unk0x1C);
            writer.Write(_unk0x20);
            writer.Write(_unk0x24);
            writer.Write(_unk0x28);
            writer.Write(_unk0x2C);
            writer.Write(_unk0x30);
            writer.Write(_unk0x34);
            writer.Write(_unk0x38);
            writer.Write(_unk0x3C);
            writer.Write(_unk0x40);
            writer.Write(XOffset);
            writer.Write(YOffset);
            writer.Write(_unk0x4C);
            writer.Write(_unk0x50);
            writer.Write(X1);
            writer.Write(Y1);
            writer.Write(X2);
            writer.Write(Y2);
            writer.Write(ColorA);
            writer.Write(ColorR);
            writer.Write(ColorG);
            writer.Write(ColorB);
            writer.Write(_unk0x74);
            writer.Write(_unk0x78);
            writer.Write(_unk0x7C);
        }
    }

    public class SPRKeyList
    {
        public List<SPRKey> List = new List<SPRKey>();

        public SPRKeyList(BinaryReader reader, List<int> keyOffsetList)
        {
            for (int i = 0; i < keyOffsetList.Count; i++)
            {
                reader.BaseStream.Seek(keyOffsetList[i], SeekOrigin.Begin);
                List.Add(new SPRKey(reader.ReadBytes(0x80), i));
            }
        }

        public int Size
        {
            get
            {
                int returned = 0;
                foreach (var a in List) returned += a.Size;
                return returned;
            }
        }

        public void Get(BinaryWriter writer)
        {
            foreach (var a in List)
            {
                a.Get(writer);
            }
        }
    }

    public struct RotationMask
    {
        internal int data;

        public bool HorizontalFlip
        {
            get { return (data & 1) != 0; }
            set { data = value ? data | 1 : data & ~1; }
        }

        public bool VerticalFlip
        {
            get { return (data & 2) != 0; }
            set { data = value ? data | 2 : data & ~2; }
        }

    }
}