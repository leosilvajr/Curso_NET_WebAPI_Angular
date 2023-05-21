using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext _context)
        {
            this._context = _context;           
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false) 
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                        .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                .Include(p => p.PalestrantesEventos) 
                .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p =>p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                        .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                .Include(p => p.PalestrantesEventos) 
                .ThenInclude(p => p.Evento);
            }

            query = query.AsNoTracking().OrderBy(p =>p.Id)
                            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                        .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                .Include(p => p.PalestrantesEventos) 
                .ThenInclude(p => p.Evento);
            }

            query = query.AsNoTracking().OrderBy(p =>p.Id)
                            .Where(p => p.Id == palestranteId);
            return await query.FirstOrDefaultAsync();
        }


    }
}