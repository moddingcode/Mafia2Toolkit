﻿using System.IO;
using Utils.StringHelpers;

namespace ResourceTypes.M3.XBin
{
    public class VehicleTableItem
    {
        public int Unk0 { get; set; }
        public int ID { get; set; }
        public ETrafficCommonFlags CommonFlags { get; set; } //E_TrafficCommonFlags
        public ETrafficVehicleFlags VehicleFlags { get; set; } //E_TrafficVehicleFlags
        public ETrafficVehicleLookFlags VehicleLookFlags { get; set; } //E_TrafficVehicleLookFlags
        public EVehiclesTableFunctionFlags VehicleFunctionFlags { get; set; } //E_VehiclesTableFunctionFlags
        public string ModelName { get; set; }
        public string SoundVehicleSwitch { get; set; }
        public ERadioStation RadioRandom { get; set; } //E_RadioStation
        public float RadioSoundQuality { get; set; }
        public int TexID { get; set; }
        public ulong TexHash { get; set; } //maybe
        public string BrandNameUI { get; set; }
        public string ModelNameUI { get; set; }
        public string LogoNameUI { get; set; }
        public int StealKoeficient { get; set; }
        public int Price { get; set; }
        public float MaxDirt { get; set; }
        public float MaxRust { get; set; }
        public float M1DE_Unk0 { get; set; }
        public float M1DE_Unk1 { get; set; }
        public EVehicleRaceClass RaceClass { get; set; } //E_VehicleRaceClass
        public float TrunkDockOffsetX { get; set; }
        public float TrunkDockOffsetY { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", ID, ModelName);
        }
        public void WriteText(StreamWriter writer)
        {
            writer.WriteLine("Start --------------------------------");
            writer.WriteLine("Unk0: {0}", Unk0);
            writer.WriteLine("ID: {0}", ID);
            writer.WriteLine("CommonFlags: {0}", CommonFlags);
            writer.WriteLine("VehicleFlags: {0}", VehicleFlags);
            writer.WriteLine("VehicleLookFlags: {0}", VehicleLookFlags);
            writer.WriteLine("VehicleFunctionFlags: {0}", VehicleFunctionFlags);
            writer.WriteLine("ModelName: {0}", ModelName);
            writer.WriteLine("SoundVehicleSwitch: {0}", SoundVehicleSwitch);
            writer.WriteLine("RadioRandom: {0}", RadioRandom);
            writer.WriteLine("RadioSoundQuality: {0}", RadioSoundQuality);
            writer.WriteLine("TexID: {0}", TexID);
            writer.WriteLine("TexHash: {0:X8}", TexHash);
            writer.WriteLine("BrandNameUI: {0}", BrandNameUI);
            writer.WriteLine("ModelNameUI: {0}", ModelNameUI);
            writer.WriteLine("LogoNameUI: {0}", LogoNameUI);
            writer.WriteLine("StealKoeficient: {0}", StealKoeficient);
            writer.WriteLine("Price: {0}", Price);
            writer.WriteLine("MaxDirt: {0}", MaxDirt);
            writer.WriteLine("MaxRust: {0}", MaxRust);
            writer.WriteLine("M1DE_Unk0: {0}", M1DE_Unk0);
            writer.WriteLine("M1DE_Unk0: {0}", M1DE_Unk1);
            writer.WriteLine("RaceClass: {0}", RaceClass);
            writer.WriteLine("TrunkDockOffsetX: {0}", TrunkDockOffsetX);
            writer.WriteLine("TrunkDockOffsetY: {0}", TrunkDockOffsetY);
            writer.WriteLine("End --------------------------------");
        }
    }

    public class VehicleTable
    {
        private VehicleTableItem[] vehicles;

        public VehicleTableItem[] Vehicles {
            get { return vehicles; }
            set { vehicles = value; }
        }

        public VehicleTable()
        {
            vehicles = new VehicleTableItem[0];
        }

