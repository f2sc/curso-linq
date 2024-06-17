using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace curso_linq
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries() 
        { 
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            }
        }

        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }

        public IEnumerable<Book> LibrosDespuesDel2000()
        {
            // Esta es la manera con Extension method
            //return librosCollection.Where(p => p.PublishedDate.Year > 2000).OrderByDescending(p => p.PublishedDate);
            //return librosCollection.Where(p => p.PublishedDate >= DateTime.Parse("01-01-2000"));

            // Esta es la manera con Query Expression
            return (from l in librosCollection where l.PublishedDate.Year > 2000 select l).OrderByDescending(p => p.PublishedDate);

        }
        public IEnumerable<Book> LibrosConMasDe250paginasInAction()
        {
            // Esta es la manera con Extension method
            //return librosCollection.Where(p => p.PageCount > 250).Where(p => p.Title.Contains("in Action"));
            return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            // Esta es la manera con Query Expression
            //return from l in librosCollection where l.Title.Contains("in Action") where l.PageCount > 250 select l;

        }
    }
}
