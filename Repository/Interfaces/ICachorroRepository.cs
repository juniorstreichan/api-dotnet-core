

using System.Collections.Generic;
using apiCachorro.Models;

namespace apiCachorro.Repository.Interfaces
{
    public interface ICachorroRepository
    {
        void Add(Cachorro cachorro);
        void Update(Cachorro cachorro);
        IEnumerable<Cachorro> GetAll();
        Cachorro FindById(long id);
        void RemoveById(long id);
    }
}