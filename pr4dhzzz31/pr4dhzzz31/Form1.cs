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
            // Методы
            InitializeComponent();
            AssignIconsToSquares();
        }
        // Все метки будут иметь случайные значки из списка icons.
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        Label firstClicked = null;
        Label secondClicked = null;
        int timeLeft;
        private object timeLabel;

        // Переменная tableLayoutPanel1_Paint
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Метод AssignIconsToSquares()
        // присваивает каждой метке из tableLayoutPanel1 случайный значок из списка icons.
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        // Метод label1_Click() вызывается при щелчке на метке.
        // Если таймер уже запущен или метка уже открыта,метод завершается.
        // Иначе, если firstClicked еще не задан, щелкнутая метка становится
        // первой открытой меткой и ее цвет изменяется на черный.
        // Иначе, щелкнутая метка становится второй открытой меткой и ее цвет также изменяется
        // на черный. После этого вызывается метод CheckForWinner()
        // для проверки наличия победителя. Если открытые метки совпадают,
        // переменные firstClicked и secondClicked обнуляются.
        // В противном случае,запускается таймер.
        private void label1_click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();

            }
        }

        // Метод timer1_Tick() выполняется каждый раз, когда срабатывает таймер.
        // В этом методе таймер останавливается, цвет открытых меток меняется на цвет фона,
        // а затем переменные firstClicked и secondClicked обнуляются. 
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            // Если нет ни одной метки с цветом текста, равным цвету фона,
            // отображается сообщение о победе с заголовком "Ты что победил?".
            MessageBox.Show("Ты победил. Так дежать. Сыграем еще раз?");
        }
    }
}



