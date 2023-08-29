using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Projeto3Bim
{
   
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public Color CriarCor(byte r, byte g, byte b)
        {
            return Color.FromArgb(255, r, g, b);
        }

        public Bitmap CriaImagem(string caminho)
        {
            return new Bitmap(caminho);
        }

        public void BinareImage(string caminho, string imagemSalvar)
        {
            Bitmap imgNova = CriaImagem(caminho);
            int coluna = imgNova.Width;
            int linha = imgNova.Height;

            Color cor;
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    byte r = imgNova.GetPixel(i, j).R;
                    if (r <= 126)
                    {
                        cor = CriarCor(0, 0, 0);
                        imgNova.SetPixel(i, j, cor);
                    }
                    else
                    {
                        cor = CriarCor(255, 255, 255);
                        imgNova.SetPixel(i, j, cor);
                    }
                }
            }
            imgNova.Save(imagemSalvar);
            pictureBox3.Load(imagemSalvar);
        }

        public void GrayScale(string caminho, string imagemSalvar)
        {
            Bitmap imgNova = CriaImagem(caminho);
            int coluna = imgNova.Width;
            int linha = imgNova.Height;
            Color cor;
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    byte r = imgNova.GetPixel(i, j).R;
                    byte g = imgNova.GetPixel(i, j).G;
                    byte b = imgNova.GetPixel(i, j).B;
                    byte gray = (byte)((r * 0.30) + (g * 0.59) + (b * 0.11));
                    cor = CriarCor(gray, gray, gray);
                    imgNova.SetPixel(i, j, cor);
                }
            }
            imgNova.Save(imagemSalvar);
            pictureBox2.Load(imagemSalvar);
        }

        public void ProcessarImagens(string caminhoImagem1, string caminhoImagem2, string imagemSalvar)
        {
            Bitmap ImgInicial = CriaImagem(caminhoImagem1);
            Bitmap ImgSecundaria = CriaImagem(caminhoImagem2);
            Bitmap imgNova = ImgInicial;
            int coluna = ImgSecundaria.Width;
            int linha = ImgSecundaria.Height;
            Color cor;


            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    byte r = ImgSecundaria.GetPixel(i, j).R;
                    byte g = ImgSecundaria.GetPixel(i, j).G;
                    byte b = ImgSecundaria.GetPixel(i, j).B;
                    if (!(r > 100 & g > 100 && b < 110))
                    {
                        cor = ImgSecundaria.GetPixel(i, j);
                        imgNova.SetPixel(i + 135, j, cor);
                    }

                }
            }

            imgNova.Save(imagemSalvar);
            pictureBox1.Load(imagemSalvar);
        }

        private void Processar_Click(object sender, EventArgs e)
        {
            ProcessarImagens("C:/Imagens/Imagem_A.jpg", "C:/Imagens/Panela.jpg", "C:/Imagens/fogaoComPanela.jpg");
            GrayScale("C:/Imagens/fogaoComPanela.jpg", "C:/Imagens/escalaDeCinza.jpg");
            BinareImage("C:/Imagens/escalaDeCinza.jpg", "C:/Imagens/binaria.jpg");
        }
    }
}