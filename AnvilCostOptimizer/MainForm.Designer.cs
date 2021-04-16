namespace AnvilCostOptimizer
{
    partial class MainForm
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
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.FlpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnRun = new System.Windows.Forms.Button();
            this.FlpSteps = new System.Windows.Forms.FlowLayoutPanel();
            this.LblTotalCost = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.LblTarget = new System.Windows.Forms.Label();
            this.LblSacrifice = new System.Windows.Forms.Label();
            this.LblCost = new System.Windows.Forms.Label();
            this.LblResult = new System.Windows.Forms.Label();
            this.CbPresets = new System.Windows.Forms.ComboBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.LblPresets = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Location = new System.Drawing.Point(12, 12);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(69, 28);
            this.BtnAddItem.TabIndex = 0;
            this.BtnAddItem.Text = "ADD ITEM";
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // FlpItems
            // 
            this.FlpItems.AutoScroll = true;
            this.FlpItems.BackColor = System.Drawing.SystemColors.Control;
            this.FlpItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FlpItems.Location = new System.Drawing.Point(12, 51);
            this.FlpItems.Name = "FlpItems";
            this.FlpItems.Size = new System.Drawing.Size(347, 70);
            this.FlpItems.TabIndex = 3;
            this.FlpItems.WrapContents = false;
            this.FlpItems.MouseEnter += new System.EventHandler(this.FlpItems_MouseEnter);
            // 
            // BtnRun
            // 
            this.BtnRun.Location = new System.Drawing.Point(290, 383);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(69, 28);
            this.BtnRun.TabIndex = 4;
            this.BtnRun.Text = "RUN";
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // FlpSteps
            // 
            this.FlpSteps.AutoScroll = true;
            this.FlpSteps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FlpSteps.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlpSteps.Location = new System.Drawing.Point(12, 144);
            this.FlpSteps.Name = "FlpSteps";
            this.FlpSteps.Size = new System.Drawing.Size(347, 228);
            this.FlpSteps.TabIndex = 5;
            this.FlpSteps.WrapContents = false;
            this.FlpSteps.MouseEnter += new System.EventHandler(this.FlpSteps_MouseEnter);
            // 
            // LblTotalCost
            // 
            this.LblTotalCost.AutoSize = true;
            this.LblTotalCost.Location = new System.Drawing.Point(9, 391);
            this.LblTotalCost.Name = "LblTotalCost";
            this.LblTotalCost.Size = new System.Drawing.Size(77, 13);
            this.LblTotalCost.TabIndex = 6;
            this.LblTotalCost.Text = "TOTAL COST:";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(87, 12);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(69, 28);
            this.BtnClear.TabIndex = 7;
            this.BtnClear.Text = "CLEAR";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // LblTarget
            // 
            this.LblTarget.AutoSize = true;
            this.LblTarget.Location = new System.Drawing.Point(16, 135);
            this.LblTarget.Name = "LblTarget";
            this.LblTarget.Size = new System.Drawing.Size(51, 13);
            this.LblTarget.TabIndex = 8;
            this.LblTarget.Text = "TARGET";
            // 
            // LblSacrifice
            // 
            this.LblSacrifice.AutoSize = true;
            this.LblSacrifice.Location = new System.Drawing.Point(100, 135);
            this.LblSacrifice.Name = "LblSacrifice";
            this.LblSacrifice.Size = new System.Drawing.Size(62, 13);
            this.LblSacrifice.TabIndex = 9;
            this.LblSacrifice.Text = "SACRIFICE";
            // 
            // LblCost
            // 
            this.LblCost.AutoSize = true;
            this.LblCost.Location = new System.Drawing.Point(277, 135);
            this.LblCost.Name = "LblCost";
            this.LblCost.Size = new System.Drawing.Size(36, 13);
            this.LblCost.TabIndex = 10;
            this.LblCost.Text = "COST";
            // 
            // LblResult
            // 
            this.LblResult.AutoSize = true;
            this.LblResult.Location = new System.Drawing.Point(196, 135);
            this.LblResult.Name = "LblResult";
            this.LblResult.Size = new System.Drawing.Size(50, 13);
            this.LblResult.TabIndex = 11;
            this.LblResult.Text = "RESULT";
            // 
            // CbPresets
            // 
            this.CbPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPresets.FormattingEnabled = true;
            this.CbPresets.Items.AddRange(new object[] {
            "HELMET",
            "CHESTPLATE",
            "LEGGINGS",
            "BOOTS",
            "BOW",
            "SWORD",
            "AXE",
            "PICKAXE",
            "SHOVEL",
            "HOE",
            "FISHING ROD"});
            this.CbPresets.Location = new System.Drawing.Point(263, 16);
            this.CbPresets.Name = "CbPresets";
            this.CbPresets.Size = new System.Drawing.Size(95, 21);
            this.CbPresets.TabIndex = 12;
            this.CbPresets.SelectedIndexChanged += new System.EventHandler(this.CbPresets_SelectedIndexChanged);
            // 
            // BtnStop
            // 
            this.BtnStop.Enabled = false;
            this.BtnStop.Location = new System.Drawing.Point(215, 383);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(69, 28);
            this.BtnStop.TabIndex = 13;
            this.BtnStop.Text = "STOP";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // LblPresets
            // 
            this.LblPresets.AutoSize = true;
            this.LblPresets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPresets.Location = new System.Drawing.Point(203, 18);
            this.LblPresets.Name = "LblPresets";
            this.LblPresets.Size = new System.Drawing.Size(54, 16);
            this.LblPresets.TabIndex = 14;
            this.LblPresets.Text = "Presets";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 423);
            this.Controls.Add(this.LblPresets);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.CbPresets);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.LblTarget);
            this.Controls.Add(this.LblCost);
            this.Controls.Add(this.LblSacrifice);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.LblTotalCost);
            this.Controls.Add(this.FlpSteps);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.FlpItems);
            this.Controls.Add(this.BtnAddItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anvil Cost Optimizer";
            this.Icon = Properties.Resources.ANVIL;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.FlowLayoutPanel FlpItems;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.FlowLayoutPanel FlpSteps;
        private System.Windows.Forms.Label LblTotalCost;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label LblTarget;
        private System.Windows.Forms.Label LblSacrifice;
        private System.Windows.Forms.Label LblCost;
        private System.Windows.Forms.Label LblResult;
        private System.Windows.Forms.ComboBox CbPresets;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Label LblPresets;
    }
}

