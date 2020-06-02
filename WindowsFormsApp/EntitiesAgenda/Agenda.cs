using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.EntitiesAgenda
{
    public class Agenda
    {
        private bool ordemLista;
        private List<Pessoa> listaAgenda = new List<Pessoa>();

        public List<Pessoa> ListaAgenda { get => listaAgenda; set => listaAgenda = value; }
        public bool OrdemLista { get => ordemLista; set => ordemLista = value; }

        public void Armazenar(string nome, string endereco,
                              string telefone, string email)
        {
            Pessoa pessoa = new Pessoa(nome, endereco, telefone, email);
            ListaAgenda.Add(pessoa);
        }

        public void Remover(int index)
        {
            ListaAgenda.RemoveAt(index);
        }

        public void Ordenar()
        {
            if (!OrdemLista)
            {
                ListaAgenda = ListaAgenda.OrderBy(item => item.Nome).ToList();
                OrdemLista = true;
            }
            else
            {
                ListaAgenda = ListaAgenda.OrderByDescending(item => item.Nome).ToList();
                OrdemLista = false;
            }
        }

        public int RetornarTamanhoLista()
        {
            return ListaAgenda.Count;
        }

        public Pessoa RetornarPessoa(int index)
        {
            return ListaAgenda[index];
        }

        public void Editar(Pessoa pessoa, int index)
        {
            listaAgenda[index].Nome = pessoa.Nome;
            listaAgenda[index].Endereco = pessoa.Endereco;
            listaAgenda[index].Telefone = pessoa.Telefone;
            listaAgenda[index].Email = pessoa.Email;

        }
    }
}
