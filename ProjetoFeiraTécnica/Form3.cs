using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFeiraTécnica
{
    public partial class Form3 : Form
    {
        Form2 form2;



        public Form3(Form2 formulario2)
        {
            InitializeComponent();

            form2 = formulario2;
            string mapa = form2.Mapa[form2.x];
            pictureBox1.Load(mapa);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();
            

        }

      

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                Close();
                this.form2.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (metroProgressBar1.Value < 100)
            {
                metroProgressBar1.Increment(1);
            }
            if(metroProgressBar1.Value == 100)
            {
                timer1.Stop();
                metroProgressBar1.Visible = false;
                panel2.Visible = true;
                pictureBox1.Load(form2.referencia[form2.x]);
            }

            
        }
    }
}
