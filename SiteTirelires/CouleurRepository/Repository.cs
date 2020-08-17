using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
//using SiteTirelires.DataAccess;
using SiteTirelires.Models;
using Microsoft.EntityFrameworkCore;

using SiteTirelires;
using System.Data.Entity;

namespace SiteTirelires
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private TireliresContext _context;

        public Repository(): this(new TireliresContext(new DbContextOptions<TireliresContext>()))       //TireliresContext => Data.identityContext
        { }

        public Repository(TireliresContext ctx)
        {
            _context = ctx;
        }

        public void Create(T nouveau)
        {
            _context.Set<T>().Add(nouveau);
            _context.SaveChanges();
            
            //if (nouveau.Designation != null && nouveau.Designation.Length > 0)
            //{
            //    _context.Add(nouveau);
            //    _context.SaveChanges();
            //}
        }

        public void Delete(int id)
        {
            var couleur = _context.Couleur.SingleOrDefault(c => c.Id == id);
            _context.Couleur.Remove(couleur);
            _context.SaveChanges();
        }

        public Couleur GetElementById(int id)
        {
            return _context.Couleur.Find(id);
        }

        public IEnumerable<T> Lister()
        {
            return _context.Set<T>().ToList<T>();
        }

        public void SaveChanges()
        {
            //_context.SaveChanges();
            throw new NotImplementedException();
        }

        public void UpDate(T element)
        {
            try
            {
                _context.Attach(element);
                _context.Entry(element).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
