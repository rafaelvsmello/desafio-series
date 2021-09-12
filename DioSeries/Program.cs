using DioSeries.Entities;
using DioSeries.Entities.Enums;
using DioSeries.Repository;
using System;
using System.Collections.Generic;

namespace DioSeries
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opcão inválida");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        static string ObterOpcaoUsuario()
        {
            Console.WriteLine("*** Bem-vindo ao  DioSeries ***");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            Console.Write("Escolha: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        static void VisualizarSerie()
        {
            Console.WriteLine("[Visualizar série]");
            Console.WriteLine();

            Console.Write("Digite o ID da série: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Serie serie = repository.RetornaPorId(id);
            Console.WriteLine(serie);
            Console.WriteLine();
        }

        static void ListarSeries()
        {
            Console.WriteLine("[Listar séries]");
            Console.WriteLine();

            List<Serie> lista = repository.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada");
                Console.WriteLine();
                return;
            }

            foreach (Serie serie in lista)
            {
                var serieExcluida = serie.RetornarExcluido();

                Console.WriteLine("#ID:{0} - {1} {2}", serie.RetornarId(), serie.RetornarTitulo(), (serieExcluida ? "*Excluída*" : ""));
            }

            Console.WriteLine();
        }

        static void InserirSerie()
        {
            Console.WriteLine("[Inserir nova série]");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();
            Console.Write("Informe o gênero da série: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição da série: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int ano = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repository.ProximoId(),
                genero: (Genero)genero,
                titulo: titulo,
                descricao: descricao,
                ano: ano);

            repository.Insere(novaSerie);
            Console.WriteLine("Série cadastrada com sucesso!");
            Console.WriteLine();
        }

        static void AtualizarSerie()
        {
            Console.WriteLine("[Atualizar série]");
            Console.WriteLine();

            Console.Write("Informe o ID da série: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();
            Console.Write("Informe o novo gênero da série: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo título da série: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a nova descrição da série: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o novo ano da série: ");
            int ano = int.Parse(Console.ReadLine());

            Serie alterarSerie = new Serie(id: id,
                genero: (Genero)genero,
                titulo: titulo,
                descricao: descricao,
                ano: ano);

            repository.Atualiza(id, alterarSerie);
            Console.WriteLine("Série atualizada com sucesso!");
            Console.WriteLine();
        }

        static void ExcluirSerie()
        {
            Console.WriteLine("[Excluir série]");
            Console.WriteLine();

            Console.Write("Digite o ID da série: ");
            int id = int.Parse(Console.ReadLine());

            repository.Exclui(id);
            Console.WriteLine("Série excluida com sucesso!");
            Console.WriteLine();
        }
    }
}
