using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr4dhzzz31
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random random = new Random();
            List<string> list = new List<string>()
            {
                "!", "!", "N", "N", ",",",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z"

            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel!= null)
                {
                    int randomNumber = Random.Next(AssignIconsToSquares.Count);
                    iconLabel.Text = 


                }
            }   
        }
    }
}
