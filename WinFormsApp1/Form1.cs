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

            Pen Penbriz = new Pen(Color.Red, 1);
            Pen Pencda = new Pen(Color.Blue, 1);

            Graphics Graphicsbriz = pictureBox2.CreateGraphics();
            Graphics Graphicscda = pictureBox1.CreateGraphics();

            brizfan(X1, Y1, X2, Y2);
            cdafan(X1, Y1, X2, Y2);

            void brizfan( int X1, int Y1, int X2, int Y2)
            {
                int Px = X2 - X1;
                int Py = Y2 - Y1;
                int E = 2 * Px - Py;
                int L = Px;

                Graphicsbriz.DrawRectangle(Penbriz, X1, Y1, 1, 1);

                for (int i = 0; i < E; i++) {
                    if (E >= 0)
                    {
                        X1 = X1 + 1;
                        Y1 = Y1 + 1;
                        E = E + 2 * (Py - Px);
                        Graphicsbriz.DrawRectangle(Penbriz, X1, Y1, 1, 1);
                    }
                    else {
                        X1 = X1 + 1;
                        Y1 = Y1 + 1;
                        E = E + 2 * Py;
                        Graphicsbriz.DrawRectangle(Penbriz, X1, Y1, 1, 1);
                    }
                }
            }

            void cdafan(float X1, float Y1, float X2, float Y2)
            {
                float Px = X2 - X1;
                float Py = Y2 - Y1;

                Graphicscda.DrawRectangle(Pencda, X1, Y1, 1, 1);        

                while(X1 < X2)
                {
                    X1 = X1 + 1;
                    Y1 = Y1 + (Py / Px);
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, 1, 1);
                }

                while (X2 < X1)
                {
                    X1 = X1 - 1;
                    Y1 = Y1 - (Py / Px);
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, 1, 1);
                }

                while (Y1 < Y2)
                {
                    X1 = X1 + (Px / Py);
                    Y1 = Y1 + 1;
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, 1, 1);
                }

                while (Y2 < Y1)
                {
                    X1 = X1 - (Px / Py);
                    Y1 = Y1 - 1;
                    Graphicscda.DrawRectangle(Pencda, X1, Y1, 1, 1);
                }
            }

        }
    }
}
