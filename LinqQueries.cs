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

        public IEnumerable<Animal> AnimalesOrdenadosPorNombre()
        {
            return animalesCollection.OrderBy(p => p.Nombre);
        }

        public IEnumerable<Book> TresLibrosMasRecientesDeJava()
        {
            return librosCollection
                .Where(p => p.Categories.Contains("Java", StringComparer.OrdinalIgnoreCase))
                .OrderByDescending(p => p.PublishedDate)
                .Take(3);
        }

        public IEnumerable<Book> tercerYCuartoLibroConMasDe400Paginas()
        {
            return librosCollection
                .Where(p => p.PageCount > 400)
                .Skip(2)
                .Take(2);
        }

        public IEnumerable<Book> TituloYNumeroDePaginasDeLosPrimerosTresLibros()
        {
            return librosCollection
                .Take(3)
                .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
        }

        public int NumeroDeLibrosEntre200Y500Paginas()
        {
            //return librosCollection
            //    .Where(p => p.PageCount <= 500)
            //    .Where(p => p.PageCount >= 200)
            //    .Count();

            //Count permite insertar una condición y así evitar una operación extra.
            return librosCollection
                .Count(p => p.PageCount <= 500 &&  p.PageCount >= 200);
        }

        public DateTime MenorFechaDePublicacionDeLibros()
        {
            return librosCollection.Min(p => p.PublishedDate);
        }

        public int NumeroDePaginasDelLibroConMasPaginas()
        {
            return librosCollection.Max(p => p.PageCount);
        }

        public Book? LibroConMenorNumeroDePaginasPeroMayorQueCero()
        {
            return librosCollection
                .Where(p => p.PageCount > 0)
                .MinBy(p => p.PageCount);
        }

        public Book? libroConFechaDePublicacionMasReciente()
        {
            return librosCollection.MaxBy(p => p.PublishedDate);
        }

        public int NumeroDePaginasTotalesDeLosLibrosQueTienenEntre0Y500Paginas()
        {
            return librosCollection
                .Where(p => p.PageCount > 0 && p.PageCount <= 500)
                .Sum(p => p.PageCount);
        }

        public string TitulosDeLibrosDespuesDe2015Concatenados()
        {
            return librosCollection
                .Where(p => p.PublishedDate.Year >= 2015)
                .Aggregate("", (stringTitulo, libro) =>
                {
                    if (stringTitulo == string.Empty)
                        stringTitulo = libro.Title;
                    else
                        stringTitulo += " - " + libro.Title;

                    return stringTitulo;
                });
        }

        public double PromedioDeCaracteresQueTienenLosTitulos()
        {
            return librosCollection.Average(p => p.Title.Length);
        }

        public double PromedioDeNumeroDePaginasDeTodosLosLibros()
        {
            return librosCollection
                .Where(p => p.PageCount > 0)
                .Average(p => p.PageCount);
        }

        public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAno()
        {
            return librosCollection
                .Where(p => p.PublishedDate.Year >= 2000)
                .GroupBy(p => p.PublishedDate.Year);
        }

        public IEnumerable<IGrouping<string, Animal>> AnimalesAgrupadosPorColores()
        {
            return animalesCollection
                .GroupBy(p => p.Color);
        }

        public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
        {
            return librosCollection.ToLookup(p => p.Title[0], p => p);
        }

        public ILookup<int, Book> DiccionarioDeLibrosPorAno()
        {
            return librosCollection.ToLookup(p => p.PublishedDate.Year, p => p);
        }
    }
}
