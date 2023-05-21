using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote>  Lotes { get; set; } //UM EVENTO VAI TER DIVERSOS LOTES
        public IEnumerable<RedeSocial>  RedeSociais { get; set; } 

        /*
            Um Palestrante pode participar de varios Eventos
            E um Evento pode ter varios Palestrantes 
        */
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

    }
}