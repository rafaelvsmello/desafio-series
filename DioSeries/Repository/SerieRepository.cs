using DioSeries.Entities;
using System.Collections.Generic;

namespace DioSeries.Repository
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> _listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            _listaSerie[id] = entidade; 
        }

        public void Exclui(int id)
        {
            _listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            _listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return _listaSerie;
        }

        public int ProximoId()
        {
            return _listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return _listaSerie[id];
        }
    }
}
