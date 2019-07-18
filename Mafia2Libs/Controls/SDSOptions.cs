﻿using System;
using System.Windows.Forms;
using Utils.Lang;
using Utils.Settings;

namespace Forms.OptionControls
{
    public partial class SDSOptions : UserControl
    {
        public SDSOptions()
        {
            InitializeComponent();
            Localise();
            LoadSettings();
        }

        private void Localise()
        {
            M2Label.Text = Language.GetString("$SDS_COMPRESSION_TYPE");
            CompressionDropdownBox.Items[0] = Language.GetString("$SDS_UNCOMPRESSED");
            CompressionDropdownBox.Items[1] = Language.GetString("$SDS_COMPRESSED");
            AddTimeDateBackupsBox.Text = Language.GetString("$ADD_TIME_DATE_BACKUP");
            UnpackLUABox.Text = Language.GetString("$DECOMPILE_LUA_UNPACK");
        }

        private void LoadSettings()
        {
            CompressionDropdownBox.SelectedIndex = ToolkitSettings.SerializeSDSOption;
            AddTimeDateBackupsBox.Checked = ToolkitSettings.AddTimeDataBackup;
            UnpackLUABox.Checked = ToolkitSettings.DecompileLUA;
        }

        private void SDSCompress_IndexChanged(object sender, EventArgs e)
        {
            ToolkitSettings.SerializeSDSOption = CompressionDropdownBox.SelectedIndex;
            ToolkitSettings.WriteKey("SerializeOption", "SDS", CompressionDropdownBox.SelectedIndex.ToString());
        }

        private void AddTimeDateBackupsBox_CheckedChanged(object sender, EventArgs e)
        {
            ToolkitSettings.AddTimeDataBackup = AddTimeDateBackupsBox.Checked;
            ToolkitSettings.WriteKey("AddTimeDataBackup", "SDS", ToolkitSettings.AddTimeDataBackup.ToString());
        }

        private void UnpackLUABox_CheckedChanged(object sender, EventArgs e)
        {
            ToolkitSettings.DecompileLUA = UnpackLUABox.Checked;
            ToolkitSettings.WriteKey("DecompileLUA", "SDS", ToolkitSettings.DecompileLUA.ToString());
        }
    }
}