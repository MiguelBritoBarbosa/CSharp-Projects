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

namespace ProjetoPVB_4_Bimestre
{
    public partial class Form1 : Form
    {
        
        public int indice = 0;

        string FormatarNomes(string nome)
        {
            nome = nome.ToLower();
            string[] strs = {"dos ", "das ", "de ", "da ", "do "};
            for (int i = 0; i < nome.Length; i++)
            {
                if (i == 0)
                {
                    nome = char.ToUpper(nome[0]) + nome.Substring(1);
                }
                else
                {
                    if (nome[i-1] == ' ' && (Array.IndexOf(strs, nome.Substring(i, 4)) == -1 && Array.IndexOf(strs, nome.Substring(i, 3)) == -1))
                    {
                        nome = nome.Substring(0, i-1) + " " + char.ToUpper(nome[i]) + "" + nome.Substring(i + 1);
                    }
                }       
            }   
            return nome;
        }

        void LimparTextos()
        {
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            maskedTextBox2.Clear();
            pictureBox1.Image = null;
            pictureBox1.ImageLocation = null;
        }

        MySqlConnection Conectar()
        {
            try
            {
                string database = "SERVER=localhost;DATABASE=projeto;UID=root;PASSWORD=;";
                MySqlConnection conexão = new MySqlConnection(database);
                conexão.Open();
                return conexão;
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro: " + err.ToString());
                MySqlConnection conexão = null;
                return conexão;
            }

        }

