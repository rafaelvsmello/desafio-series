using DioSeries.Entities.Enums;
using System;

namespace DioSeries.Entities
{
    public class Serie : EntitieBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public void Excluir()
        {
            Excluido = true;
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int GetId()
        {
            return Id;
        }        

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Gênero: {Genero}" + Environment.NewLine;
            retorno += $"Título: {Titulo}" + Environment.NewLine;
            retorno += $"Descrição: {Descricao}" + Environment.NewLine;
            retorno += $"Ano de Lançamento: {Ano}";

            return retorno;
        }
    }
}
