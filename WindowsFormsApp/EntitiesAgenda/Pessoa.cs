using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.EntitiesAgenda
{
    public class Pessoa
    {
        //Atributos = propriedades, campos de uma classe

        private string email;
        private string nome;
        private string endereco;
        private string telefone;

        // Encapsula os campos. 
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }

        // Multiplos construtores
        // São chamados no momento em que o objeto é instanciado.
        public Pessoa()
        {

        }

        public Pessoa(string nome, string endereco,
                      string telefone, string email)
        {
            /*
            if (nome.Length < 3)
                throw new DomainException("Nome Invalido");

            if (endereco.Length < 3)
                throw new DomainException("Endereco Invalido");

            if (telefone.Length < 8)
                throw new DomainException("Telefone Invalido");

            if (email.Length < 3)
                throw new DomainException("E-mail Invalido");
            */
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }
    }
}
