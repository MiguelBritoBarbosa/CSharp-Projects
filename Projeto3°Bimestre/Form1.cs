/*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 *Curso Técnico em Informática - Data de Entrega: 06 / 09 / 2022
 * Autores do Projeto: Miguel Brito Barbosa - Lucas de Oliveira Maia
 *
 * Turma: 2M
 * Atividade Proposta em aula
 * Observação: 
    dateTimePicker1: controle de data onde o usuário irá inserir o dia da compra feita.
    textBox1: caixa de texto onde o usuário irá inserir o valor da compra.
    textBox2: caixa de texto que receberá a quantidade de parcelas da compra.
    button1: botão que gera as parcelas e seus valores e o enviam para uma listbox.
    listBox1: caixa de lista que receberá as parcelas geradas pelo botão.
    label4: texto que receberá o valor total da compra.
    dateTimePicker2: controle de data onde o usuário irá inserir o dia do pagamento.
    button2: botão que pagará uma parcela selecionada na listbox1 pelo usuário.
 * 
 * 
 * ******************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto3_Bimestre
{
   public partial class Form1 : Form
    {

        float ValorMensal;
        float Valor;
        int Parcelas;
        DateTime[] Datas = new DateTime[0];


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Datas.Length == 0)
            {
                DateTime DataCompra = dateTimePicker1.Value.Date;
                if (float.TryParse(textBox1.Text, out Valor) && int.TryParse(textBox2.Text, out Parcelas))
                {
                    Valor = float.Parse(textBox1.Text);
                    Parcelas = int.Parse(textBox2.Text);
                    ValorMensal = Valor / Parcelas;

                    label4.Text = string.Format($"Total a pagar: {Valor:C2}");
                    Array.Resize(ref Datas, Datas.Length + Parcelas);

                    for (int i = 0; i < Parcelas; i++)
                    {

                        DateTime DataParcela = DataCompra.AddMonths(i);

                        int diaSemana = (int)DataParcela.DayOfWeek;

                        if (diaSemana == 0)
                        {
                            DataParcela = DataParcela.AddDays(1);
                        }
                        else if (diaSemana == 6)
                        {
                            DataParcela = DataParcela.AddDays(2);
                        }


                        listBox1.Items.Add(String.Format($"{i + 1}° Parcela: {ValorMensal:C2} - " + DataParcela.ToString("dd/MM/yyyy")));
                        Datas[i] = DataParcela;
                    }
                    label4.Visible = true;
                    button2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Digite os valores corretamente!");
                }
            }
            else
            {
                MessageBox.Show("Pagamento de compra peendente. Termine o pagamento para realizar outra compra");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Datas.Length == 1)
            {
                button2.Enabled = false;
            }
            DateTime DataPagamento = dateTimePicker2.Value.Date;

            int indice = listBox1.SelectedIndex;

            if ( indice != -1 && DateTime.Compare(Datas[indice], DataPagamento) < 0)
            {
                MessageBox.Show(String.Format($"Pagamento atrasado. Valor da parcela reajustado: {ValorMensal*1.03:C2}"));
            }

            //MessageBox.Show(Datas[indice].ToString() + " - " + DataPagamento.ToString());

            int Id = listBox1.SelectedIndex;
            if (Id == -1)
            {
                MessageBox.Show("Selecione uma parcela!");
            }
            else if (Id != 0)
            {
                MessageBox.Show("Não foi possivel pagar está parcela pois há uma parcela anterior peendente");
            }
            else
            {
                listBox1.Items.RemoveAt(Id);
                Valor -= ValorMensal;
                label4.Text = string.Format($"Total a pagar: {Valor:C2}");
                if (Datas.Length >= 1)
                {
                    for (int i = 0; i < Datas.Length - 1; i++)
                    {
                        Datas[i] = Datas[i + 1];
                    }
                    Array.Resize(ref Datas, Datas.Length - 1);
                }
            }
        }
    }
}
