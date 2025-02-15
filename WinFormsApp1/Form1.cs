using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int X1 = int.Parse(textBox1.Text);
            int Y1 = int.Parse(textBox2.Text);
            int X2 = int.Parse(textBox3.Text);
            int Y2 = int.Parse(textBox4.Text);

            int size = 4;

            Pen Penbriz = new Pen(Color.Red, 1);
            Pen Pencda = new Pen(Color.Blue, 1);

            Graphics Graphicsbriz = pictureBox2.CreateGraphics();
            Graphics Graphicscda = pictureBox1.CreateGraphics();

            brizfan(X1, Y1, X2, Y2);
            cdafan(X1, Y1, X2, Y2);

            void brizfan(int X1, int Y1, int X2, int Y2)
            {
                int Px = Math.Abs(X2 - X1);  // Длина по оси X
                int Py = Math.Abs(Y2 - Y1);  // Длина по оси Y
                int sx = (X1 < X2) ? 1 : -1; // Направление по оси X
                int sy = (Y1 < Y2) ? 1 : -1; // Направление по оси Y
                int E = Px - Py;

                while (true)
                {

                    Graphicsbriz.DrawRectangle(Penbriz, X1, Y1, size, size);

                    if (X1 == X2 && Y1 == Y2) break;

                    int E2 = E * 2;

                    if (E2 > -Py)
                    {
                        E -= Py;
                        X1 += sx;
                    }
                    if (E2 < Px)
                    {
                        E += Px;
                        Y1 += sy;
                    }
                }
            }

            void cdafan(float X1, float Y1, float X2, float Y2)
            {
                float Px = X2 - X1;
                float Py = Y2 - Y1;

                Graphicscda.DrawRectangle(Pencda, X1, Y1, size, size);

                while (X1 < X2)
                {
                    X1 = X1 + 1;
                    Y1 = Y1 + (Py / Px);
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, size, size);
                }

                while (X2 < X1)
                {
                    X1 = X1 - 1;
                    Y1 = Y1 - (Py / Px);
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, size, size);
                }

                while (Y1 < Y2)
                {
                    X1 = X1 + (Px / Py);
                    Y1 = Y1 + 1;
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, size, size);
                }

                while (Y2 < Y1)
                {
                    X1 = X1 - (Px / Py);
                    Y1 = Y1 - 1;
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, size, size);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }
    }
}
