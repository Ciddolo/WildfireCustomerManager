using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WildfireCustomersManager
{
    public partial class FormShowCoupons : Form
    {
        public FormShowCoupons()
        {
            InitializeComponent();
        }

        public void LoadGrid(List<Coupon> coupons)
        {
            for (int i = 0; i < coupons.Count; i++)
            {
                dataGridCoupons.Rows.Add();
                dataGridCoupons.Rows[i].Cells[0].Value = coupons[i].EmissionDate.ToString("d");
                dataGridCoupons.Rows[i].Cells[1].Value = coupons[i].ExpireDate.ToString("d");
                dataGridCoupons.Rows[i].Cells[2].Value = coupons[i].InitialValue;
                dataGridCoupons.Rows[i].Cells[3].Value = coupons[i].CurrentValue;
            }
        }
    }
}
