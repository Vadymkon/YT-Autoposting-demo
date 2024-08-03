
namespace YLoader
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.yt_Button3 = new yt_DesignUI.yt_Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.egoldsToggleSwitch2 = new yt_DesignUI.EgoldsToggleSwitch();
            this.egoldsToggleSwitch1 = new yt_DesignUI.EgoldsToggleSwitch();
            this.egoldsGoogleTextBox2 = new yt_DesignUI.EgoldsGoogleTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.yt_Button13 = new yt_DesignUI.yt_Button();
            this.yt_Button12 = new yt_DesignUI.yt_Button();
            this.yt_Button10 = new yt_DesignUI.yt_Button();
            this.yt_Button8 = new yt_DesignUI.yt_Button();
            this.yt_Button7 = new yt_DesignUI.yt_Button();
            this.yt_Button11 = new yt_DesignUI.yt_Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(12, 37);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(500, 479);
            this.objectListView1.SortGroupItemsByPrimaryColumn = false;
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseAlternatingBackColors = true;
            this.objectListView1.UseCellFormatEvents = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "FileName";
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 347;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "PublishedDate";
            this.olvColumn2.Text = "Date";
            this.olvColumn2.Width = 467;
            // 
            // yt_Button3
            // 
            this.yt_Button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.yt_Button3.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button3.BackColorGradientEnabled = false;
            this.yt_Button3.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button3.BorderColor = System.Drawing.Color.LawnGreen;
            this.yt_Button3.BorderColorEnabled = false;
            this.yt_Button3.BorderColorOnHover = System.Drawing.Color.LawnGreen;
            this.yt_Button3.BorderColorOnHoverEnabled = false;
            this.yt_Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yt_Button3.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Bold);
            this.yt_Button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.yt_Button3.Location = new System.Drawing.Point(12, 522);
            this.yt_Button3.Name = "yt_Button3";
            this.yt_Button3.RippleColor = System.Drawing.Color.Black;
            this.yt_Button3.Rounding = 80;
            this.yt_Button3.RoundingEnable = true;
            this.yt_Button3.Size = new System.Drawing.Size(776, 35);
            this.yt_Button3.TabIndex = 28;
            this.yt_Button3.Text = "Realize this schedule";
            this.yt_Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yt_Button3.TextHover = null;
            this.yt_Button3.UseDownPressEffectOnClick = false;
            this.yt_Button3.UseRippleEffect = true;
            this.yt_Button3.UseVisualStyleBackColor = false;
            this.yt_Button3.UseZoomEffectOnHover = false;
            this.yt_Button3.Click += new System.EventHandler(this.yt_Button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.egoldsToggleSwitch2);
            this.panel2.Controls.Add(this.egoldsToggleSwitch1);
            this.panel2.Controls.Add(this.egoldsGoogleTextBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.cmbStyle);
            this.panel2.Controls.Add(this.yt_Button13);
            this.panel2.Controls.Add(this.yt_Button12);
            this.panel2.Controls.Add(this.yt_Button10);
            this.panel2.Controls.Add(this.yt_Button8);
            this.panel2.Controls.Add(this.yt_Button7);
            this.panel2.Controls.Add(this.yt_Button11);
            this.panel2.Location = new System.Drawing.Point(528, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 479);
            this.panel2.TabIndex = 32;
            // 
            // egoldsToggleSwitch2
            // 
            this.egoldsToggleSwitch2.BackColor = System.Drawing.Color.White;
            this.egoldsToggleSwitch2.BackColorOFF = System.Drawing.Color.Silver;
            this.egoldsToggleSwitch2.BackColorON = System.Drawing.Color.DodgerBlue;
            this.egoldsToggleSwitch2.Checked = false;
            this.egoldsToggleSwitch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.egoldsToggleSwitch2.Font = new System.Drawing.Font("Verdana", 9F);
            this.egoldsToggleSwitch2.Location = new System.Drawing.Point(20, 301);
            this.egoldsToggleSwitch2.Name = "egoldsToggleSwitch2";
            this.egoldsToggleSwitch2.Size = new System.Drawing.Size(107, 15);
            this.egoldsToggleSwitch2.TabIndex = 33;
            this.egoldsToggleSwitch2.Text = "FileName";
            this.egoldsToggleSwitch2.TextOnChecked = "Title";
            this.egoldsToggleSwitch2.CheckedChanged += new yt_DesignUI.EgoldsToggleSwitch.OnCheckedChangedHandler(this.egoldsToggleSwitch2_CheckedChanged);
            // 
            // egoldsToggleSwitch1
            // 
            this.egoldsToggleSwitch1.BackColor = System.Drawing.Color.White;
            this.egoldsToggleSwitch1.BackColorOFF = System.Drawing.Color.Silver;
            this.egoldsToggleSwitch1.BackColorON = System.Drawing.Color.DodgerBlue;
            this.egoldsToggleSwitch1.Checked = false;
            this.egoldsToggleSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.egoldsToggleSwitch1.Font = new System.Drawing.Font("Verdana", 9F);
            this.egoldsToggleSwitch1.Location = new System.Drawing.Point(20, 331);
            this.egoldsToggleSwitch1.Name = "egoldsToggleSwitch1";
            this.egoldsToggleSwitch1.Size = new System.Drawing.Size(142, 15);
            this.egoldsToggleSwitch1.TabIndex = 33;
            this.egoldsToggleSwitch1.Text = "Do NOT format";
            this.egoldsToggleSwitch1.TextOnChecked = "Format";
            this.egoldsToggleSwitch1.CheckedChanged += new yt_DesignUI.EgoldsToggleSwitch.OnCheckedChangedHandler(this.egoldsToggleSwitch1_CheckedChanged);
            // 
            // egoldsGoogleTextBox2
            // 
            this.egoldsGoogleTextBox2.BackColor = System.Drawing.Color.White;
            this.egoldsGoogleTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.egoldsGoogleTextBox2.BorderColorNotActive = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.egoldsGoogleTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.egoldsGoogleTextBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.egoldsGoogleTextBox2.FontTextPreview = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.egoldsGoogleTextBox2.ForeColor = System.Drawing.Color.Black;
            this.egoldsGoogleTextBox2.Location = new System.Drawing.Point(20, 169);
            this.egoldsGoogleTextBox2.Name = "egoldsGoogleTextBox2";
            this.egoldsGoogleTextBox2.SelectionStart = 0;
            this.egoldsGoogleTextBox2.Size = new System.Drawing.Size(224, 40);
            this.egoldsGoogleTextBox2.TabIndex = 31;
            this.egoldsGoogleTextBox2.TextInput = "";
            this.egoldsGoogleTextBox2.TextPreview = "DD.MM.YYYY - start date";
            this.egoldsGoogleTextBox2.UseSystemPasswordChar = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "a_3d",
            "a_sh"});
            this.comboBox1.Location = new System.Drawing.Point(36, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(224, 28);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Visible = false;
            // 
            // cmbStyle
            // 
            this.cmbStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(20, 64);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(224, 21);
            this.cmbStyle.TabIndex = 30;
            // 
            // yt_Button13
            // 
            this.yt_Button13.BackColor = System.Drawing.Color.SlateGray;
            this.yt_Button13.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button13.BackColorGradientEnabled = false;
            this.yt_Button13.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button13.BorderColor = System.Drawing.Color.LawnGreen;
            this.yt_Button13.BorderColorEnabled = false;
            this.yt_Button13.BorderColorOnHover = System.Drawing.Color.LawnGreen;
            this.yt_Button13.BorderColorOnHoverEnabled = false;
            this.yt_Button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yt_Button13.Font = new System.Drawing.Font("Verdana", 16.25F);
            this.yt_Button13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.yt_Button13.Location = new System.Drawing.Point(20, 395);
            this.yt_Button13.Name = "yt_Button13";
            this.yt_Button13.RippleColor = System.Drawing.Color.Black;
            this.yt_Button13.Rounding = 60;
            this.yt_Button13.RoundingEnable = true;
            this.yt_Button13.Size = new System.Drawing.Size(224, 65);
            this.yt_Button13.TabIndex = 28;
            this.yt_Button13.Text = "Shift schedule";
            this.yt_Button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yt_Button13.TextHover = null;
            this.yt_Button13.UseDownPressEffectOnClick = false;
            this.yt_Button13.UseRippleEffect = true;
            this.yt_Button13.UseVisualStyleBackColor = false;
            this.yt_Button13.UseZoomEffectOnHover = false;
            this.yt_Button13.Click += new System.EventHandler(this.yt_Button13_Click);
            // 
            // yt_Button12
            // 
            this.yt_Button12.BackColor = System.Drawing.Color.SlateGray;
            this.yt_Button12.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button12.BackColorGradientEnabled = false;
            this.yt_Button12.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button12.BorderColor = System.Drawing.Color.LawnGreen;
            this.yt_Button12.BorderColorEnabled = false;
            this.yt_Button12.BorderColorOnHover = System.Drawing.Color.LawnGreen;
            this.yt_Button12.BorderColorOnHoverEnabled = false;
            this.yt_Button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yt_Button12.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.yt_Button12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.yt_Button12.Location = new System.Drawing.Point(20, 352);
            this.yt_Button12.Name = "yt_Button12";
            this.yt_Button12.RippleColor = System.Drawing.Color.Black;
            this.yt_Button12.Rounding = 60;
            this.yt_Button12.RoundingEnable = true;
            this.yt_Button12.Size = new System.Drawing.Size(224, 37);
            this.yt_Button12.TabIndex = 28;
            this.yt_Button12.Text = "Shorts-schedule";
            this.yt_Button12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yt_Button12.TextHover = null;
            this.yt_Button12.UseDownPressEffectOnClick = false;
            this.yt_Button12.UseRippleEffect = true;
            this.yt_Button12.UseVisualStyleBackColor = false;
            this.yt_Button12.UseZoomEffectOnHover = false;
            this.yt_Button12.Click += new System.EventHandler(this.yt_Button12_Click);
            // 
            // yt_Button10
            // 
            this.yt_Button10.BackColor = System.Drawing.Color.Lime;
            this.yt_Button10.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button10.BackColorGradientEnabled = false;
            this.yt_Button10.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button10.BorderColor = System.Drawing.Color.LawnGreen;
            this.yt_Button10.BorderColorEnabled = false;
            this.yt_Button10.BorderColorOnHover = System.Drawing.Color.LawnGreen;
            this.yt_Button10.BorderColorOnHoverEnabled = false;
            this.yt_Button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yt_Button10.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.yt_Button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.yt_Button10.Location = new System.Drawing.Point(20, 215);
            this.yt_Button10.Name = "yt_Button10";
            this.yt_Button10.RippleColor = System.Drawing.Color.Black;
            this.yt_Button10.Rounding = 60;
            this.yt_Button10.RoundingEnable = true;
            this.yt_Button10.Size = new System.Drawing.Size(224, 37);
            this.yt_Button10.TabIndex = 28;
            this.yt_Button10.Text = "Correct the dates";
            this.yt_Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yt_Button10.TextHover = null;
            this.yt_Button10.UseDownPressEffectOnClick = false;
            this.yt_Button10.UseRippleEffect = true;
            this.yt_Button10.UseVisualStyleBackColor = false;
            this.yt_Button10.UseZoomEffectOnHover = false;
            this.yt_Button10.Click += new System.EventHandler(this.yt_Button10_Click);
            // 
            // yt_Button8
            // 
            this.yt_Button8.BackColor = System.Drawing.Color.SlateGray;
            this.yt_Button8.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button8.BackColorGradientEnabled = false;
            this.yt_Button8.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button8.BorderColor = System.Drawing.Color.LawnGreen;
            this.yt_Button8.BorderColorEnabled = false;
            this.yt_Button8.BorderColorOnHover = System.Drawing.Color.LawnGreen;
            this.yt_Button8.BorderColorOnHoverEnabled = false;
            this.yt_Button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yt_Button8.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.yt_Button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.yt_Button8.Location = new System.Drawing.Point(20, 101);
            this.yt_Button8.Name = "yt_Button8";
            this.yt_Button8.RippleColor = System.Drawing.Color.Black;
            this.yt_Button8.Rounding = 60;
            this.yt_Button8.RoundingEnable = true;
            this.yt_Button8.Size = new System.Drawing.Size(224, 37);
            this.yt_Button8.TabIndex = 28;
            this.yt_Button8.Text = "Add material";
            this.yt_Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yt_Button8.TextHover = null;
            this.yt_Button8.UseDownPressEffectOnClick = false;
            this.yt_Button8.UseRippleEffect = true;
            this.yt_Button8.UseVisualStyleBackColor = false;
            this.yt_Button8.UseZoomEffectOnHover = false;
            this.yt_Button8.Click += new System.EventHandler(this.yt_Button8_Click);
            // 
            // yt_Button7
            // 
            this.yt_Button7.BackColor = System.Drawing.Color.Lime;
            this.yt_Button7.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button7.BackColorGradientEnabled = false;
            this.yt_Button7.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button7.BorderColor = System.Drawing.Color.LawnGreen;
            this.yt_Button7.BorderColorEnabled = false;
            this.yt_Button7.BorderColorOnHover = System.Drawing.Color.LawnGreen;
            this.yt_Button7.BorderColorOnHoverEnabled = false;
            this.yt_Button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yt_Button7.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.yt_Button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.yt_Button7.Location = new System.Drawing.Point(46, 0);
            this.yt_Button7.Name = "yt_Button7";
            this.yt_Button7.RippleColor = System.Drawing.Color.Black;
            this.yt_Button7.Rounding = 60;
            this.yt_Button7.RoundingEnable = true;
            this.yt_Button7.Size = new System.Drawing.Size(224, 37);
            this.yt_Button7.TabIndex = 28;
            this.yt_Button7.Text = "Script:";
            this.yt_Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yt_Button7.TextHover = null;
            this.yt_Button7.UseDownPressEffectOnClick = false;
            this.yt_Button7.UseRippleEffect = true;
            this.yt_Button7.UseVisualStyleBackColor = false;
            this.yt_Button7.UseZoomEffectOnHover = false;
            this.yt_Button7.Visible = false;
            // 
            // yt_Button11
            // 
            this.yt_Button11.BackColor = System.Drawing.Color.Lime;
            this.yt_Button11.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button11.BackColorGradientEnabled = false;
            this.yt_Button11.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button11.BorderColor = System.Drawing.Color.LawnGreen;
            this.yt_Button11.BorderColorEnabled = false;
            this.yt_Button11.BorderColorOnHover = System.Drawing.Color.LawnGreen;
            this.yt_Button11.BorderColorOnHoverEnabled = false;
            this.yt_Button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yt_Button11.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.yt_Button11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.yt_Button11.Location = new System.Drawing.Point(20, 21);
            this.yt_Button11.Name = "yt_Button11";
            this.yt_Button11.RippleColor = System.Drawing.Color.Black;
            this.yt_Button11.Rounding = 60;
            this.yt_Button11.RoundingEnable = true;
            this.yt_Button11.Size = new System.Drawing.Size(224, 37);
            this.yt_Button11.TabIndex = 28;
            this.yt_Button11.Text = "Sources:";
            this.yt_Button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.yt_Button11.TextHover = null;
            this.yt_Button11.UseDownPressEffectOnClick = false;
            this.yt_Button11.UseRippleEffect = true;
            this.yt_Button11.UseVisualStyleBackColor = false;
            this.yt_Button11.UseZoomEffectOnHover = false;
            this.yt_Button11.Click += new System.EventHandler(this.yt_Button11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(454, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 22);
            this.label1.TabIndex = 34;
            this.label1.Text = "?";
            this.toolTip1.SetToolTip(this.label1, "Check videos you gonna move \r\n(click on checkboxes)\r\nAfter right click to place w" +
        "here you gonna put it.\r\n\r\nClick on \"Move Graffik\" to HIDE checkboxes.");
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(57, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(705, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "DEMO maximum is 50 videos. Need more: vadymkonbusiness@gmail.com";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 569);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.yt_Button3);
            this.Controls.Add(this.objectListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Opacity = 0.98D;
            this.Text = "Проверить график выхода";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private yt_DesignUI.yt_Button yt_Button3;
        private System.Windows.Forms.Panel panel2;
        private yt_DesignUI.yt_Button yt_Button11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbStyle;
        private yt_DesignUI.yt_Button yt_Button13;
        private yt_DesignUI.yt_Button yt_Button12;
        private yt_DesignUI.yt_Button yt_Button10;
        private yt_DesignUI.yt_Button yt_Button7;
        private yt_DesignUI.EgoldsGoogleTextBox egoldsGoogleTextBox2;
        private yt_DesignUI.yt_Button yt_Button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private yt_DesignUI.EgoldsToggleSwitch egoldsToggleSwitch1;
        private yt_DesignUI.EgoldsToggleSwitch egoldsToggleSwitch2;
        private System.Windows.Forms.Label label2;
    }
}