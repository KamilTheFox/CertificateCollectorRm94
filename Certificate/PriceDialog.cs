using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certificate
{
    public partial class PriceDialog: Form
    {
        public PriceDialog(params int[] ints)
        {
            InitializeComponent();
            numericUpDown1.Value = ints[0];
            numericUpDown2.Value = ints[1];
            numericUpDown3.Value = ints[2];
        }

        public int MinimumPremium => (int)numericUpDown1.Value;

        public int ThresholdPrice => (int)numericUpDown2.Value;
        public int PremiumPercentage => (int)numericUpDown3.Value;

    }
}
