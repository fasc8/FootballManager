namespace FootballManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tpSetup = new System.Windows.Forms.TabPage();
            this.cbLoadLastBackupOnStart = new System.Windows.Forms.CheckBox();
            this.cbCloseBackup = new System.Windows.Forms.CheckBox();
            this.cbAutoBackup = new System.Windows.Forms.CheckBox();
            this.btnSaveTable = new System.Windows.Forms.Button();
            this.mtbPauseLength = new System.Windows.Forms.MaskedTextBox();
            this.mtbGameLength = new System.Windows.Forms.MaskedTextBox();
            this.lblListPause = new System.Windows.Forms.Label();
            this.lvPauses = new System.Windows.Forms.ListView();
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPause = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsPause = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePause = new System.Windows.Forms.ToolStripMenuItem();
            this.mtbStartTime = new System.Windows.Forms.MaskedTextBox();
            this.lblPause = new System.Windows.Forms.Label();
            this.lblMatchdauer = new System.Windows.Forms.Label();
            this.lblStartZeit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavePlan = new System.Windows.Forms.Button();
            this.btnImportPlan = new System.Windows.Forms.Button();
            this.btnCreatePlan = new System.Windows.Forms.Button();
            this.lvTeams = new System.Windows.Forms.ListView();
            this.chTeam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsTeams = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpPlan = new System.Windows.Forms.TabPage();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.lvSpiele = new System.Windows.Forms.ListView();
            this.chZeit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHeim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWertung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpTable = new System.Windows.Forms.TabPage();
            this.lvTable = new System.Windows.Forms.ListView();
            this.chRang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMannschaft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSpiele = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPunkte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGegenTore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDifferenz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrBackup = new System.Windows.Forms.Timer(this.components);
            this.tbMain.SuspendLayout();
            this.tpSetup.SuspendLayout();
            this.cmsPause.SuspendLayout();
            this.cmsTeams.SuspendLayout();
            this.tpPlan.SuspendLayout();
            this.tpTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMain.Controls.Add(this.tpSetup);
            this.tbMain.Controls.Add(this.tpPlan);
            this.tbMain.Controls.Add(this.tpTable);
            this.tbMain.Location = new System.Drawing.Point(12, 12);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(821, 536);
            this.tbMain.TabIndex = 6;
            // 
            // tpSetup
            // 
            this.tpSetup.Controls.Add(this.cbLoadLastBackupOnStart);
            this.tpSetup.Controls.Add(this.cbCloseBackup);
            this.tpSetup.Controls.Add(this.cbAutoBackup);
            this.tpSetup.Controls.Add(this.btnSaveTable);
            this.tpSetup.Controls.Add(this.mtbPauseLength);
            this.tpSetup.Controls.Add(this.mtbGameLength);
            this.tpSetup.Controls.Add(this.lblListPause);
            this.tpSetup.Controls.Add(this.lvPauses);
            this.tpSetup.Controls.Add(this.mtbStartTime);
            this.tpSetup.Controls.Add(this.lblPause);
            this.tpSetup.Controls.Add(this.lblMatchdauer);
            this.tpSetup.Controls.Add(this.lblStartZeit);
            this.tpSetup.Controls.Add(this.label1);
            this.tpSetup.Controls.Add(this.btnSavePlan);
            this.tpSetup.Controls.Add(this.btnImportPlan);
            this.tpSetup.Controls.Add(this.btnCreatePlan);
            this.tpSetup.Controls.Add(this.lvTeams);
            this.tpSetup.Location = new System.Drawing.Point(4, 22);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetup.Size = new System.Drawing.Size(813, 510);
            this.tpSetup.TabIndex = 1;
            this.tpSetup.Text = "Setup";
            this.tpSetup.UseVisualStyleBackColor = true;
            // 
            // cbLoadLastBackupOnStart
            // 
            this.cbLoadLastBackupOnStart.AutoSize = true;
            this.cbLoadLastBackupOnStart.Location = new System.Drawing.Point(610, 180);
            this.cbLoadLastBackupOnStart.Name = "cbLoadLastBackupOnStart";
            this.cbLoadLastBackupOnStart.Size = new System.Drawing.Size(146, 17);
            this.cbLoadLastBackupOnStart.TabIndex = 9;
            this.cbLoadLastBackupOnStart.Text = "Load last backup on start";
            this.cbLoadLastBackupOnStart.UseVisualStyleBackColor = true;
            // 
            // cbCloseBackup
            // 
            this.cbCloseBackup.AutoSize = true;
            this.cbCloseBackup.Location = new System.Drawing.Point(610, 203);
            this.cbCloseBackup.Name = "cbCloseBackup";
            this.cbCloseBackup.Size = new System.Drawing.Size(114, 17);
            this.cbCloseBackup.TabIndex = 10;
            this.cbCloseBackup.Text = "Backup on closing";
            this.cbCloseBackup.UseVisualStyleBackColor = true;
            // 
            // cbAutoBackup
            // 
            this.cbAutoBackup.AutoSize = true;
            this.cbAutoBackup.Location = new System.Drawing.Point(610, 226);
            this.cbAutoBackup.Name = "cbAutoBackup";
            this.cbAutoBackup.Size = new System.Drawing.Size(163, 17);
            this.cbAutoBackup.TabIndex = 11;
            this.cbAutoBackup.Text = "AutoBackup every 5 Minutes";
            this.cbAutoBackup.UseVisualStyleBackColor = true;
            // 
            // btnSaveTable
            // 
            this.btnSaveTable.Location = new System.Drawing.Point(610, 151);
            this.btnSaveTable.Name = "btnSaveTable";
            this.btnSaveTable.Size = new System.Drawing.Size(115, 23);
            this.btnSaveTable.TabIndex = 8;
            this.btnSaveTable.Text = "Save Table";
            this.btnSaveTable.UseVisualStyleBackColor = true;
            this.btnSaveTable.Click += new System.EventHandler(this.btnSaveTable_Click);
            // 
            // mtbPauseLength
            // 
            this.mtbPauseLength.Location = new System.Drawing.Point(610, 23);
            this.mtbPauseLength.Mask = "90";
            this.mtbPauseLength.Name = "mtbPauseLength";
            this.mtbPauseLength.Size = new System.Drawing.Size(115, 20);
            this.mtbPauseLength.TabIndex = 3;
            // 
            // mtbGameLength
            // 
            this.mtbGameLength.Location = new System.Drawing.Point(464, 23);
            this.mtbGameLength.Mask = "00";
            this.mtbGameLength.Name = "mtbGameLength";
            this.mtbGameLength.Size = new System.Drawing.Size(115, 20);
            this.mtbGameLength.TabIndex = 2;
            // 
            // lblListPause
            // 
            this.lblListPause.AutoSize = true;
            this.lblListPause.Location = new System.Drawing.Point(316, 55);
            this.lblListPause.Name = "lblListPause";
            this.lblListPause.Size = new System.Drawing.Size(42, 13);
            this.lblListPause.TabIndex = 13;
            this.lblListPause.Text = "Pauses";
            // 
            // lvPauses
            // 
            this.lvPauses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTime,
            this.chPause});
            this.lvPauses.ContextMenuStrip = this.cmsPause;
            this.lvPauses.FullRowSelect = true;
            this.lvPauses.Location = new System.Drawing.Point(319, 71);
            this.lvPauses.MultiSelect = false;
            this.lvPauses.Name = "lvPauses";
            this.lvPauses.Size = new System.Drawing.Size(260, 266);
            this.lvPauses.TabIndex = 4;
            this.lvPauses.UseCompatibleStateImageBehavior = false;
            this.lvPauses.View = System.Windows.Forms.View.Details;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 86;
            // 
            // chPause
            // 
            this.chPause.Text = "Pauselength";
            this.chPause.Width = 170;
            // 
            // cmsPause
            // 
            this.cmsPause.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddPause,
            this.tsmiDeletePause});
            this.cmsPause.Name = "cmsPause";
            this.cmsPause.Size = new System.Drawing.Size(108, 48);
            // 
            // tsmiAddPause
            // 
            this.tsmiAddPause.Name = "tsmiAddPause";
            this.tsmiAddPause.Size = new System.Drawing.Size(107, 22);
            this.tsmiAddPause.Text = "Add";
            this.tsmiAddPause.Click += new System.EventHandler(this.tsmiAddPause_Click);
            // 
            // tsmiDeletePause
            // 
            this.tsmiDeletePause.Name = "tsmiDeletePause";
            this.tsmiDeletePause.Size = new System.Drawing.Size(107, 22);
            this.tsmiDeletePause.Text = "Delete";
            this.tsmiDeletePause.Click += new System.EventHandler(this.tsmiDeletePause_Click);
            // 
            // mtbStartTime
            // 
            this.mtbStartTime.Location = new System.Drawing.Point(319, 23);
            this.mtbStartTime.Mask = "90:00";
            this.mtbStartTime.Name = "mtbStartTime";
            this.mtbStartTime.Size = new System.Drawing.Size(115, 20);
            this.mtbStartTime.TabIndex = 1;
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.Location = new System.Drawing.Point(607, 7);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(140, 13);
            this.lblPause.TabIndex = 11;
            this.lblPause.Text = "Pauselength after the match";
            // 
            // lblMatchdauer
            // 
            this.lblMatchdauer.AutoSize = true;
            this.lblMatchdauer.Location = new System.Drawing.Point(461, 7);
            this.lblMatchdauer.Name = "lblMatchdauer";
            this.lblMatchdauer.Size = new System.Drawing.Size(64, 13);
            this.lblMatchdauer.TabIndex = 9;
            this.lblMatchdauer.Text = "Gamelength";
            // 
            // lblStartZeit
            // 
            this.lblStartZeit.AutoSize = true;
            this.lblStartZeit.Location = new System.Drawing.Point(316, 7);
            this.lblStartZeit.Name = "lblStartZeit";
            this.lblStartZeit.Size = new System.Drawing.Size(55, 13);
            this.lblStartZeit.TabIndex = 7;
            this.lblStartZeit.Text = "Start Time";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gray means that the team is not part of the competition (doubleclick on item)";
            // 
            // btnSavePlan
            // 
            this.btnSavePlan.Location = new System.Drawing.Point(610, 122);
            this.btnSavePlan.Name = "btnSavePlan";
            this.btnSavePlan.Size = new System.Drawing.Size(115, 23);
            this.btnSavePlan.TabIndex = 7;
            this.btnSavePlan.Text = "Save Plan";
            this.btnSavePlan.UseVisualStyleBackColor = true;
            this.btnSavePlan.Click += new System.EventHandler(this.btnSavePlan_Click);
            // 
            // btnImportPlan
            // 
            this.btnImportPlan.Location = new System.Drawing.Point(610, 93);
            this.btnImportPlan.Name = "btnImportPlan";
            this.btnImportPlan.Size = new System.Drawing.Size(115, 23);
            this.btnImportPlan.TabIndex = 6;
            this.btnImportPlan.Text = "Import Plan";
            this.btnImportPlan.UseVisualStyleBackColor = true;
            this.btnImportPlan.Click += new System.EventHandler(this.btnImportPlan_Click);
            // 
            // btnCreatePlan
            // 
            this.btnCreatePlan.Location = new System.Drawing.Point(610, 64);
            this.btnCreatePlan.Name = "btnCreatePlan";
            this.btnCreatePlan.Size = new System.Drawing.Size(115, 23);
            this.btnCreatePlan.TabIndex = 5;
            this.btnCreatePlan.Text = "Create Plan";
            this.btnCreatePlan.UseVisualStyleBackColor = true;
            this.btnCreatePlan.Click += new System.EventHandler(this.btnCreatePlan_Click);
            // 
            // lvTeams
            // 
            this.lvTeams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvTeams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTeam});
            this.lvTeams.ContextMenuStrip = this.cmsTeams;
            this.lvTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTeams.FullRowSelect = true;
            this.lvTeams.GridLines = true;
            this.lvTeams.Location = new System.Drawing.Point(7, 7);
            this.lvTeams.MultiSelect = false;
            this.lvTeams.Name = "lvTeams";
            this.lvTeams.Size = new System.Drawing.Size(292, 484);
            this.lvTeams.TabIndex = 0;
            this.lvTeams.UseCompatibleStateImageBehavior = false;
            this.lvTeams.View = System.Windows.Forms.View.Details;
            this.lvTeams.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvTeams_ColumnClick);
            this.lvTeams.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTeams_MouseDoubleClick);
            // 
            // chTeam
            // 
            this.chTeam.Text = "Team";
            this.chTeam.Width = 286;
            // 
            // cmsTeams
            // 
            this.cmsTeams.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsTeams.Name = "cmsTeams";
            this.cmsTeams.Size = new System.Drawing.Size(108, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tpPlan
            // 
            this.tpPlan.Controls.Add(this.cbFilter);
            this.tpPlan.Controls.Add(this.lvSpiele);
            this.tpPlan.Location = new System.Drawing.Point(4, 22);
            this.tpPlan.Name = "tpPlan";
            this.tpPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tpPlan.Size = new System.Drawing.Size(813, 510);
            this.tpPlan.TabIndex = 0;
            this.tpPlan.Text = "Plan";
            this.tpPlan.UseVisualStyleBackColor = true;
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(686, 483);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 3;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // lvSpiele
            // 
            this.lvSpiele.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSpiele.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chZeit,
            this.chHeim,
            this.chStand,
            this.chGast,
            this.chWertung});
            this.lvSpiele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSpiele.FullRowSelect = true;
            this.lvSpiele.GridLines = true;
            this.lvSpiele.Location = new System.Drawing.Point(3, 3);
            this.lvSpiele.MultiSelect = false;
            this.lvSpiele.Name = "lvSpiele";
            this.lvSpiele.Size = new System.Drawing.Size(807, 471);
            this.lvSpiele.TabIndex = 0;
            this.lvSpiele.UseCompatibleStateImageBehavior = false;
            this.lvSpiele.View = System.Windows.Forms.View.Details;
            this.lvSpiele.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSpiele_MouseDoubleClick);
            // 
            // chZeit
            // 
            this.chZeit.Text = "Time";
            this.chZeit.Width = 85;
            // 
            // chHeim
            // 
            this.chHeim.Text = "Home";
            this.chHeim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chHeim.Width = 158;
            // 
            // chStand
            // 
            this.chStand.Text = "Score";
            this.chStand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chGast
            // 
            this.chGast.Text = "Guest";
            this.chGast.Width = 396;
            // 
            // chWertung
            // 
            this.chWertung.Text = "Rating";
            // 
            // tpTable
            // 
            this.tpTable.Controls.Add(this.lvTable);
            this.tpTable.Location = new System.Drawing.Point(4, 22);
            this.tpTable.Name = "tpTable";
            this.tpTable.Size = new System.Drawing.Size(813, 510);
            this.tpTable.TabIndex = 2;
            this.tpTable.Text = "Table";
            this.tpTable.UseVisualStyleBackColor = true;
            // 
            // lvTable
            // 
            this.lvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRang,
            this.chMannschaft,
            this.chSpiele,
            this.chPunkte,
            this.chTore,
            this.chGegenTore,
            this.chDifferenz});
            this.lvTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTable.FullRowSelect = true;
            this.lvTable.GridLines = true;
            this.lvTable.Location = new System.Drawing.Point(3, 3);
            this.lvTable.MultiSelect = false;
            this.lvTable.Name = "lvTable";
            this.lvTable.Size = new System.Drawing.Size(807, 504);
            this.lvTable.TabIndex = 0;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            // 
            // chRang
            // 
            this.chRang.Text = "Rank";
            this.chRang.Width = 57;
            // 
            // chMannschaft
            // 
            this.chMannschaft.Text = "Team";
            this.chMannschaft.Width = 134;
            // 
            // chSpiele
            // 
            this.chSpiele.Text = "Matches played";
            this.chSpiele.Width = 131;
            // 
            // chPunkte
            // 
            this.chPunkte.Text = "Points";
            // 
            // chTore
            // 
            this.chTore.Text = "Goals for";
            this.chTore.Width = 85;
            // 
            // chGegenTore
            // 
            this.chGegenTore.Text = "Goals against";
            this.chGegenTore.Width = 122;
            // 
            // chDifferenz
            // 
            this.chDifferenz.Text = "Goal difference";
            this.chDifferenz.Width = 131;
            // 
            // tmrBackup
            // 
            this.tmrBackup.Enabled = true;
            this.tmrBackup.Interval = 300000;
            this.tmrBackup.Tick += new System.EventHandler(this.tmrBackup_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 560);
            this.Controls.Add(this.tbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Footballmanager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbMain.ResumeLayout(false);
            this.tpSetup.ResumeLayout(false);
            this.tpSetup.PerformLayout();
            this.cmsPause.ResumeLayout(false);
            this.cmsTeams.ResumeLayout(false);
            this.tpPlan.ResumeLayout(false);
            this.tpTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tpSetup;
        private System.Windows.Forms.Button btnSavePlan;
        private System.Windows.Forms.Button btnImportPlan;
        private System.Windows.Forms.Button btnCreatePlan;
        private System.Windows.Forms.ListView lvTeams;
        private System.Windows.Forms.ColumnHeader chTeam;
        private System.Windows.Forms.TabPage tpPlan;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ListView lvSpiele;
        private System.Windows.Forms.ColumnHeader chZeit;
        private System.Windows.Forms.ColumnHeader chHeim;
        private System.Windows.Forms.ColumnHeader chStand;
        private System.Windows.Forms.ColumnHeader chGast;
        private System.Windows.Forms.ColumnHeader chWertung;
        private System.Windows.Forms.TabPage tpTable;
        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ColumnHeader chRang;
        private System.Windows.Forms.ColumnHeader chMannschaft;
        private System.Windows.Forms.ColumnHeader chSpiele;
        private System.Windows.Forms.ColumnHeader chPunkte;
        private System.Windows.Forms.ColumnHeader chTore;
        private System.Windows.Forms.ColumnHeader chGegenTore;
        private System.Windows.Forms.ColumnHeader chDifferenz;
        private System.Windows.Forms.ContextMenuStrip cmsTeams;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbPauseLength;
        private System.Windows.Forms.MaskedTextBox mtbGameLength;
        private System.Windows.Forms.Label lblListPause;
        private System.Windows.Forms.ListView lvPauses;
        private System.Windows.Forms.ColumnHeader chPause;
        private System.Windows.Forms.MaskedTextBox mtbStartTime;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label lblMatchdauer;
        private System.Windows.Forms.Label lblStartZeit;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ContextMenuStrip cmsPause;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddPause;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePause;
        private System.Windows.Forms.Button btnSaveTable;
        private System.Windows.Forms.Timer tmrBackup;
        private System.Windows.Forms.CheckBox cbCloseBackup;
        private System.Windows.Forms.CheckBox cbAutoBackup;
        private System.Windows.Forms.CheckBox cbLoadLastBackupOnStart;
    }
}

