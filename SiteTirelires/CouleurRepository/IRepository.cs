using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiteTirelires.Models;

namespace SiteTirelires
{
    public interface IRepository<T>
    {
        IEnumerable<T> Lister();
        Couleur GetElementById(int id);
        void Create(T nouveau);
        void Delete(int id);
        void SaveChanges();
        void UpDate(T element);

        //IQueryable<Couleur>

        /*IEnumerable<Cupcake> GetCupcakes();
      Cupcake GetCupcakeById(int id);
      void CreateCupcake(Cupcake cupcake);
      void DeleteCupcake(int id);
      void SaveChanges();
      IQueryable<Bakery> PopulateBakeriesDropDownList();*/
    }
}
