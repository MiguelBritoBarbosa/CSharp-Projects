using System.Drawing;

namespace Projeto1Bim
{
    public partial class Form1 : Form
    {
        bool desenhaReta = false;
        int x0 = 0;
        int y0 = 0;
        int m = 0;
        int x1 = 0;
        int b = 0;
        int y1 = 0;

        public Form1()
        {
            InitializeComponent();
        }


        public Pen CriaCaneta()
        {
            Color Cor = new Color();
            Cor = Color.FromArgb(0, 0, 0);
            return new Pen(Cor, 2);
        }


        public void PlanoCartesiano(PaintEventArgs e)
        {
            Pen Caneta = CriaCaneta();
            e.Graphics.DrawLine(Caneta, 0, 325, 1050, 325);
            e.Graphics.DrawLine(Caneta, 525, 0, 525, 650);
        }

        public void Linha(PaintEventArgs e, int x0, int y0, int x1, int y1)
        {
            x0 += 525;
            x1 += 525;
            y0 += 325;
            y1 += 325;
            Pen Caneta = CriaCaneta();
            e.Graphics.DrawLine(Caneta, x0, y0, x1, y1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PlanoCartesiano(e);
            if (desenhaReta)
            {
                Linha(e, x0, y0, x1, y1);
            }
            desenhaReta = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x0 = int.Parse(xInicial.Text);
            y0 = int.Parse(yInicial.Text);
            m = int.Parse(mAngular.Text);
            x1 = int.Parse(xFinal.Text);
            b = int.Parse(bLinear.Text);

            y1 = m * x1 + b;

            y0 = y0 * -1;
            y1 = y1 * -1;
            equacao.Text = $"y = {m}x + {b} = {y1}";
            desenhaReta = true;
            Invalidate();



        }
    }
}