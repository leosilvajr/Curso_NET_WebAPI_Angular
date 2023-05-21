namespace ProEventos.Domain
{
    public class PalestranteEvento
    {

        /*
            Um Palestrante pode participar de varios Eventos
            E um Evento pode ter varios Palestrantes 
        */
        

        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }


        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}