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
        private List<Animal> animalesCollection = new List<Animal>();

        public LinqQueries() 
        {
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
            }

            //Creo varias instancias de la clase Animal para operar con ellos.
            animalesCollection.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
            animalesCollection.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
            animalesCollection.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
            animalesCollection.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
            animalesCollection.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
            animalesCollection.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
            animalesCollection.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
            animalesCollection.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
            animalesCollection.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });

            // Escribe tu código aquí
            // filtra todos los animales que sean de color verde que su nombre inicie con una vocal
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

        public IEnumerable<Animal> AnimalesVerdesQueEmpiecenPorVocal() 
        {
            return animalesCollection.Where(p => p.Color.Equals("gris",StringComparison.CurrentCultureIgnoreCase)
            && (p.Nombre.StartsWith("a", StringComparison.CurrentCultureIgnoreCase) 
            || p.Nombre.StartsWith("e",StringComparison.CurrentCultureIgnoreCase) 
            || p.Nombre.StartsWith("i",StringComparison.CurrentCultureIgnoreCase) 
            || p.Nombre.StartsWith("o", StringComparison.CurrentCultureIgnoreCase) 
            || p.Nombre.StartsWith("u", StringComparison.CurrentCultureIgnoreCase))
            );
        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(p => p.Status != string.Empty);
        }

        public bool AlgunoDeLosLibrosFueronPublicadosEn2005()
        {
            return librosCollection.Any(p => p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> DevuelveLosLibrosSobrePython()
        {
            return librosCollection.Where(p => p.Title.Contains("Python",StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Book> LibrosDeJavaOrdenadosPorNombre()
        {
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
        }
        public IEnumerable<Book> LibrosDeMasDe450PaginasOrdenadasPorPagDescendiente()
        {
            return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
        }
    }
}
