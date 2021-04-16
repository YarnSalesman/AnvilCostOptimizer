using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minecraft;
using Optimizer;

namespace AnvilCostOptimizer
{
    public partial class MainForm : Form
    {
        private class CPictureBox<T> : PictureBox
        {
            public T Data { get; set; }
            public ToolTip TT { get; set; }

            public CPictureBox(T data)
            {
                Data = data;
                TT = new ToolTip
                {
                    UseAnimation = false,
                    UseFading = false,
                    ShowAlways = true,
                    AutoPopDelay = 10000,
                    InitialDelay = 70,
                    ReshowDelay = 500
                };
            }
        }

        private Item RestrictItem { get; set; }
        private int RestrictItemCount { get; set; }
        private CancellationTokenSource CTSrc { get; set; }
        private CancellationToken CToken { get; set; }

        public MainForm()
        {
            InitializeComponent();
            RestrictItemCount = 0;
        }

        private void AddItem(Item item)
        {
            CPictureBox<Item> cpbItem = new CPictureBox<Item>(item)
            {
                Image = Properties.Resources.ResourceManager.GetObject(item.Info.Name) as Image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                ClientSize = new Size(43, 43),
                Cursor = Cursors.Hand
            };
            cpbItem.Click += CpbItem_Click;

            Button btnItemRemove = new Button
            {
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(10, 10),
                UseVisualStyleBackColor = false,
                Visible = true
            };
            btnItemRemove.FlatAppearance.BorderSize = 1;
            btnItemRemove.Click += BtnItemRemove_Click;

            Panel pnlItem = new Panel();
            pnlItem.Controls.Add(btnItemRemove);
            pnlItem.Controls.Add(cpbItem);
            pnlItem.Size = new Size(43, 43);

            FlpItems.Controls.Add(pnlItem);

            if (item.Info.Id != MC.BOOK)
            {
                RestrictItemCount++;
                RestrictItem = item;
            }

            cpbItem.TT.SetToolTip(cpbItem, cpbItem.Data.PrintItemInfo());
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            using (ItemForm itemForm = new ItemForm(RestrictItem, false))
            {
                DialogResult retval = itemForm.ShowDialog();

                if (retval == DialogResult.OK)
                {
                    AddItem(itemForm.ResultItem);
                }
            }
        }

        private void CpbItem_Click(object sender, EventArgs e)
        {
            using (ItemForm itemForm = new ItemForm((sender as CPictureBox<Item>).Data, true))
            {
                DialogResult retval = itemForm.ShowDialog();

                if (retval == DialogResult.OK)
                {
                    CPictureBox<Item> cpbItem = sender as CPictureBox<Item>;
                    cpbItem.Data = itemForm.ResultItem;
                    cpbItem.TT.SetToolTip(cpbItem, itemForm.ResultItem.PrintItemInfo());
                }
            }
        }

        private void BtnItemRemove_Click(object sender, EventArgs e)
        {
            Item selectedItem = ((sender as Button).Parent.Controls[1] as CPictureBox<Item>).Data;
            
            if (RestrictItem != null && RestrictItem.Info.Id == selectedItem.Info.Id)
            {
                if (--RestrictItemCount == 0)
                {
                    RestrictItem = null;
                }
            }

            FlpItems.Controls.Remove((sender as Button).Parent);
        }

        private void ToggleFormControls(bool toggle)
        {
            if (toggle == true)
            {
                BtnAddItem.Enabled = false;
                BtnClear.Enabled = false;
                CbPresets.Enabled = false;
                FlpItems.Enabled = false;
                FlpSteps.Enabled = false;
                BtnRun.Enabled = false;
                BtnStop.Enabled = true;
            }
            else
            {
                BtnAddItem.Enabled = true;
                BtnClear.Enabled = true;
                CbPresets.Enabled = true;
                FlpItems.Enabled = true;
                FlpSteps.Enabled = true;
                BtnRun.Enabled = true;
                BtnStop.Enabled = false;
            }
        }

