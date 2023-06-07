using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistence
{
    public class ProEventosPersitence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersitence(ProEventosContext _context)
        {
            this._context = _context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENTOS
        public async Task<Evento[]> GetAllEventosByTemaAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);
            

            if (includePalestrantes){

                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();

        }
        public async Task<Evento[]> GetAllEventosAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);
            

            if (includePalestrantes){

                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id) 
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);
            

            if (includePalestrantes){

                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id) 
                         .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
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