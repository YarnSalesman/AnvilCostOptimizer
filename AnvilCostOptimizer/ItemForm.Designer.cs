namespace AnvilCostOptimizer
{
    partial class ItemForm
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
            this.BtnDone = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAddEnchantment = new System.Windows.Forms.Button();
            this.CbItems = new System.Windows.Forms.ComboBox();
            this.PbItem = new System.Windows.Forms.PictureBox();
            this.FlpEnchantments = new System.Windows.Forms.FlowLayoutPanel();
            this.NudPenalty = new System.Windows.Forms.NumericUpDown();
            this.LblPenalty = new System.Windows.Forms.Label();
            this.CbEnchantments = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPenalty)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDone
            // 
            this.BtnDone.Location = new System.Drawing.Point(270, 11);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(59, 48);
            this.BtnDone.TabIndex = 0;
            this.BtnDone.Text = "DONE";
            this.BtnDone.UseVisualStyleBackColor = true;
            this.BtnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(270, 64);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(59, 48);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnAddEnchantment
            // 
            this.BtnAddEnchantment.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddEnchantment.Location = new System.Drawing.Point(117, 92);
            this.BtnAddEnchantment.Name = "BtnAddEnchantment";
            this.BtnAddEnchantment.Size = new System.Drawing.Size(147, 20);
            this.BtnAddEnchantment.TabIndex = 2;
            this.BtnAddEnchantment.Text = "ADD ENCHANTMENT";
            this.BtnAddEnchantment.UseVisualStyleBackColor = true;
            this.BtnAddEnchantment.Click += new System.EventHandler(this.BtnAddEnchantment_Click);
            // 
            // CbItems
            // 
            this.CbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbItems.FormattingEnabled = true;
            this.CbItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CbItems.Location = new System.Drawing.Point(118, 12);
            this.CbItems.Name = "CbItems";
            this.CbItems.Size = new System.Drawing.Size(146, 21);
            this.CbItems.TabIndex = 3;
            this.CbItems.SelectedIndexChanged += new System.EventHandler(this.CbItems_SelectedIndexChanged);
            // 
            // PbItem
            // 
            this.PbItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbItem.Location = new System.Drawing.Point(12, 12);
            this.PbItem.Name = "PbItem";
            this.PbItem.Size = new System.Drawing.Size(100, 100);
            this.PbItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbItem.TabIndex = 4;
            this.PbItem.TabStop = false;
            // 
            // FlpEnchantments
            // 
            this.FlpEnchantments.AutoScroll = true;
            this.FlpEnchantments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FlpEnchantments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlpEnchantments.Location = new System.Drawing.Point(11, 118);
            this.FlpEnchantments.Name = "FlpEnchantments";
            this.FlpEnchantments.Size = new System.Drawing.Size(318, 119);
            this.FlpEnchantments.TabIndex = 5;
            this.FlpEnchantments.WrapContents = false;
            this.FlpEnchantments.MouseEnter += new System.EventHandler(this.FlpEnchantments_MouseEnter);
            // 
            // NudPenalty
            // 
            this.NudPenalty.BackColor = System.Drawing.Color.White;
            this.NudPenalty.Location = new System.Drawing.Point(225, 39);
            this.NudPenalty.Name = "NudPenalty";
            this.NudPenalty.ReadOnly = true;
            this.NudPenalty.Size = new System.Drawing.Size(39, 20);
            this.NudPenalty.TabIndex = 6;
            this.NudPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblPenalty
            // 
            this.LblPenalty.AutoSize = true;
            this.LblPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPenalty.Location = new System.Drawing.Point(130, 39);
            this.LblPenalty.Name = "LblPenalty";
            this.LblPenalty.Size = new System.Drawing.Size(89, 15);
            this.LblPenalty.TabIndex = 7;
            this.LblPenalty.Text = "Work Penalties";
            // 
            // CbEnchantments
            // 
            this.CbEnchantments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEnchantments.FormattingEnabled = true;
            this.CbEnchantments.Location = new System.Drawing.Point(118, 65);
            this.CbEnchantments.Name = "CbEnchantments";
            this.CbEnchantments.Size = new System.Drawing.Size(146, 21);
            this.CbEnchantments.Sorted = true;
            this.CbEnchantments.TabIndex = 8;
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 251);
            this.Controls.Add(this.CbEnchantments);
            this.Controls.Add(this.LblPenalty);
            this.Controls.Add(this.NudPenalty);
            this.Controls.Add(this.FlpEnchantments);
            this.Controls.Add(this.PbItem);
            this.Controls.Add(this.CbItems);
            this.Controls.Add(this.BtnAddEnchantment);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.PbItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPenalty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDone;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnAddEnchantment;
        private System.Windows.Forms.ComboBox CbItems;
        private System.Windows.Forms.PictureBox PbItem;
        private System.Windows.Forms.FlowLayoutPanel FlpEnchantments;
        private System.Windows.Forms.NumericUpDown NudPenalty;
        private System.Windows.Forms.Label LblPenalty;
        private System.Windows.Forms.ComboBox CbEnchantments;
    }
}