using System;
using System.Collections.Generic;
using System.Text;

namespace Armazem
{
    public class Produto
    {
        List<Produto> ListaDaClasseProduto = new List<Produto>();
        private static int geradorId = 0;
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string PaisOrigem { get; set; }
        public string DataDeRegistro { get; set; }

        public Produto()
        {
            this.Id = System.Threading.Interlocked.Increment(ref geradorId);
        }
        public Produto(int id, string descricao, string paisorigem, string dataDeRegistro)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.PaisOrigem = paisorigem;
            this.DataDeRegistro = dataDeRegistro;
        }
        override
        public string ToString()
        {
            return " ID de cadastro: " + this.Id + " Descrição do produto: " + this.Descricao + "\n Pais de origem do produto: " + this.PaisOrigem + "\n Data de registro do produto: " + this.DataDeRegistro;
        }
    }
}
