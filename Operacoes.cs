using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Armazem
{
    public class Operacoes
    {
        Produto produto = new Produto();
        List<Produto> listaProdutos = new List<Produto>();
        List<Armazem> listaArmazem = new List<Armazem>();
        Armazem armazem = new Armazem();
        public void MenuInicial()
        {
            do
            {
                Console.WriteLine("OPÇÕES DO MENU");
                Console.WriteLine("1- Cadastrar.");
                Console.WriteLine("2- Atualizar.");
                Console.WriteLine("3- Remover.");
                Console.WriteLine("x- Sair.");
                Console.WriteLine("==============");
                string opcao1 = Console.ReadLine();

                if(opcao1 == "x")
                {
                    break;
                }
                switch (opcao1)
                {
                    case "1":
                        Console.WriteLine("1- Cadastrar produto: ");
                        Console.WriteLine("2- Cadastrar armazem: ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("Digite a descrição do produto: ");
                                produto.Descricao = Console.ReadLine();
                                Console.WriteLine("Digite o País de origem do produto: ");
                                produto.PaisOrigem = Console.ReadLine();
                                Console.WriteLine("Digite a data de registro do produto: ");
                                produto.DataDeRegistro = Console.ReadLine();
                                listaProdutos.Add(produto);
                                break;
                            case "2":
                                Console.WriteLine("Digite o nome do armazem que voce deseja registrar: ");
                                armazem.NomeArmazem = Console.ReadLine();
                                Console.WriteLine("Digite o endereço do armazem registrado: ");
                                armazem.EnderecoArmazem = Console.ReadLine();
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("1- Atualizar o produto: ");
                        Console.WriteLine("2- Atualizar armazem: ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                MostrarProdutosDisponiveis();
                                int i = BuscarIndiceProduto();
                                Console.WriteLine("Atualize a data de registro: ");
                                listaProdutos[i].DataDeRegistro = Console.ReadLine();
                                Console.WriteLine("Atualize a descrição do produto: ");
                                listaProdutos[i].Descricao = Console.ReadLine();
                                Console.WriteLine("Atualize o pais origem: ");
                                listaProdutos[i].PaisOrigem = Console.ReadLine();
                                break;
                            case "2":

                                MostrarArmazensDisponiveis();
                                int j = BuscarIndiceArmazem();
                                Console.WriteLine("Atualize o endereço do armazem: ");
                                listaArmazem[j].NomeArmazem = Console.ReadLine();
                                Console.WriteLine("Atualize o nome do armazem: ");
                                listaArmazem[j].EnderecoArmazem = Console.ReadLine();
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("1- Remover produto. ");
                        Console.WriteLine("2= Remover armazem. ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                RemoverProduto();
                                Console.WriteLine("Produto removido...");
                                break;
                            case "2":
                                RemoverArmazem();
                                Console.WriteLine("Armazem removido");
                                break;
                        }
                        break;
                }
            }
            while (true);
 

        }
        public void MostrarProdutosDisponiveis()
        {
            foreach (Produto produto in listaProdutos)
            {
                Console.WriteLine(produto.ToString());
            }
        }
        public void MostrarArmazensDisponiveis()
        {
            foreach (Armazem armazem in listaArmazem)
            {
                Console.WriteLine(armazem.ToString());
            }
        }
        private List<Armazem> SelecionarArmazem(int id)
        {
            return listaArmazem.Where(L => L.Id == id).ToList();

        }
        private List<Produto> SelecionarProduto(int id)
        {
            return listaProdutos.Where(P => P.Id == id).ToList();
        }
        private int BuscarIndiceArmazem()
        {
            int idArmazem = 0;
            int indiceArmazem = -1;
            var armazemQuery =
                from Armazem armazem in this.listaArmazem
                where armazem.Id == idArmazem
                select armazem;
            while (indiceArmazem == -1)
            {
                Console.WriteLine("Digite o id do armazem a ser atualizado: ");
                idArmazem = Convert.ToInt32(Console.ReadLine());
                foreach (var armazem in armazemQuery.Select((value, i) => new { i, value }))
                {
                    indiceArmazem = armazem.i;
                }
            }
            return indiceArmazem;
        }
        private int BuscarIndiceProduto()
        {
            int idProduto = 0;
            int indiceProduto = -1;
            var produtoQuery =
                from Produto produto in this.listaProdutos
                where produto.Id == idProduto
                select produto;
            while (indiceProduto == -1)
            {
                Console.WriteLine("Digite o id do produto a ser atualizado: ");
                idProduto = Convert.ToInt32(Console.ReadLine());
                foreach (var produto in produtoQuery.Select((value, i) => new { i, value }))
                {
                    indiceProduto = produto.i;
                }
            }
            return indiceProduto;
        }
        private void RemoverProduto()
        {
            listaProdutos.RemoveAt(BuscarIndiceProduto());
        }
        private void RemoverArmazem()
        {
            listaArmazem.RemoveAt(BuscarIndiceArmazem());
        }
    }
    
}
