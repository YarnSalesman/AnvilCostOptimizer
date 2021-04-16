using System;
using System.Drawing;
using System.Windows.Forms;
using Minecraft;

namespace AnvilCostOptimizer
{
    public partial class ItemForm : Form
    {
        private ItemInfo SelectedItemInfo { get; set; }
        public Item ResultItem { get; set; }

        public ItemForm(Item item, bool edit)
        {
            InitializeComponent();

            if (item == null || edit == false)
            {
                this.Text = "New Item";
                BtnDone.Enabled = false;
                
                if (item != null)
                {
                    CbItems.Items.Add(item.Info.Name);
                    CbItems.Items.Add(MC.Items[MC.BOOK].Name);
                }
                else
                {
                    CbItems.Items.AddRange(MC.GetItemNamesFromSet(0));
                }
            }
            else
            {
                this.Text = "Edit Item";
                CbItems.Enabled = false;
                SelectedItemInfo = item.Info;
                NudPenalty.Value = item.AnvilUses;
                PbItem.Image = Properties.Resources.ResourceManager.GetObject(SelectedItemInfo.Name) as Image;
                CbEnchantments.Items.AddRange(MC.GetEnchantmentNamesFromSet(SelectedItemInfo.ApplicableEnchantments));

                if (item.AppliedEnchantmentsList.Count != 0)
                {
                    foreach (Enchantment e in item.AppliedEnchantmentsList)
                    {
                        FormAddEnchantment(MC.Enchantments[e.Id].Name, e.Level, e.Preserved);
                    }
                }
            }
        }

        private void FormAddEnchantment(string e, int level, bool preserve)
        {
            if (SelectedItemInfo.Id == MC.BOOK)
            {
                BtnDone.Enabled = true;
            }

            EnchantmentInfo ei = MC.GetEnchantmentInfo(e);
            
            FlowLayoutPanel row = new FlowLayoutPanel
            {
                Size = new Size(288, 27)
            };

            Label elbl = new Label
            {
                Font = new Font("Microsoft Sans Serif", 9.25F, FontStyle.Regular,
                                  GraphicsUnit.Point, (byte)0),
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Size = new Size(170, 19),
                Location = new Point(3, 3),
                Text = ei.Name
            };

            NumericUpDown lud = new NumericUpDown
            {
                ReadOnly = true,
                Minimum = 1,
                BackColor = Color.White,
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(35, 20),
                Maximum = ei.Maxlevel,
                Value = level == -1 ? ei.Maxlevel : level,
                Margin = new Padding(3, 3, 36, 3)
            };

            Button rbtn = new Button
            {
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(70, 3),
                Size = new Size(24, 20),
                Text = "X"
            };
            rbtn.Click += new EventHandler(BtnRemove_Click);

            row.Controls.Add(elbl);
            row.Controls.Add(lud);

            UInt64 incompatibles = ei.IncompatibleEnchantments & SelectedItemInfo.ApplicableEnchantments;

            if (0 != incompatibles)
            {
                lud.Margin = new Padding(3, 3, 9, 3);

                CheckBox cb = new CheckBox
                {
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Margin = new Padding(3, 3, 9, 3),
                    Checked = preserve
                };
                
                row.Controls.Add(cb);

                foreach (string name in MC.GetEnchantmentNamesFromSet(incompatibles))
                {
                    CbEnchantments.Items.Remove(name);
                }
            }

            CbEnchantments.Items.Remove(ei.Name);

            row.Controls.Add(rbtn);
            FlpEnchantments.Controls.Add(row);
        }

        private void CbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItemInfo = MC.GetItemInfo(((sender as ComboBox).SelectedItem as string));
            PbItem.Image = Properties.Resources.ResourceManager.GetObject(SelectedItemInfo.Name) as Image;
            NudPenalty.Value = 0;
            CbEnchantments.Items.Clear();
            CbEnchantments.Items.AddRange(MC.GetEnchantmentNamesFromSet(SelectedItemInfo.ApplicableEnchantments));
            FlpEnchantments.Controls.Clear();
            BtnDone.Enabled = SelectedItemInfo.Id == MC.BOOK ? false : true;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel row = (sender as Button).Parent as FlowLayoutPanel;
            EnchantmentInfo ei = MC.GetEnchantmentInfo((row.Controls[0] as Label).Text);

            UInt64 incompatibles = ei.IncompatibleEnchantments & SelectedItemInfo.ApplicableEnchantments;

            if (0 != incompatibles)
            {
                if (incompatibles == (1UL << MC.RIPTIDE) &&
                   (!CbEnchantments.Items.Contains(MC.GetEnchantmentName(MC.CHANNELING)) &&
                    !CbEnchantments.Items.Contains(MC.GetEnchantmentName(MC.LOYALTY))))
                {
                    //Empty. So so empty.
                }
                else
                {
                    foreach (string name in MC.GetEnchantmentNamesFromSet(incompatibles))
                    {
                        CbEnchantments.Items.Add(name);
                    }
                }
            }

            CbEnchantments.Items.Add(ei.Name);

            FlpEnchantments.Controls.Remove(row);

            if (FlpEnchantments.Controls.Count == 0 && SelectedItemInfo.Id == MC.BOOK)
            {
                BtnDone.Enabled = false;
            }
        }

        private void BtnAddEnchantment_Click(object sender, EventArgs e)
        {
            if (CbEnchantments.SelectedItem is string)
            {
                FormAddEnchantment(CbEnchantments.SelectedItem as string, -1, false);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.ResultItem = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            Item ni = new Item(SelectedItemInfo.Id)
            {
                AnvilUses = (int)NudPenalty.Value
            };

            foreach (FlowLayoutPanel f in FlpEnchantments.Controls)
            {
                EnchantmentInfo ei = MC.GetEnchantmentInfo((f.Controls[0] as Label).Text);
                ni.AddEnchantment(ei.Id,
                                  (int)(f.Controls[1] as NumericUpDown).Value,
                                  (f.Controls[2] is CheckBox) ? (f.Controls[2] as CheckBox).Checked : false,
                                  true);
            }

            ResultItem = ni;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FlpEnchantments_MouseEnter(object sender, EventArgs e)
        {
            FlpEnchantments.Focus();
        }
    }
}
