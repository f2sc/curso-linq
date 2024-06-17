// See https://aka.ms/new-console-template for more information
using curso_linq;

//Console.WriteLine("¡Hola buenas tardes!");

LinqQueries queries = new LinqQueries();

//ImprimirValores(queries.TodaLaColeccion());
//ImprimirValores(queries.LibrosDespuesDel2000());
ImprimirValores(queries.LibrosConMasDe250paginasInAction());

void ImprimirValores(IEnumerable<Book> ListaDeLibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n","Titulo", "N. páginas", "Fecha publicacion");
    foreach(var item in ListaDeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }


}
