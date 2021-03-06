﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.EntitiesAgenda;

namespace WindowsFormsApp
{
    public partial class CadastroAgenda : Form
    {
        public Agenda agenda = new Agenda(); 

        public CadastroAgenda()
        {
            InitializeComponent();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            boxNome.Text = string.Empty;
            boxEndereco.Text = string.Empty;
            boxTelefone.Text = string.Empty;
            boxEmail.Text = string.Empty;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (lvAgenda.SelectedItems.Count > 0)
            {
                var pessoa = new Pessoa(boxNome.Text,
                                        boxEndereco.Text,
                                        boxTelefone.Text,
                                        boxEmail.Text);

                ListViewItem item = lvAgenda.SelectedItems[0];
                int index = lvAgenda.Items.IndexOf(lvAgenda.SelectedItems[0]);
                agenda.Editar(pessoa, index);

                string nomeOriginal = lvAgenda.SelectedItems[0].SubItems[0].Text;
                lvAgenda.SelectedItems[0].SubItems[0].Text = pessoa.Nome;
                lvAgenda.SelectedItems[0].SubItems[1].Text = pessoa.Endereco;
                lvAgenda.SelectedItems[0].SubItems[2].Text = pessoa.Telefone;
                lvAgenda.SelectedItems[0].SubItems[3].Text = pessoa.Email;

                ManipulaAgenda.Manipulacao.AtualizarRegistro(pessoa.Nome, pessoa.Endereco, pessoa.Telefone, pessoa.Email, nomeOriginal);
            }
            else
            {
                ListViewItem item = new ListViewItem(new[] { boxNome.Text,
                                                             boxEndereco.Text,
                                                             boxTelefone.Text,
                                                             boxEmail.Text });
                lvAgenda.Items.Add(item);

                agenda.Armazenar(boxNome.Text, boxEndereco.Text, boxTelefone.Text, boxEmail.Text);

                ManipulaAgenda.Manipulacao.InserirRegistro(boxNome.Text, boxEndereco.Text, boxTelefone.Text, boxEmail.Text);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvAgenda.SelectedItems[0];
            int index = lvAgenda.Items.IndexOf(item);

            string nomeOriginal = lvAgenda.SelectedItems[0].SubItems[0].Text;

            lvAgenda.SelectedItems[0].SubItems.Clear();
            agenda.Remover(index);

            lvAgenda.SelectedItems[0].Selected = false;

            ManipulaAgenda.Manipulacao.ExcluirRegistro(nomeOriginal);
        }

        private void LvAgenda_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int coluna = e.Column;

            if (coluna == 0)
            {
                agenda.Ordenar();
                lvAgenda.Items.Clear();
                int tamanhoList = agenda.RetornarTamanhoLista();

                for (int indice = 0; indice < tamanhoList; indice++)
                {
                    var pessoa = agenda.RetornarPessoa(indice);
                    ListViewItem item = new ListViewItem(new[] { pessoa.Nome,
                                                                 pessoa.Endereco,
                                                                 pessoa.Telefone,
                                                                 pessoa.Email });
                    lvAgenda.Items.Add(item);
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (lvAgenda.SelectedItems.Count> 0)
            {
                ListViewItem item = lvAgenda.SelectedItems[0];
                boxNome.Text     = item.SubItems[0].Text;
                boxEndereco.Text = item.SubItems[1].Text;
                boxTelefone.Text = item.SubItems[2].Text;
                boxEmail.Text    = item.SubItems[3].Text;
            }

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Enza";

        }

        private void CadastroAgenda_Load(object sender, EventArgs e)
        {
            // string escape = @"\n";
            // MessageBox.Show("Teste" + escape + "Teste");

            List<Pessoa> pessoasRegistros = ManipulaAgenda.Manipulacao.SelecionarRegistros();

            for (int contador = 0; contador < pessoasRegistros.Count; contador++)
            {
                ListViewItem item = new ListViewItem(new[] { pessoasRegistros[contador].Nome,
                                                             pessoasRegistros[contador].Endereco,
                                                             pessoasRegistros[contador].Telefone,
                                                             pessoasRegistros[contador].Email});
                lvAgenda.Items.Add(item);

                agenda.Armazenar(pessoasRegistros[contador].Nome,
                                pessoasRegistros[contador].Endereco,
                                pessoasRegistros[contador].Telefone,
                                pessoasRegistros[contador].Email);
            }
        }
    }
}
