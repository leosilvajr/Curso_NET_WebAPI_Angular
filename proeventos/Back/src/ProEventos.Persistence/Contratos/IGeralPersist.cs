using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IGeralPersist
    {

        //Todas as ações que vamos ter no site vai passar por esses metodos

        //Criar um void generico que recebe a entidade onde o T é uma classe

        //GERAL
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        void DeleteRange<T>(T[] entity) where T:class; //Deletar varios.

        Task<bool> SaveChangesAsync();
    }
}