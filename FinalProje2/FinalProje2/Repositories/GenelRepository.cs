using FinalProje2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalProje2.Depo
{
    public class GenelRepository<T> where T : class,new()
    {
        FilmContext c = new FilmContext();

        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }
        public void TEkle(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void TSil(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public void TGuncelle(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public T TGetir(int id)
        {
            return c.Set<T>().Find(id);
        }
        public List<T> Tlist(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
        public List<T> Plist(string n)
        {
            return c.Set<T>().Include(n).ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }
    }
}
