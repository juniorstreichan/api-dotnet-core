using System.Collections.Generic;
using System.Linq;
using apiCachorro.Models;
using apiCachorro.Models.Context;
using apiCachorro.Repository.Interfaces;

namespace apiCachorro.Repository
{
    public class CachorroRepository : ICachorroRepository
    {
        private readonly CachorroDbContext _context;
        public CachorroRepository(CachorroDbContext ctx)
        {
            _context = ctx;
        }

        public void Add(Cachorro cachorro)
        {
            _context.Add(cachorro);
            _context.SaveChanges();
        }

        public Cachorro FindById(long id)
        {
            return _context.Cachorro.FirstOrDefault(
                c => c.CachorroId == id
            );
        }

        public IEnumerable<Cachorro> GetAll()
        {
            return _context.Cachorro.ToList();
        }

        public void RemoveById(long id)
        {
            var cachorro = this.FindById(id);
            _context.Cachorro.Remove(cachorro);
            _context.SaveChanges();
        }

        public void Update(Cachorro cachorro)
        {
            _context.Update(cachorro);
            _context.SaveChanges();
        }
    }
}