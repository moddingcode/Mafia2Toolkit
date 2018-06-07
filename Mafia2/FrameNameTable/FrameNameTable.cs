﻿using System.IO;

namespace Mafia2
{
    public class FrameNameTable
    {
        int stringLength;
        int dataSize;
        string names;
        Data[] frameData;

        public Data[] FrameData {
            get { return frameData; }
            set { frameData = value; }
        }

        public FrameNameTable(string file)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                ReadFromFile(reader);
            }
        }

        public void ReadFromFile(BinaryReader reader)
        {
            stringLength = reader.ReadInt32();
            names = new string(reader.ReadChars(stringLength));

            dataSize = reader.ReadInt32();
            frameData = new Data[dataSize];

            for (int i = 0; i != frameData.Length; i++)
            {
                frameData[i] = new Data(reader);

                int pos = frameData[i].NamePos1;
                frameData[i].Name = names.Substring(pos, names.IndexOf('\0', pos) - pos);
                pos = frameData[i].Parent;
                frameData[i].ParentName = names.Substring(pos, names.IndexOf('\0', pos) - pos);
            }
        }

        public void WriteToFile(BinaryWriter writer)
        {
            writer.Write(stringLength);
            writer.Write(names.ToCharArray());
            writer.Write(dataSize);

            for(int i = 0; i != frameData.Length; i++)
            {
                frameData[i].WriteToFile(writer);
            }
        }

        public class Data
        {
            string parentName;
            string name;                   
            short parent;  
            ushort namepos1;
            ushort namepos2;
            short frameIndex;
            short flags;

            public string ParentName {
                get { return parentName; }
                set { parentName = value; }
            }
            public string Name {
                get { return name; }
                set { name = value; }
            }
            public short Parent {
                get { return parent; }
                set { parent = value; }
            }
            public ushort NamePos1 {
                get { return namepos1; }
                set { namepos1 = value; }
            }
            public ushort NamePos2 {
                get { return namepos2; }
                set { namepos2 = value; }
            }
            public short FrameIndex {
                get { return frameIndex; }
                set { frameIndex = value; }
            }
            public short Flags {
                get { return flags; }
                set { flags = value; }
            }

            public Data(BinaryReader reader)
            {
                ReadFromFile(reader);
            }

            public void ReadFromFile(BinaryReader reader)
            {
                parent = reader.ReadInt16();
                namepos1 = reader.ReadUInt16();
                namepos2 = reader.ReadUInt16();
                frameIndex = reader.ReadInt16();
                flags = reader.ReadInt16();
            }

            public void WriteToFile(BinaryWriter writer)
            {
                writer.Write(parent);
                writer.Write(namepos1);
                writer.Write(namepos2);
                writer.Write(frameIndex);
                writer.Write(flags);
            }

            public override string ToString()
            {
                return string.Format("{0}, {1}, Frame Index: {2}", parentName, name, frameIndex);
            }
        }
    }
}
