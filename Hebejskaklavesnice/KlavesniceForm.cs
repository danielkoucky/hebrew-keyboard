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
            // if (t1.Text == "d")
            // {
            //     vysledek = "ד";
            //         }

            //textLabel.Text = vysledek;
            t1.Text = t1.Text + "d";
            




        }

        private void KlavesniceForm_Load(object sender, EventArgs e)
        {

        }

        private void t1_TextChanged(object sender, EventArgs e)
        {
            t2.Text = ConvertToHeb(t1.Text[0]).ToString();
        }


        private char ConvertToHeb(char input)
        {
            char result = 'b';
            return  dBManager.GetColumn("SELECT hb FROM slovnik where cs = '" + input + "'").ToCharArray()[0];
            

            
        }
    }

}
