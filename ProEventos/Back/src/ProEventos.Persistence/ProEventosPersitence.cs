using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class ProEventosPersitence : IProEventosPersistence
    {
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
        public void DeleteRange<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        //EVENTOS
        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }
        public Task<Evento[]> GetAllEventosAsync(string tema, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }
        public Task<Evento[]> GetEventosByIdAsync(int EventoId, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        //PALESTRANTES
        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }
        public Task<Palestrante[]> GetAllPalestrantesAsync(string tema, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }
        public Task<Palestrante[]> GetPalestrantesByIdAsync(int EventoId, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }
    }
}