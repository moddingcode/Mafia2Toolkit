﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Mafia2
{
    public class FrameObjectSingleMesh : FrameObjectJoint
    {

        NameTableFlags nameTableFlags;
        SingleMeshFlags flags;
        Bounds bounds;
        byte unk_14_byte;
        int meshIndex;
        int materialIndex;
        Hash unk_17_textureHash;
        byte unk_18_byte1;
        byte unk_18_byte2;
        byte unk_18_byte3;
        FrameGeometry mesh;

        [Description("Only use this if the object is going to be saved in the FrameNameTable")]
        public NameTableFlags FrameNameTableFlags {
            get { return nameTableFlags; }
            set { nameTableFlags = value; }
        }
        public SingleMeshFlags Flags {
            get { return flags; }
            set { flags = value; }
        }
        public Bounds Boundings {
            get { return bounds; }
            set { bounds = value; }
        }
        public byte Unk_14 {
            get { return unk_14_byte; }
            set { unk_14_byte = value; }
        }
        public int MeshIndex {
            get { return meshIndex; }
            set { meshIndex = value; }
        }
        public int MaterialIndex {
            get { return materialIndex; }
            set { materialIndex = value; }
        }
        public Hash Unk17 {
            get { return unk_17_textureHash; }
            set { unk_17_textureHash = value; }
        }
        public byte Unk_18_1 {
            get { return unk_18_byte1; }
            set { unk_18_byte1 = value; }
        }
        public byte Unk_18_2 {
            get { return unk_18_byte2; }
            set { unk_18_byte2 = value; }
        }
        public byte Unk_18_3 {
            get { return unk_18_byte3; }
            set { unk_18_byte3 = value; }
        }
        public FrameGeometry Mesh {
            get { return mesh; }
            set { mesh = value; }
        }

        public FrameObjectSingleMesh(BinaryReader reader) : base()
        {
            ReadFromFile(reader);
        }
        public FrameObjectSingleMesh() : base()
        {
        }

        public override void ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            flags = (SingleMeshFlags)reader.ReadInt32();
            bounds = new Bounds(reader);
            unk_14_byte = reader.ReadByte();
            meshIndex = reader.ReadInt32();
            materialIndex = reader.ReadInt32();
            unk_17_textureHash = new Hash(reader);
            unk_18_byte1 = reader.ReadByte();
            unk_18_byte2 = reader.ReadByte();
            unk_18_byte3 = reader.ReadByte();
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            base.WriteToFile(writer);
            writer.Write((int)flags);
            bounds.WriteToFile(writer);
            writer.Write(unk_14_byte);
            writer.Write(meshIndex);
            writer.Write(materialIndex);
            unk_17_textureHash.WriteToFile(writer);
            writer.Write(unk_18_byte1);
            writer.Write(unk_18_byte2);
            writer.Write(unk_18_byte3);
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
