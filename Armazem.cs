using System;
using System.Collections.Generic;
using System.Text;

namespace Armazem
{
    public class Armazem
    {
        public List<Produto> produtos = new List<Produto>();

        private static int geradorId = 0;
        public int Id { get; set; }
        public string NomeArmazem { get; set; }
        public string EnderecoArmazem { get; set; }

        public Armazem()
        {
            this.Id = System.Threading.Interlocked.Increment(ref geradorId);
        }
        public Armazem(int id, string nomeArmazem, string enderecoArmazem)
        {
            this.Id = id;
            this.NomeArmazem = nomeArmazem;
            this.EnderecoArmazem = enderecoArmazem;
        }
        override

        public string ToString()
        {
            return " ID do produto: " + this.Id + " Nome do armazem: " + this.NomeArmazem + "\n Endereço do armazem: " + this.EnderecoArmazem;
        }
    }
}
