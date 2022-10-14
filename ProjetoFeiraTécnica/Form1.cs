using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFeiraTécnica
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            // Inicia a segunda tela da aplicação.
            Form2 Tela2 = new Form2();
            Tela2.ShowDialog();
        }
    }

}
