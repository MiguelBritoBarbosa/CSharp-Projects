using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto3Bim
{
    public partial class Form1 : Form
    {
        Bitmap imgFogao = new Bitmap("C:/Imagens/Imagem_A.jpg");
        Bitmap imgPanela = new Bitmap("C:/Imagens/Panela.jpg");
        Bitmap imgnova = new Bitmap("C:/Imagens/Imagem_A.jpg"   );


        public Form1()
        {
            InitializeComponent();
        }

        public Color CriarCor(byte r, byte g, byte b)
        {
            return Color.FromArgb(255, r, g, b);
        }


        public Color getPanela(byte x, byte y, byte r, byte g, byte b )
        {
            Bitmap imgPanela = new Bitmap("C:/Imagens/Panela.jpg");
            byte rP = imgPanela.GetPixel(x, y).R;
            byte gP = imgPanela.GetPixel(x, y).G;
            byte bP = imgPanela.GetPixel(x, y).B;
            if (!(r == 255 & g == 255 && b == 0))
            {
                return imgPanela.GetPixel(x, y);
            }
            else
            {
                return Color.FromArgb(255, r, g, b);
            }
        }



        public void ProcessarImagens()
        {
            int coluna = imgPanela.Width;
            int linha = imgPanela.Height;
            Color cor;


            for (byte i = 0; i <= coluna - 1; i++)
            {
                for (byte j = 0; j <= linha - 1; j++)
                {
                    byte r = imgPanela.GetPixel(i, j).R;
                    byte g = imgPanela.GetPixel(i, j).G;
                    byte b = imgPanela.GetPixel(i, j).B;
                    if (!(r == 255 & g == 255 && b == 0))
                    {
                        cor = imgPanela.GetPixel(i, j);
                        imgnova.SetPixel(i, j, cor);
                    }
                    
                }
            }


            imgnova.Save("C:/Imagens/novaImagem.jpg");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ProcessarImagens();
        }
    }
}
