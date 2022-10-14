using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace ProjetoFeiraTécnica
{
    public partial class Form2 : Form
    {
        MySqlConnection conexao = new MySqlConnection("Server=localhost;port=3306;User Id=root; database=MapaFeira_db; password=");
        
        public string[] Mapa = new string[4];
        public string[] referencia = new string[4];
        public int x;
        MySqlDataReader dr = null;


        
        public void Consulta(string output)
        {
            MySqlCommand query = conexao.CreateCommand();





            try
            {
                conexao.Open();
                string sql = $"select * from salas where ano = '{output}';";
                query = new MySqlCommand(sql, conexao);
                dr = query.ExecuteReader();



                int n = 0;
                while (dr.Read())
                {
                    listBox1.Items.Add("Sala: " + dr.GetString(1));   
                    this.Mapa[n] = dr.GetString(4);
                    this.referencia[n] = dr.GetString(5);
                    n++;
                }
                if (n == 1 || n == 0)
                {
                   
                    //string video = dr.GetString(6);

                    Form3 Imagem = new Form3(this);
                    Imagem.ShowDialog();
                }
                else
                {
                    label3.Visible = false;
                    button2.Visible = true;
                    listBox1.Visible = true;
                }
                    






            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro);

            }
         

            
        }


        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {


            button1.Visible = false;
            Process processo = new Process();
            processo.StartInfo.FileName = @"C:\Users\Migue\AppData\Local\Programs\Python\Python310\python.exe"; //<-Python path
            processo.StartInfo.Arguments = "./projeto.py";
            processo.StartInfo.UseShellExecute = false;
            processo.StartInfo.CreateNoWindow = true;
            processo.StartInfo.RedirectStandardError = true;
            processo.StartInfo.RedirectStandardOutput = true;
            processo.Start();

            StreamReader reader = processo.StandardOutput;
            string output = reader.ReadToEnd();
            

            output = output.Trim();

            Consulta(output);


            processo.WaitForExit();
            processo.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand query = conexao.CreateCommand();
            this.x = listBox1.SelectedIndex;
            if (this.x == -1)
            {
                MessageBox.Show("SELECIONE UMA SALA ANTES DE PROCURAR!!!");
            }
            else
            {
                Form3 Imagem = new Form3(this);
                Imagem.ShowDialog();
            }
            
        }
    }
}
