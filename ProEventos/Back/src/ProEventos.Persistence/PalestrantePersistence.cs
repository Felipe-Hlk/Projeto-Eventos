using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : InterfacePalestrantePersistence
    {
        private readonly ProEventosContext _context;
        public PalestrantePersistence(ProEventosContext context)
        {
            this._context = context;
        }
        //PALESTRANTES

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);
            

            if (includePalestrantes){

                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);
            

            if (includePalestrantes){

                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(p => p.Id) 
                        .Where(p => p.Nome.ToLower().Contains(Nome.ToLower));

            return await query.ToArrayAsync();
        }
        
        public async Task<Palestrante[]> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);
            

            if (includePalestrantes){

                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(p => p.Id) 
                        .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}