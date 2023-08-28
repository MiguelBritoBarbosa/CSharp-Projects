using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Projeto3Bim
{
    public partial class Form1 : Form
    {
        Bitmap imgFogao = new Bitmap("C:/Imagens/Imagem_A.jpg");
        Bitmap imgPanela = new Bitmap("C:/Imagens/Panela.jpg");
        Bitmap imgnova;


        public Form1()
        {
            InitializeComponent();
        }

        public Color CriarCor(byte r, byte g, byte b)
        {
            return Color.FromArgb(255, r, g, b);
        }


        public void BinareImage()
        {
            imgnova = new Bitmap("C:/Imagens/escalaDeCinza.jpg");
            int coluna = imgnova.Width;
            int linha = imgnova.Height;
            Color cor;
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    byte r = imgnova.GetPixel(i, j).R;
                    if (r <= 126)
                    {
                        cor = CriarCor(0, 0, 0);
                        imgnova.SetPixel(i, j, cor);
                    }
                    else
                    {
                        cor = CriarCor(255, 255, 255);
                        imgnova.SetPixel(i, j, cor);
                    }
                }
            }
            imgnova.Save("C:/Imagens/binaria.jpg");
            pictureBox3.Load("C:/Imagens/binaria.jpg");
        }

        public void GrayScale()
        {
            int coluna = imgnova.Width;
            int linha = imgnova.Height;
            Color cor;
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    byte r = imgnova.GetPixel(i, j).R;
                    byte g = imgnova.GetPixel(i, j).G;
                    byte b = imgnova.GetPixel(i, j).B;
                    byte gray = (byte)((r * 0.30) + (g * 0.59) + (b * 0.11));
                    cor = CriarCor(gray, gray, gray);
                    imgnova.SetPixel(i, j, cor);
                }
            }
            imgnova.Save("C:/Imagens/escalaDeCinza.jpg");
            pictureBox2.Load("C:/Imagens/escalaDeCinza.jpg");
        }

        public void ProcessarImagens()
        {
            imgnova = imgFogao;
            int coluna = imgPanela.Width;
            int linha = imgPanela.Height;
            Color cor;


            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    byte r = imgPanela.GetPixel(i, j).R;
                    byte g = imgPanela.GetPixel(i, j).G;
                    byte b = imgPanela.GetPixel(i, j).B;
                    if (!(r > 100 & g > 100 && b < 110))
                    {
                        cor = imgPanela.GetPixel(i, j);
                        imgnova.SetPixel(i + 135, j, cor);
                    }

                }
            }


            imgnova.Save("C:/Imagens/fogaoComPanela.jpg");
            pictureBox1.Load("C:/Imagens/fogaoComPanela.jpg");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ProcessarImagens();
            GrayScale();
            BinareImage();
        }
    }
}