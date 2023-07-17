using System.Numerics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Projeto2Bim
{
    public partial class Form1 : Form
    {

        string tipoDesenho = "linha";
        int pontos;
        int pontosSalvos;
        int[] x = new int[5];
        int[] y = new int[5];
        bool pintar = false;
        Pen caneta1;
        Pen caneta2;
        bool mouseButtonClick;
        bool Cor1Ou2;


        #region Primitivas
        public Color CriaCor(int r, int g, int b)
        {
            Color Cor = new Color();
            Cor = Color.FromArgb(r, g, b);
            return Cor;
        }

        public Pen CriaCaneta(int r, int g, int b, int espessura, float[] dashPattern)
        {
            Color cor = CriaCor(r, g, b);
            Pen caneta = new Pen(cor, espessura);
            caneta.DashPattern = dashPattern;
            return caneta;
        }

        public void Ponto(PaintEventArgs e, int x, int y, Pen Caneta)
        {
            e.Graphics.DrawLine(Caneta, x, y, x + 1, y);
        }

        public void Linha(PaintEventArgs e, int x0, int y0, int x1, int y1, Pen Caneta)
        {
            e.Graphics.DrawLine(Caneta, x0, y0, x1, y1);
        }

        public void Retangulo(PaintEventArgs e, int x, int y, int x1, int y1)
        {
            Pen Caneta;
            if (mouseButtonClick)
            {
                Caneta = caneta1;
            }
            else
            {
                Caneta = caneta2;
            }
            Linha(e, x, y, x1, y, Caneta);
            Linha(e, x1, y, x1, y1, Caneta);
            Linha(e, x1, y1, x, y1, Caneta);
            Linha(e, x, y1, x, y, Caneta);
        }
        public void Losango(PaintEventArgs e, int x, int y, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Pen Caneta;
            if (mouseButtonClick)
            {
                Caneta = caneta1;
            }
            else
            {
                Caneta = caneta2;
            }
            Linha(e, x, y, x1, y1, Caneta);
            Linha(e, x1, y1, x2, y2, Caneta);
            Linha(e, x2, y2, x3, y3, Caneta);
            Linha(e, x3, y3, x, y, Caneta);
        }
        public void Triangulo(PaintEventArgs e, int x, int y, int x1, int y1, int x2, int y2)
        {
            Pen Caneta;
            if (mouseButtonClick)
            {
                Caneta = caneta1;
            }
            else
            {
                Caneta = caneta2;
            }
            Linha(e, x, y, x1, y1, Caneta);
            Linha(e, x1, y1, x2, y2, Caneta);
            Linha(e, x2, y2, x, y, Caneta);
        }

        public void Pentagono(PaintEventArgs e, int x, int y, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            Pen Caneta;
            if (mouseButtonClick)
            {
                Caneta = caneta1;
            }
            else
            {
                Caneta = caneta2;
            }
            Linha(e, x, y, x1, y1, Caneta);
            Linha(e, x1, y1, x2, y2, Caneta);
            Linha(e, x2, y2, x3, y3, Caneta);
            Linha(e, x3, y3, x4, y4, Caneta);
            Linha(e, x4, y4, x, y, Caneta);
        }

        public void Elipse(PaintEventArgs e, int Xc, int Yc, int Lx, int Ay)
        {
            Pen Caneta;
            if (mouseButtonClick)
            {
                Caneta = caneta1;
            }
            else
            {
                Caneta = caneta2;
            }
            e.Graphics.DrawEllipse(Caneta, Xc, Yc, Lx, Ay);
        }

        public void Circulo(PaintEventArgs e, int xc, int yc, int raio, int Ti, int Tf)
        {
            Pen Caneta;
            if (mouseButtonClick)
            {
                Caneta = caneta1;
            }
            else
            {
                Caneta = caneta2;
            }
            for (int teta = Ti; teta <= Tf; teta++)
            {
                int x = (int)(xc + raio * Math.Cos(teta * (Math.PI / 180)));
                int y = (int)(yc + raio * Math.Sin(teta * (Math.PI / 180)));
                Ponto(e, x, y, Caneta);
            }
        }

        #endregion

        #region Pegar Coordenadas


        public void pegarCoordenadas(MouseEventArgs e)
        {
            if (pontos == 0)
            {
                x[0] = e.X;
                y[0] = e.Y;
            }
            else if (pontos == 1)
            {
                x[1] = e.X;
                y[1] = e.Y;
            }
            else if (pontos == 2)
            {
                x[2] = e.X;
                y[2] = e.Y;
            }
            else if (pontos == 3)
            {
                x[3] = e.X;
                y[3] = e.Y;
            }
            else
            {
                x[4] = e.X;
                y[4] = e.Y;
            }

            pintar = true;
            Invalidate();
        }

        #endregion


        public Form1()
        {
            InitializeComponent();
            float[] solid = { 1 };
            caneta1 = CriaCaneta(0, 0, 0, 2, solid);
            caneta2 = CriaCaneta(255, 255, 255, 2, solid);
        }




        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseButtonClick = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                mouseButtonClick = false;
            }
            switch (tipoDesenho)
            {
                case "linha":
                    pegarCoordenadas(e);
                    break;

                case "retangulo":
                    pegarCoordenadas(e);
                    break;

                case "losango":
                    pegarCoordenadas(e);
                    break;
                case "triangulo":
                    pegarCoordenadas(e);
                    break;
                case "pentagono":
                    pegarCoordenadas(e);
                    break;
                case "elipse":
                    pegarCoordenadas(e);
                    break;

            }



            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tipoDesenho = "linha";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tipoDesenho = "elipse";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tipoDesenho = "retangulo";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tipoDesenho = "losango";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tipoDesenho = "triangulo";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tipoDesenho = "pentagono";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible;
            if (comboBox1.Visible)
            {
                comboBox1.DroppedDown = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = !comboBox2.Visible;
            if (comboBox2.Visible)
            {
                comboBox2.DroppedDown = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            caneta1.Width = int.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));
            caneta2.Width = int.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoLinha = comboBox2.GetItemText(comboBox2.SelectedItem);

            switch (tipoLinha)
            {
                case "SOLID":
                    float[] solid = { 1 };
                    caneta1.DashPattern = solid;
                    caneta2.DashPattern = solid;
                    break;
                case "DASH":
                    float[] dash = { 5, 2 };
                    caneta1.DashPattern = dash;
                    caneta2.DashPattern = dash;
                    break;
                case "DOT":
                    float[] dot = { 1, 1 };
                    caneta1.DashPattern = dot;
                    caneta2.DashPattern = dot;
                    break;
                case "DASHDOT":
                    float[] dashdot = { 5, 2, 1, 2 };
                    caneta1.DashPattern = dashdot;
                    caneta2.DashPattern = dashdot;
                    break;
                case "DASHDOTDOT":
                    float[] dashdotdot = { 5, 2, 1, 2, 1, 2 };
                    caneta1.DashPattern = dashdotdot;
                    caneta2.DashPattern = dashdotdot;
                    break;

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cor1Ou2 = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Cor1Ou2 = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button11.BackColor;
                caneta1.Color = button11.BackColor;
            }
            else
            {
                button10.BackColor = button11.BackColor;
                caneta2.Color = button11.BackColor;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button12.BackColor;
                caneta1.Color = button12.BackColor;
            }
            else
            {
                button10.BackColor = button12.BackColor;
                caneta2.Color = button12.BackColor;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button13.BackColor;
                caneta1.Color = button13.BackColor;
            }
            else
            {
                button10.BackColor = button13.BackColor;
                caneta2.Color = button13.BackColor;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button14.BackColor;
                caneta1.Color = button14.BackColor;
            }
            else
            {
                button10.BackColor = button14.BackColor;
                caneta2.Color = button14.BackColor;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button15.BackColor;
                caneta1.Color = button15.BackColor;
            }
            else
            {
                button10.BackColor = button15.BackColor;
                caneta2.Color = button15.BackColor;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button16.BackColor;
                caneta1.Color = button16.BackColor;
            }
            else
            {
                button10.BackColor = button16.BackColor;
                caneta2.Color = button16.BackColor;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button17.BackColor;
                caneta1.Color = button17.BackColor;
            }
            else
            {
                button10.BackColor = button17.BackColor;
                caneta2.Color = button17.BackColor;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button18.BackColor;
                caneta1.Color = button18.BackColor;
            }
            else
            {
                button10.BackColor = button18.BackColor;
                caneta2.Color = button18.BackColor;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button19.BackColor;
                caneta1.Color = button19.BackColor;
            }
            else
            {
                button10.BackColor = button19.BackColor;
                caneta2.Color = button19.BackColor;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button20.BackColor;
                caneta1.Color = button20.BackColor;
            }
            else
            {
                button10.BackColor = button20.BackColor;
                caneta2.Color = button20.BackColor;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button21.BackColor;
                caneta1.Color = button21.BackColor;
            }
            else
            {
                button10.BackColor = button21.BackColor;
                caneta2.Color = button21.BackColor;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button22.BackColor;
                caneta1.Color = button22.BackColor;
            }
            else
            {
                button10.BackColor = button22.BackColor;
                caneta2.Color = button22.BackColor;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button23.BackColor;
                caneta1.Color = button23.BackColor;
            }
            else
            {
                button10.BackColor = button23.BackColor;
                caneta2.Color = button23.BackColor;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button24.BackColor;
                caneta1.Color = button24.BackColor;
            }
            else
            {
                button10.BackColor = button24.BackColor;
                caneta2.Color = button24.BackColor;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button25.BackColor;
                caneta1.Color = button25.BackColor;
            }
            else
            {
                button10.BackColor = button25.BackColor;
                caneta2.Color = button25.BackColor;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button26.BackColor;
                caneta1.Color = button26.BackColor;
            }
            else
            {
                button10.BackColor = button26.BackColor;
                caneta2.Color = button26.BackColor;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button27.BackColor;
                caneta1.Color = button27.BackColor;
            }
            else
            {
                button10.BackColor = button27.BackColor;
                caneta2.Color = button27.BackColor;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button28.BackColor;
                caneta1.Color = button28.BackColor;
            }
            else
            {
                button10.BackColor = button28.BackColor;
                caneta2.Color = button28.BackColor;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button29.BackColor;
                caneta1.Color = button29.BackColor;
            }
            else
            {
                button10.BackColor = button29.BackColor;
                caneta2.Color = button29.BackColor;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (Cor1Ou2)
            {
                button9.BackColor = button30.BackColor;
                caneta1.Color = button30.BackColor;
            }
            else
            {
                button10.BackColor = button30.BackColor;
                caneta2.Color = button30.BackColor;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string path = @"C:\Arquivos\dados.dat";
            File.WriteAllText(path, tipoDesenho + Environment.NewLine);
            File.AppendAllText(path, pontosSalvos.ToString() + Environment.NewLine);
            for (int i = 0; i < pontosSalvos; i++)
            {
                File.AppendAllText(path, x[i].ToString() + Environment.NewLine);
                File.AppendAllText(path, y[i].ToString() + Environment.NewLine);
            }
            if (Cor1Ou2)
            {
                File.AppendAllText(path, button9.BackColor.R.ToString() + Environment.NewLine);
                File.AppendAllText(path, button9.BackColor.G.ToString() + Environment.NewLine);
                File.AppendAllText(path, button9.BackColor.B.ToString() + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(path, button10.BackColor.R.ToString() + Environment.NewLine);
                File.AppendAllText(path, button10.BackColor.G.ToString() + Environment.NewLine);
                File.AppendAllText(path, button10.BackColor.B.ToString() + Environment.NewLine);
            }
            if (mouseButtonClick)
            {
                File.AppendAllText(path, caneta1.Width.ToString() + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(path, caneta2.Width.ToString() + Environment.NewLine);
            }
            if (mouseButtonClick)
            {
                File.AppendAllText(path, caneta1.DashPattern.Length.ToString() + Environment.NewLine);
                for (int i = 0; i < caneta1.DashPattern.Length; i++)
                {
                    File.AppendAllText(path, caneta1.DashPattern[i].ToString() + Environment.NewLine);
                }
                File.AppendAllText(path, "caneta1" + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(path, caneta2.DashPattern.Length.ToString() + Environment.NewLine);
                for (int i = 0; i < caneta2.DashPattern.Length; i++)
                {
                    File.AppendAllText(path, caneta2.DashPattern[i].ToString() + Environment.NewLine);
                }
                File.AppendAllText(path, "caneta2" + Environment.NewLine);
            }
            pontosSalvos = 0;

            MessageBox.Show("Arquivo .dat salvo com sucesso!");

        }

        private void button32_Click(object sender, EventArgs e)
        {
            String[] lines = System.IO.File.ReadAllLines(@"C:\Arquivos\dados.dat");
            tipoDesenho = lines[0];
            pontosSalvos = int.Parse(lines[1]);
            pontos = pontosSalvos - 1;
            int j = 0;
            for (int i = 2;i < pontosSalvos*2; i = i + 2)
            {
                x[j] = int.Parse(lines[i]);
                y[j] = int.Parse(lines[i + 1]);
                j++;
            }
            int[] rgb = new int[3];
            for (int i = 0; i < 3; i++)
            {
                rgb[i] = int.Parse(lines[1 + (pontosSalvos * 2) + 1 + i]);
            }
            float[] dashPattern = new float[int.Parse(lines[1 + (pontosSalvos * 2) + 5])];
            for (int i = 0; i < int.Parse(lines[1 + (pontosSalvos * 2) + 5]); i++)
            {
                dashPattern[i] = int.Parse(lines[1 + (pontosSalvos * 2) + 6 + i]);
            }

            if (lines[lines.Length -1] == "caneta1")
            {
                caneta1 = CriaCaneta(rgb[0], rgb[1], rgb[2], int.Parse(lines[1 + (pontosSalvos * 2) + 4]), dashPattern);
                mouseButtonClick = true;
                Cor1Ou2 = true;
            }
            else
            {
                caneta2 = CriaCaneta(rgb[0], rgb[1], rgb[2], int.Parse(lines[1 + (pontosSalvos * 2) + 4]), dashPattern);
                mouseButtonClick = false;
                Cor1Ou2 = false;
            }
            pintar = true;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen Caneta;
            if (mouseButtonClick)
            {
                Caneta = caneta1;
            }
            else
            {
                Caneta = caneta2;
            }
            if (pintar)
            {
                Ponto(e, x[0], y[0], Caneta);
                pontos += 1;

                if (pontos >= 2)
                {
                    switch (tipoDesenho)
                    {
                        case "linha":
                            Linha(e, x[0], y[0], x[1], y[1], Caneta);
                            pontosSalvos = pontos;
                            pontos = 0;
                            break;

                        case "retangulo":
                            Retangulo(e, x[0], y[0], x[1], y[1]);
                            pontosSalvos = pontos;
                            pontos = 0;
                            break;

                        case "losango":
                            if (pontos == 4)
                            {
                                Losango(e, x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                                pontosSalvos = pontos;
                                pontos = 0;
                            }
                            break;
                        case "triangulo":
                            if (pontos == 3)
                            {
                                Triangulo(e, x[0], y[0], x[1], y[1], x[2], y[2]);
                                pontosSalvos = pontos;
                                pontos = 0;
                            }
                            break;
                        case "pentagono":
                            if (pontos == 5)
                            {
                                Pentagono(e, x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3], x[4], y[4]);
                                pontosSalvos = pontos;
                                pontos = 0;
                            }
                            break;


                    }
                }
                else if (pontos == 1 && tipoDesenho == "elipse")
                {
                    DialogResult dialogResult = MessageBox.Show("Desenha desenhar uma Elipse?", "Elipse ou Circulo?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int Largura = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Selecione a largura", "Largura  Elipse", "", 150, 150));
                        int Altura = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Selecione a altura", "Altura Elipse", "", 150, 150));
                        Elipse(e, x[0], y[0], Largura, Altura);
                        pontosSalvos = pontos;
                        pontos = 0;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        int raio = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Selecione o raio", "Raio Circulo", "", 150, 150));
                        Circulo(e, x[0], y[0], raio, 0, 360);
                        pontosSalvos = pontos;
                        pontos = 0;
                    }


                }
            }
            pintar = false;
        }
    }
}