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
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext _context)
        {
            this._context = _context;           
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                        .Include(e => e.Lotes)
                        .Include(e => e.RedeSociais);

            if(includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos) //A cada PalestrantesEventos, inclua o Palestrante
                .ThenInclude(e => e.Palestrante);
            }

            query = query.OrderBy(e =>e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                        .Include(e => e.Lotes)
                        .Include(e => e.RedeSociais);

            if(includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos) //A cada PalestrantesEventos, inclua o Palestrante
                .ThenInclude(e => e.Palestrante);
            }

            query = query.OrderBy(e =>e.Id)
                            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes  = false)
        {
            IQueryable<Evento> query = _context.Eventos
                        .Include(e => e.Lotes)
                        .Include(e => e.RedeSociais);

            if(includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos) //A cada PalestrantesEventos, inclua o Palestrante
                .ThenInclude(e => e.Palestrante);
            }

            query = query.OrderBy(e =>e.Id)
                            .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}