using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    
    public partial class CadastroFuncionario : Form
    {
        ListaFuncionario listaFuncionarios = new ListaFuncionario();
        
        public CadastroFuncionario()
        {
            InitializeComponent();            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void MinhaJanela_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            LimparCampos();
        } 
                    
        private void LimparCampos()
        {
            tbNome.Text = "";
            tbSalario.Text = "0";
            tbDesconto.Text = "0";
            tbAdicional.Text = "0";
            tbLiquido.Text = "0";
            tbCPF.Text = "";
        }

        private bool ValidarCampos()
        {
            if (tbNome.Text == "")
            {
                MessageBox.Show("Nome Inválido","Atenção");
                return false;
            }

            if (tbSalario.Text == "" || tbSalario.Text == "0")
            {
                MessageBox.Show("Salário Inválido","Atenção");
                return false;
            }

            return true;
        }
        
        private void FormatarCampos()
        {
            float valor;
                
            valor = float.Parse(tbSalario.Text);
            tbSalario.Text = valor.ToString("N2");

            valor = float.Parse(tbDesconto.Text);
            tbDesconto.Text = valor.ToString("N2");

            valor = float.Parse(tbAdicional.Text);
            tbAdicional.Text = valor.ToString("N2");

            valor = float.Parse(tbLiquido.Text);
            tbLiquido.Text = valor.ToString("N2");
        }

        private void CalcularLiquido()
        {
            if (cbDesconto.Checked)
                tbLiquido.Text = Convert.ToString(float.Parse(tbSalario.Text) + float.Parse(tbAdicional.Text));
            else
                tbLiquido.Text = Convert.ToString(float.Parse(tbSalario.Text) - float.Parse(tbDesconto.Text) + float.Parse(tbAdicional.Text));

        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                
                listaFuncionarios.ArmazenarFuncionario(tbNome.Text,
                                                        float.Parse(tbSalario.Text),
                                                        float.Parse(tbDesconto.Text),
                                                        float.Parse(tbAdicional.Text),
                                                        tbCPF.Text,
                                                        cbDesconto.Checked);

                ListViewItem item = new ListViewItem(new[] { tbNome.Text,
                                                            float.Parse(tbSalario.Text).ToString("N2"),
                                                            float.Parse(tbDesconto.Text).ToString("N2"),
                                                            float.Parse(tbAdicional.Text).ToString("N2"),
                                                            float.Parse(tbLiquido.Text).ToString("N2") });
                
                lvListaFuncionarios.Items.Add(item);

                MessageBox.Show($"Calculou Salário Líquido para o funcionário {tbNome.Text}", "Atenção");
                LimparCampos();
            }
        }
               
        private void LvListaFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TbAdicional_Leave(object sender, EventArgs e)
        {
            CalcularLiquido();
            FormatarCampos();
        }

        private void TbSalario_Leave(object sender, EventArgs e)
        {
            CalcularLiquido();
            FormatarCampos();
        }

        private void TbDesconto_Leave(object sender, EventArgs e)
        {
            CalcularLiquido();
            FormatarCampos();
        }

        private void CbDesconto_CheckStateChanged(object sender, EventArgs e)
        {
            CalcularLiquido();
            FormatarCampos();
        }
                       
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            for (int itemList = lvListaFuncionarios.SelectedItems.Count - 1; itemList >=0; itemList--)
            {
                ListViewItem lista = lvListaFuncionarios.SelectedItems[itemList];
                lvListaFuncionarios.Items.Remove(lista);
            }
        }
                
    }

    
}
