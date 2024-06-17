// See https://aka.ms/new-console-template for more information
using curso_linq;

//Console.WriteLine("¡Hola buenas tardes!");

LinqQueries queries = new LinqQueries();

//ImprimirValores(queries.TodaLaColeccion());
//ImprimirValores(queries.LibrosDespuesDel2000());
//ImprimirValores(queries.LibrosConMasDe250paginasInAction());

//ImprimirAnimales(queries.AnimalesVerdesQueEmpiecenPorVocal());

//Console.WriteLine($" ¿Todos los libros tienen status? {queries.TodosLosLibrosTienenStatus()}");
Console.WriteLine($" ¿Algún libro fué publicado en 2005? {queries.AlgunoDeLosLibrosFueronPublicadosEn2005()}");




void ImprimirValores(IEnumerable<Book> ListaDeLibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n","Titulo", "N. páginas", "Fecha publicacion");
    foreach(var item in ListaDeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirAnimales(IEnumerable<Animal> ListaDeAnimales)
{
    Console.WriteLine("{0,-60} {1, 15}\n", "Nombre", "Color");
    foreach (var item in ListaDeAnimales)
    {
        Console.WriteLine("{0,-60} {1, 15}\n", item.Nombre, item.Color);
    }
}

