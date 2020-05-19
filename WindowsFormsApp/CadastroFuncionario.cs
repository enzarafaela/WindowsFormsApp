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
                
                // metodo ArmazenarFuncionario
                // responsavel por inserir um novo objeto Funcionario
                // em uma posição da list
                listaFuncionarios.ArmazenarFuncionario(tbNome.Text,
                                                        float.Parse(tbSalario.Text),
                                                        float.Parse(tbDesconto.Text),
                                                        float.Parse(tbAdicional.Text),
                                                        tbCPF.Text,
                                                        cbDesconto.Checked);

                // alimento uma "sublista" de item (que é uma linha da list view)
                // "pegando" os dados  dos textbox 
                ListViewItem item = new ListViewItem(new[] { tbNome.Text,
                                                             tbCPF.Text,
                                                            float.Parse(tbSalario.Text).ToString("N2"),
                                                            float.Parse(tbDesconto.Text).ToString("N2"),
                                                            float.Parse(tbAdicional.Text).ToString("N2"),
                                                            float.Parse(tbLiquido.Text).ToString("N2") });
                // adicionando o objeto item na listview
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
         
        // Evento Click do btnExcluir 
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            // Este for, percorre a lista de itens selecionados na listview
            for (int itemList = lvListaFuncionarios.SelectedItems.Count - 1; itemList >=0; itemList--)
            {
                // cria um objeto tipo list view item
                // joga pra esse objeto, a lista de funcionarios selecionados
                ListViewItem lista = lvListaFuncionarios.SelectedItems[itemList];
                // metodo remove = remove uma lista (item) da list view
                lvListaFuncionarios.Items.Remove(lista); 

                // obtem o text da posição 0 da minha sublista da listview
                // que é a coluna "nome"
                string nome = lista.SubItems[0].Text;

                // chamada ao metodo RemoverFuncionario
                // passando o parametro nome, obtido acima.
                listaFuncionarios.RemoverFuncionario(nome);
            }
        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            // metodo que ordena a lista de objetos funcionarios
            listaFuncionarios.OrdenarFuncionario();

            //limpa a listview (grid da tela)
            lvListaFuncionarios.Items.Clear();

            // obtem o tamanho da list
            // lembrando que aqui neste escopo, o listaFuncionario não é manipulado como list
            // apenas dentro da classe
            int tamanhoLista = listaFuncionarios.RetornarTamanhoLista();

            // objeto funcionarioObj "em branco"
            Funcionario funcionarioObj = new Funcionario();
            
            //percorre a list do inicio ao fim
            for (int indice = 0; indice < tamanhoLista; indice++)
            {
                // cada indice, funcionarioObj irá receber o objeto Funcionario da posição
                funcionarioObj = listaFuncionarios.RetornaObjetoFuncionario(indice);

                // alimento uma "sublista" de item (que é uma linha da list view)
                // "pegando" os dados direto do funcionarioObj
                ListViewItem item = new ListViewItem(new[] { funcionarioObj.nome,
                                                             funcionarioObj.cpf,
                                                             funcionarioObj.salarioBruto.ToString("N2"),
                                                             funcionarioObj.desconto.ToString("N2"),
                                                             funcionarioObj.adicional.ToString("N2"),
                                                             funcionarioObj.salarioLiquido.ToString("N2") });
                // adicionando o objeto item na listview
                lvListaFuncionarios.Items.Add(item);
            }
        }
    }

    
}
