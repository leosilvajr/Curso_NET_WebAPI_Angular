using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }

        /*
            Um Palestrante pode participar de varios Eventos
            E um Evento pode ter varios Palestrantes 
        */
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

    }
}