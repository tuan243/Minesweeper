using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form2 : Form
    {
        public event EventHandler TransferSettingsData;
        int maxNumberOfMine;
        private TextBox txt;
        string val;

        public Form2()
        {
            InitializeComponent();
            
            int row = (int)numericUpDown1.Value;
            int col = (int)numericUpDown2.Value;
            numericUpDown3.Maximum = (int)(0.8 * row * col);

            txt = (TextBox)numericUpDown3.Controls[1];
            txt.TextChanged += new EventHandler(txt_Changed);
            txt.Validating += new CancelEventHandler(txt_Validating);
        }

        private void txt_Changed(object sender, EventArgs e)
        {
            if (txt.Focused)
            {
                val = txt.Text;
            }
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Val: " + val);
        }





        private void customRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (customRdBtn.Checked == false)
            {
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
            }
            else
            {
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;                
            }
            //Properties.Settings;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (beginnerRdBtn.Checked == true)
            {
                Properties.Settings.Default.Setting = "Beginner";
                Properties.Settings.Default.colCount = 9;
                Properties.Settings.Default.rowCount = 9;
                Properties.Settings.Default.mineNumber = 10;
            }
            else if (intermediateRdBtn.Checked == true)
            {
                Properties.Settings.Default.Setting = "Intermediate";
                Properties.Settings.Default.colCount = 16;
                Properties.Settings.Default.rowCount = 16;
                Properties.Settings.Default.mineNumber = 40;
            }
            else if (advancedRdBtn.Checked == true)
            {
                Properties.Settings.Default.Setting = "Advanced";
                Properties.Settings.Default.colCount = 30;
                Properties.Settings.Default.rowCount = 16;
                Properties.Settings.Default.mineNumber = 99;
            }
            else
            {
                
                Properties.Settings.Default.Setting = "Custom";
                Properties.Settings.Default.rowCount = (int)numericUpDown1.Value;
                Properties.Settings.Default.colCount = (int)numericUpDown2.Value;
                Properties.Settings.Default.mineNumber = (int)numericUpDown3.Value;
            }
            Properties.Settings.Default.Save();
            TransferSettingsData(this, e);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string str = Properties.Settings.Default.Setting;
            if (str == "Beginner")
            {
                beginnerRdBtn.Checked = true;
            }
            else if (str == "Intermediate")
            {
                intermediateRdBtn.Checked = true;
            }
            else if (str == "Advanced")
            {
                advancedRdBtn.Checked = true;
            }
            else
            {
                customRdBtn.Checked = true;
                numericUpDown1.Value = Properties.Settings.Default.rowCount;
                numericUpDown2.Value = Properties.Settings.Default.colCount;
                numericUpDown3.Value = Properties.Settings.Default.mineNumber;
            }
            if (customRdBtn.Checked == false)
            {
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
            }
            else
            {
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value > numericUpDown3.Maximum)
            {
                toolTip1.Active = true;
            }
        }

        private void WightHeighChanged(object sender, EventArgs e)
        {
            int row = (int)numericUpDown1.Value;
            int col = (int)numericUpDown2.Value;
            numericUpDown3.Maximum = (int)(0.8 * row * col);
        }
    }
}