        private async void BtnRun_Click(object sender, EventArgs e)
        {
            if (FlpItems.Controls.Count < 2)
            {
                MessageBox.Show("Nothing to compute", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FlpSteps.Controls.Clear();

            List<Item> itemList = new List<Item>();
            
            foreach (Panel p in FlpItems.Controls)
            {
                itemList.Add((p.Controls[1] as CPictureBox<Item>).Data);
            }

            ToggleFormControls(true);
            CTSrc  = new CancellationTokenSource();
            CToken = CTSrc.Token;
            OptimizerC o = new OptimizerC(CToken);
            Tuple<List<AnvilStep>,int> tResult = await Task<List<AnvilStep>>.Run(() => o.StartOptTask(itemList), CTSrc.Token);
            ToggleFormControls(false);
            CTSrc.Dispose();
            int totalCost = tResult.Item2;
            List<AnvilStep> stepList = tResult.Item1;

            if (stepList == null)
            {
                MessageBox.Show("Could not combine items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LblTotalCost.Text = "TOTAL COST: " + totalCost.ToString();

            for (int i = 0; i < stepList.Count; i++)
            {
                AnvilStep a = stepList[i];

                CPictureBox<object> p1 = new CPictureBox<object>(null)
                {
                    Margin = new Padding(3, 3, 42, 3),
                    Size = new Size(44, 44),
                    Image = Properties.Resources.ResourceManager.GetObject(a.Target.Info.Name) as Image,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                p1.TT.SetToolTip(p1, a.Target.PrintItemInfo());

                CPictureBox<object> p2 = new CPictureBox<object>(null)
                {
                    Margin = new Padding(3, 3, 42, 3),
                    Size = new Size(44, 44),
                    Image = Properties.Resources.ResourceManager.GetObject(a.Sacrifice.Info.Name) as Image,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                p2.TT.SetToolTip(p2, a.Sacrifice.PrintItemInfo());

                CPictureBox<object> p3 = new CPictureBox<object>(null)
                {
                    Margin = new Padding(3, 3, 42, 3),
                    Size = new Size(44, 44),
                    Image = Properties.Resources.ResourceManager.GetObject(a.Result.Info.Name) as Image,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                p3.TT.SetToolTip(p3, a.Result.PrintItemInfo());

                Label lbl = new Label
                {
                    Text = a.Cost.ToString(),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Size = new Size(35, 13)
                };

                FlowLayoutPanel row = new FlowLayoutPanel
                {
                    Size = new Size(310, 50)
                };
                row.Controls.Add(p1);
                row.Controls.Add(p2);
                row.Controls.Add(p3);
                row.Controls.Add(lbl);

                FlpSteps.Controls.Add(row);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // autoscroll bars may not disappear after clearing controls
            LblTotalCost.Text = "TOTAL COST:";
            CbPresets.SelectedIndex = -1;
            FlpItems.Controls.Clear();
            FlpSteps.Controls.Clear();
            RestrictItem = null;
            RestrictItemCount = 0;
        }

        private void FlpSteps_MouseEnter(object sender, EventArgs e)
        {
            FlpSteps.Focus();
        }

        private void FlpItems_MouseEnter(object sender, EventArgs e)
        {
            FlpItems.Focus();
        }

        private void CbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = ((sender as ComboBox).SelectedItem as string);

            FlpItems.Controls.Clear();

            switch (selectedItem)
            {
                case "HELMET":
                    {
                        Item item  = new Item(MC.HELMET);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        Item book5 = new Item(MC.BOOK);
                        Item book6 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.AQUA_AFFINITY, 1, false, true);
                        book2.AddEnchantment(MC.MENDING, 1, false, true);
                        book3.AddEnchantment(MC.PROTECTION, 4, false, true);
                        book4.AddEnchantment(MC.RESPIRATION, 3, false, true);
                        book5.AddEnchantment(MC.THORNS, 3, false, true);
                        book6.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        AddItem(book5);
                        AddItem(book6);
                        break;
                    }
                case "CHESTPLATE":
                    {
                        Item item  = new Item(MC.CHESTPLATE);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.MENDING, 1, false, true);
                        book2.AddEnchantment(MC.PROTECTION, 4, false, true);
                        book3.AddEnchantment(MC.THORNS, 3, false, true);
                        book4.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        break;
                    }
                case "LEGGINGS":
                    {
                        Item item  = new Item(MC.LEGGINGS);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.MENDING, 1, false, true);
                        book2.AddEnchantment(MC.PROTECTION, 4, false, true);
                        book3.AddEnchantment(MC.THORNS, 3, false, true);
                        book4.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        break;
                    }
                case "BOOTS":
                    {
                        Item item  = new Item(MC.BOOTS);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        Item book5 = new Item(MC.BOOK);
                        Item book6 = new Item(MC.BOOK);
                        Item book7 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.DEPTH_STRIDER, 3, false, true);
                        book2.AddEnchantment(MC.FEATHER_FALLING, 4, false, true);
                        book3.AddEnchantment(MC.MENDING, 1, false, true);
                        book4.AddEnchantment(MC.PROTECTION, 4, false, true);
                        book5.AddEnchantment(MC.SOUL_SPEED, 3, false, true);
                        book6.AddEnchantment(MC.THORNS, 3, false, true);
                        book7.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        AddItem(book5);
                        AddItem(book6);
                        AddItem(book7);
                        break;
                    }
                case "BOW":
                    {
                        Item item  = new Item(MC.BOW);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        Item book5 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.FLAME, 1, false, true);
                        book2.AddEnchantment(MC.INFINITY, 1, false, true);
                        book3.AddEnchantment(MC.POWER, 5, false, true);
                        book4.AddEnchantment(MC.PUNCH, 2, false, true);
                        book5.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        AddItem(book5);
                        break;
                    }
                case "SWORD":
                    {
                        Item item  = new Item(MC.SWORD);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        Item book5 = new Item(MC.BOOK);
                        Item book6 = new Item(MC.BOOK);
                        Item book7 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.FIRE_ASPECT, 2, false, true);
                        book2.AddEnchantment(MC.KNOCKBACK, 2, false, true);
                        book3.AddEnchantment(MC.LOOTING, 3, false, true);
                        book4.AddEnchantment(MC.MENDING, 1, false, true);
                        book5.AddEnchantment(MC.SHARPNESS, 5, false, true);
                        book6.AddEnchantment(MC.SWEEPING_EDGE, 3, false, true);
                        book7.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        AddItem(book5);
                        AddItem(book6);
                        AddItem(book7);
                        break;
                    }
                case "AXE":
                    {
                        Item item  = new Item(MC.AXE);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.EFFICIENCY, 5, false, true);
                        book2.AddEnchantment(MC.MENDING, 1, false, true);
                        book3.AddEnchantment(MC.SHARPNESS, 5, false, true);
                        book4.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        break;
                    }
                case "PICKAXE":
                    {
                        Item item  = new Item(MC.PICKAXE);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.EFFICIENCY, 5, false, true);
                        book2.AddEnchantment(MC.MENDING, 1, false, true);
                        book3.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        break;
                    }
                case "SHOVEL":
                    {
                        Item item  = new Item(MC.SHOVEL);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.EFFICIENCY, 5, false, true);
                        book2.AddEnchantment(MC.MENDING, 1, false, true);
                        book3.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        break;
                    }
                case "HOE":
                    {
                        Item item  = new Item(MC.HOE);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.EFFICIENCY, 5, false, true);
                        book2.AddEnchantment(MC.FORTUNE, 3, false, true);
                        book3.AddEnchantment(MC.MENDING, 1, false, true);
                        book4.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        break;
                    }
                case "FISHING ROD":
                    {
                        Item item  = new Item(MC.FISHING_ROD);
                        Item book1 = new Item(MC.BOOK);
                        Item book2 = new Item(MC.BOOK);
                        Item book3 = new Item(MC.BOOK);
                        Item book4 = new Item(MC.BOOK);
                        book1.AddEnchantment(MC.LUCK_OF_THE_SEA, 3, false, true);
                        book2.AddEnchantment(MC.LURE, 3, false, true);
                        book3.AddEnchantment(MC.MENDING, 1, false, true);
                        book4.AddEnchantment(MC.UNBREAKING, 3, false, true);
                        AddItem(item);
                        AddItem(book1);
                        AddItem(book2);
                        AddItem(book3);
                        AddItem(book4);
                        break;
                    }
                default:
                    break;
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            CTSrc.Cancel();
        }
    }
}