        public void ReadFromFile(BinaryReader reader)
        {
            uint count0 = reader.ReadUInt32();
            uint count1 = reader.ReadUInt32();
            vehicles = new VehicleTableItem[count0];

            using (StreamWriter writer = new StreamWriter("M1DE_Vehicles.txt"))
            {
                for (int i = 0; i < count1; i++)
                {
                    VehicleTableItem item = new VehicleTableItem();
                    item.Unk0 = reader.ReadInt32();
                    item.ID = reader.ReadInt32();
                    item.CommonFlags = (ETrafficCommonFlags)reader.ReadInt32();
                    item.VehicleFlags = (ETrafficVehicleFlags)reader.ReadInt32();
                    item.VehicleLookFlags = (ETrafficVehicleLookFlags)reader.ReadInt32();
                    item.VehicleFunctionFlags = (EVehiclesTableFunctionFlags)reader.ReadInt32();
                    item.ModelName = StringHelpers.ReadStringBuffer(reader, 32).TrimEnd('\0');
                    item.SoundVehicleSwitch = StringHelpers.ReadStringBuffer(reader, 32).TrimEnd('\0');
                    item.RadioRandom = (ERadioStation)reader.ReadInt32();
                    item.RadioSoundQuality = reader.ReadSingle();
                    item.TexID = reader.ReadInt32();
                    item.TexHash = reader.ReadUInt64();
                    item.BrandNameUI = StringHelpers.ReadStringBuffer(reader, 32).TrimEnd('\0');
                    item.ModelNameUI = StringHelpers.ReadStringBuffer(reader, 32).TrimEnd('\0');
                    item.LogoNameUI = StringHelpers.ReadStringBuffer(reader, 32).TrimEnd('\0');
                    item.StealKoeficient = reader.ReadInt32();
                    item.Price = reader.ReadInt32();
                    item.MaxDirt = reader.ReadSingle();
                    item.MaxRust = reader.ReadSingle();
                    item.M1DE_Unk0 = reader.ReadSingle();
                    item.M1DE_Unk1 = reader.ReadSingle();
                    item.RaceClass = (EVehicleRaceClass)reader.ReadInt32();
                    item.TrunkDockOffsetX = reader.ReadSingle();
                    item.TrunkDockOffsetY = reader.ReadSingle();
                    item.WriteText(writer);

                    vehicles[i] = item;
                }
            }
        }

        public void WriteToFile(BinaryWriter writer)
        {
            DebugAddAllToCarPedia();

            writer.Write(vehicles.Length);
            writer.Write(vehicles.Length);

            foreach(var vehicle in vehicles)
            {
                writer.Write(vehicle.Unk0);
                writer.Write(vehicle.ID);
                writer.Write((int)vehicle.CommonFlags);
                writer.Write((int)vehicle.VehicleFlags);
                writer.Write((int)vehicle.VehicleLookFlags);
                writer.Write((int)vehicle.VehicleFunctionFlags);
                StringHelpers.WriteStringBuffer(writer, 32, vehicle.ModelName);
                StringHelpers.WriteStringBuffer(writer, 32, vehicle.SoundVehicleSwitch);
                writer.Write((int)vehicle.RadioRandom);
                writer.Write(vehicle.RadioSoundQuality);
                writer.Write(vehicle.TexID);
                writer.Write(vehicle.TexHash);
                StringHelpers.WriteStringBuffer(writer, 32, vehicle.BrandNameUI);
                StringHelpers.WriteStringBuffer(writer, 32, vehicle.ModelNameUI);
                StringHelpers.WriteStringBuffer(writer, 32, vehicle.LogoNameUI);
                writer.Write(vehicle.StealKoeficient);
                writer.Write(vehicle.Price);
                writer.Write(vehicle.MaxDirt);
                writer.Write(vehicle.MaxRust);
                writer.Write(vehicle.M1DE_Unk0);
                writer.Write(vehicle.M1DE_Unk1);
                writer.Write((int)vehicle.RaceClass);
                writer.Write(vehicle.TrunkDockOffsetX);
                writer.Write(vehicle.TrunkDockOffsetY);
            }
        }

        private void DebugAddAllToCarPedia()
        {
            foreach (var vehicle in vehicles)
            {
                if (!vehicle.VehicleFunctionFlags.HasFlag(EVehiclesTableFunctionFlags.E_VTFF_SHOW_IN_CARCYCLOPEDIA))
                {
                    vehicle.VehicleFunctionFlags |= EVehiclesTableFunctionFlags.E_VTFF_SHOW_IN_CARCYCLOPEDIA;
                }
            }
        }
    }
}
