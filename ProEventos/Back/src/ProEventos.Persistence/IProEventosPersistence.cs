using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        //GERAL: Itens Gerais para adicioanr, deletar ou atualizar os elemntos q assim for necessário
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetEventosByIdAsync(int EventoId, bool includePalestrantes);

        //PALESTRANTES

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(string tema, bool includeEventos);
        Task<Palestrante[]> GetPalestrantesByIdAsync(int EventoId, bool includeEventos);


    }
}