        void ConsultarTodos()
        {
            try
            {
                MySqlConnection conexão = Conectar();
                MySqlCommand query = conexão.CreateCommand();
                query.CommandText = $"select count(*) as qtd from Tabela1";
                MySqlDataReader resultado = query.ExecuteReader();
                resultado.Read();

                int qtd = int.Parse(resultado.GetString("qtd"));
                if (indice == -1)
                {
                    indice = qtd;
                }

                conexão.Close();

                conexão = Conectar();
                query = conexão.CreateCommand();
                query.CommandText = $"select *,row_number() over() as rw from Tabela1";
                resultado = query.ExecuteReader();
                while (resultado.Read())

                {
                    if (indice > qtd)
                    {
                        MessageBox.Show("Fim dos registros");
                        indice--;
                    }
                    else if (indice < 1)
                    {
                        MessageBox.Show("Fim dos registros");
                        indice++;
                    }
                    else
                    {
                        if (indice == int.Parse(resultado.GetString("rw")))
                        {
                            textBox1.Text = resultado.GetString("codigo");
                            maskedTextBox1.Text = resultado.GetString("Cpf");
                            textBox3.Text = resultado.GetString("Nome");
                            textBox4.Text = resultado.GetString("Cidade");
                            textBox5.Text = resultado.GetString("Bairro");
                            maskedTextBox2.Text = resultado.GetString("Telefone");
                            pictureBox1.Load(resultado.GetString("Foto"));
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Erro: {err}");
            }
        }

        bool VerificarRegistro(string codigo)
        {
            try
            {
                MySqlConnection conexão = Conectar();
                MySqlCommand query = conexão.CreateCommand();
                query.CommandText = $"select * from Tabela1 where codigo = '{codigo}'";
                MySqlDataReader resultado = query.ExecuteReader();

                if (resultado.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Erro: {err}");
                return false;
            }
        }

        void Cadastrar(string codigo, string cpf, string nome, string cidade, string bairro, string telefone, string foto)
        {
            try
            {
                MySqlConnection conexão = Conectar();
                MySqlCommand query = conexão.CreateCommand();
                query.CommandText = $"insert into Tabela1 values('{codigo}', '{cpf}', '{nome}', '{cidade}', '{bairro}', '{telefone}', '{foto}')";

                MySqlDataReader resultado = query.ExecuteReader();
                MessageBox.Show($"O individuo {nome} foi cadastrado com sucesso!");
                conexão.Close();
                LimparTextos();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Erro: " + err.ToString());
            }
        }

        void Alterar(string codigo, string cpf, string nome, string cidade, string bairro, string telefone, string foto)
        {
            try
            {
                MySqlConnection conexão = Conectar();
                MySqlCommand query = conexão.CreateCommand();
                query.CommandText = $"update Tabela1 set Cpf = '{cpf}', Nome = '{nome}', Cidade = '{cidade}', Bairro = '{bairro}', Telefone = '{telefone}', Foto = '{foto}' where Codigo = '{codigo}'";

                MySqlDataReader resultado = query.ExecuteReader();
                MessageBox.Show($"O individuo {nome} foi alterado com sucesso!");
                textBox1.Text = codigo;
                maskedTextBox1.Text = cpf;
                textBox3.Text = nome;
                textBox4.Text = cidade;
                textBox5.Text = bairro;
                maskedTextBox2.Text = telefone;
                pictureBox1.Load(foto);
                conexão.Close();
                LimparTextos();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Erro: " + err.ToString());
            }
        }

        void Consultar(string codigo)
        {
            try
            {
                MySqlConnection conexão = Conectar();
                MySqlCommand query = conexão.CreateCommand();
                query.CommandText = $"select * from Tabela1 where codigo = '{codigo}'";
                MySqlDataReader resultado = query.ExecuteReader();

                if (resultado.Read())
                {
                    textBox1.Text = resultado.GetString("codigo");
                    maskedTextBox1.Text = resultado.GetString("Cpf");
                    textBox3.Text = resultado.GetString("Nome");
                    textBox4.Text = resultado.GetString("Cidade");
                    textBox5.Text = resultado.GetString("Bairro");
                    maskedTextBox2.Text = resultado.GetString("Telefone");
                    pictureBox1.Load(resultado.GetString("Foto"));
                }
                else
                {
                    MessageBox.Show($"Não há resgistros com o codigo '{codigo}'");
                }
                conexão.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro: " + err);
            }
        }

        void Deletar(string codigo)
        {
            try
            {
                MySqlConnection conexão = Conectar();
                MySqlCommand query = conexão.CreateCommand();
                query.CommandText = $"select * from Tabela1 where codigo = '{codigo}'";
                MySqlDataReader resultado = query.ExecuteReader();

                if (resultado.Read())
                {
                    string nome = resultado.GetString("Nome");
                    conexão.Close();
                    conexão = Conectar();
                    query = conexão.CreateCommand();
                    query.CommandText = $"delete from Tabela1 where codigo = '{codigo}'";
                    resultado = query.ExecuteReader();
                    MessageBox.Show($"O individuo {nome} foi deletado com sucesso!");
                    conexão.Close();
                    LimparTextos();
                }
                else
                {
                    MessageBox.Show($"Não há resgistros com o codigo '{codigo}'");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro: " + err);
            }
            
        }

        bool ValidaCPF(string cpf)

        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)

                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagem = new OpenFileDialog();
            imagem.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            imagem.Title = "Selecione sua imagem";
            if (imagem.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = imagem.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string codigo = textBox1.Text;
            bool teste = VerificarRegistro(codigo);

            string cpf = maskedTextBox1.Text;
            string nome = textBox3.Text;
            string cidade = textBox4.Text;
            string bairro = textBox5.Text;
            string telefone = maskedTextBox2.Text;

            if (codigo.Length != 0 && ValidaCPF(cpf) && nome.Length > 2 && cidade.Length > 2 && bairro.Length > 2 && telefone.Length == 15 && pictureBox1.ImageLocation != null)
            {
                string foto = pictureBox1.ImageLocation.ToString();
                foto = foto.Replace("\\", "/");
                nome = FormatarNomes(nome);
                cidade = FormatarNomes(cidade);
                bairro = FormatarNomes(bairro);
                if (!teste)
                {
                    Cadastrar(codigo, cpf, nome, cidade, bairro, telefone, foto);
                }
                else
                {
                    string texto = "Esse código já tem um registro, deseja altera-lo?";
                    
                    MessageBoxButtons botões = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    DialogResult resposta = new DialogResult();
                    resposta = MessageBox.Show(texto, "atenção", botões, icon);
                    if (resposta == DialogResult.Yes)
                    {
                        Alterar(codigo, cpf, nome, cidade, bairro, telefone, foto);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Digite os dados corretamente!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text;
            if (codigo.Length != 0)
            {
                Consultar(codigo);
            }
            else
            {
                MessageBox.Show("Digite o código corretamente!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text;
            if (codigo.Length != 0)
            {
                Deletar(codigo);
            }
            else
            {
                MessageBox.Show("Digite o código corretamente!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            indice = 1;
            ConsultarTodos();
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            if(indice == 0)
            {
                indice++;
            }
            else
            {
                indice--;
            }
            ConsultarTodos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            indice++;
            ConsultarTodos();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            indice = -1;
            ConsultarTodos();
        }
    }
}
