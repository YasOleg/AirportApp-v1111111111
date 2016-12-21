using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AirportApp
{
    public partial class AddForm : Form
    {
        public AddForm(MainForm _frm)
        {
            InitializeComponent();
        }
        
         private void btnSave_Click(object sender, EventArgs e)
        {
            string lines = tbNumberFly.Text + "/" + tbArrival.Text + "/" + tbDepart.Text + "/" +
                                tbDirection.Text + "/" + tbAirline.Text + "/" + tbTerminal.Text + "/" +
                                cbStatus.Text;
          
            if (tbNumberFly.Text == "" && tbArrival.Text == "" && tbDepart.Text == "" &&
                tbDirection.Text == "" && tbAirline.Text == "" && tbTerminal.Text == "" &&
                cbStatus.Text == "")
            {
                MessageBox.Show("Write all elements!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else DataClass.dataAdd(lines); 
        }
    }
}
