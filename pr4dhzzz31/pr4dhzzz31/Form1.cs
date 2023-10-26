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
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
    }
    private void AssignIconsToSquares()
    {
        foreach (Control control in TableLayoutPanel1.Controls)
        {
            Label iconLabel = control as Label1;
            if (iconLabel != null)
            {
                int randomNamber = Random.Next(icons.Count);
                iconlabel.Text = icons[randomNamber];
                icons.RemoveAt(randomNamber);
            }
        }
    }


