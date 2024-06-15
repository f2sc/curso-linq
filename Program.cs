// See https://aka.ms/new-console-template for more information
using curso_linq;

//Console.WriteLine("¡Hola buenas tardes!");

LinqQueries queries = new LinqQueries();

ImprimirValores(queries.TodaLaColeccion());

void ImprimirValores(IEnumerable<Book> ListaDeLibros)
{
    Console.WriteLine("{0,-70}, {1, 7}, {2,11}\n","Titulo", "N. páginas", "Fecha publicacion");
    foreach(var item in ListaDeLibros)
    {
        Console.WriteLine("{0,-70}, {1, 7}, {2,11}\n", item.Title, item.PageCount, item.PublishedDate);
    }
}
