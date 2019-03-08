using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hebejskaklavesnice
{
    public partial class KlavesniceForm : Form
    {
        public DBManager dBManager = null;
        public KlavesniceForm()
        {
            InitializeComponent();
            dBManager = new DBManager();
        }


        String vysledek = "b";
        private void Dד_Click(object sender, EventArgs e)
        {
            t1.Text = t1.Text + "d";
        }

        private void KlavesniceForm_Load(object sender, EventArgs e)
        {

        }

        private void t1_TextChanged(object sender, EventArgs e)
        {
            t2.Text = String.Empty;
            string temp = String.Empty;
            foreach (char letter in t1.Text.ToCharArray())
            {
                char convertedChar = ConvertToHeb(letter,out bool succeslyFormated);
                if (succeslyFormated)
                {
                    temp = temp + convertedChar.ToString();
                }
                else
                    continue;
            }
            t2.Text = t2.Text + temp;

        }


        private char ConvertToHeb(char input, out bool success)
        {
            int i = 0;
            string unicodeCode = dBManager.GetColumn("SELECT hb FROM slovnik where cs = '" + input + "'");
            if (unicodeCode != null)
            {
                i = int.Parse(unicodeCode.Substring(2), System.Globalization.NumberStyles.HexNumber);
                success = true;
            }
            else
                success = false;

            return (char)i;

            
        }
    }

}
