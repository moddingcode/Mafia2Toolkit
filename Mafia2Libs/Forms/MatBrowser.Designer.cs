﻿namespace Mafia2Tool.Forms
{
    partial class MatBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatBrowser));
            this.FlowPanel_Materials = new System.Windows.Forms.FlowLayoutPanel();
            this.ComboBox_SelectMatLib = new System.Windows.Forms.Label();
            this.Label_SearchBar = new System.Windows.Forms.Label();
            this.ComboBox_Materials = new System.Windows.Forms.ComboBox();
            this.TextBox_SearchBar = new System.Windows.Forms.TextBox();
            this.Button_Search = new System.Windows.Forms.Button();
            this.Label_MaterialCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FlowPanel_Materials
            // 
            this.FlowPanel_Materials.AutoScroll = true;
            this.FlowPanel_Materials.Location = new System.Drawing.Point(0, 52);
            this.FlowPanel_Materials.Name = "FlowPanel_Materials";
            this.FlowPanel_Materials.Size = new System.Drawing.Size(800, 398);
            this.FlowPanel_Materials.TabIndex = 3;
            // 
            // ComboBox_SelectMatLib
            // 
            this.ComboBox_SelectMatLib.AutoSize = true;
            this.ComboBox_SelectMatLib.Location = new System.Drawing.Point(12, 9);
            this.ComboBox_SelectMatLib.Name = "ComboBox_SelectMatLib";
            this.ComboBox_SelectMatLib.Size = new System.Drawing.Size(132, 13);
            this.ComboBox_SelectMatLib.TabIndex = 4;
            this.ComboBox_SelectMatLib.Text = "$LABEL_SELECTMATLIB";
            // 
            // Label_SearchBar
            // 
            this.Label_SearchBar.AutoSize = true;
            this.Label_SearchBar.Location = new System.Drawing.Point(480, 9);
            this.Label_SearchBar.Name = "Label_SearchBar";
            this.Label_SearchBar.Size = new System.Drawing.Size(118, 13);
            this.Label_SearchBar.TabIndex = 5;
            this.Label_SearchBar.Text = "$LABEL_SEARCHBAR";
            // 
            // ComboBox_Materials
            // 
            this.ComboBox_Materials.FormattingEnabled = true;
            this.ComboBox_Materials.Location = new System.Drawing.Point(12, 25);
            this.ComboBox_Materials.Name = "ComboBox_Materials";
            this.ComboBox_Materials.Size = new System.Drawing.Size(189, 21);
            this.ComboBox_Materials.TabIndex = 6;
            this.ComboBox_Materials.SelectedIndexChanged += new System.EventHandler(this.ComboBox_MaterialsSelectedIndexChanged);
            // 
            // TextBox_SearchBar
            // 
            this.TextBox_SearchBar.Location = new System.Drawing.Point(483, 25);
            this.TextBox_SearchBar.Name = "TextBox_SearchBar";
            this.TextBox_SearchBar.Size = new System.Drawing.Size(224, 20);
            this.TextBox_SearchBar.TabIndex = 7;
            // 
            // Button_Search
            // 
            this.Button_Search.Location = new System.Drawing.Point(713, 23);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(75, 23);
            this.Button_Search.TabIndex = 8;
            this.Button_Search.Text = "$SEARCH";
            this.Button_Search.UseVisualStyleBackColor = true;
            this.Button_Search.Click += new System.EventHandler(this.Button_SearchOnClicked);
            // 
            // Label_MaterialCount
            // 
            this.Label_MaterialCount.AutoSize = true;
            this.Label_MaterialCount.Location = new System.Drawing.Point(656, 9);
            this.Label_MaterialCount.Name = "Label_MaterialCount";
            this.Label_MaterialCount.Size = new System.Drawing.Size(51, 13);
            this.Label_MaterialCount.TabIndex = 9;
            this.Label_MaterialCount.Text = "$COUNT";
            // 
            // MatBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Label_MaterialCount);
            this.Controls.Add(this.Button_Search);
            this.Controls.Add(this.TextBox_SearchBar);
            this.Controls.Add(this.ComboBox_Materials);
            this.Controls.Add(this.Label_SearchBar);
            this.Controls.Add(this.ComboBox_SelectMatLib);
            this.Controls.Add(this.FlowPanel_Materials);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatBrowser";
            this.Text = "MatBrowser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowPanel_Materials;
        private System.Windows.Forms.Label ComboBox_SelectMatLib;
        private System.Windows.Forms.Label Label_SearchBar;
        private System.Windows.Forms.ComboBox ComboBox_Materials;
        private System.Windows.Forms.TextBox TextBox_SearchBar;
        private System.Windows.Forms.Button Button_Search;
        private System.Windows.Forms.Label Label_MaterialCount;
    }
}