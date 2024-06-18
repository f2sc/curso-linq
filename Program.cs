// See https://aka.ms/new-console-template for more information
using curso_linq;

//Console.WriteLine("¡Hola buenas tardes!");

LinqQueries queries = new LinqQueries();

//ImprimirValores(queries.TodaLaColeccion());
//ImprimirValores(queries.LibrosDespuesDel2000());
//ImprimirValores(queries.LibrosConMasDe250paginasInAction());

//ImprimirAnimales(queries.AnimalesVerdesQueEmpiecenPorVocal());

//Console.WriteLine($" ¿Todos los libros tienen status? {queries.TodosLosLibrosTienenStatus()}");
//Console.WriteLine($" ¿Algún libro fué publicado en 2005? {queries.AlgunoDeLosLibrosFueronPublicadosEn2005()}");

//ImprimirValores(queries.DevuelveLosLibrosSobrePython());
//ImprimirValores(queries.LibrosDeJavaOrdenadosPorNombre());
//ImprimirValores(queries.LibrosDeMasDe450PaginasOrdenadasPorPagDescendiente());

// Retorna los elementos de la colleción animal ordenados por nombre
//ImprimirAnimales(queries.AnimalesOrdenadosPorNombre());

//ImprimirValores(queries.TresLibrosMasRecientesDeJava());

//ImprimirValores(queries.tercerYCuartoLibroConMasDe400Paginas());

//ImprimirValoresSoloTituloYPaginas(queries.TituloYNumeroDePaginasDeLosPrimerosTresLibros());

//Console.WriteLine("Hay " + queries.NumeroDeLibrosEntre200Y500Paginas() + " libros que tienen entre 200 y 500 páginas.");
//Console.WriteLine($"Hay {queries.NumeroDeLibrosEntre200Y500Paginas()} libros que tienen entre 200 y 500 páginas.");

//Console.WriteLine($"El libro con la fecha de publicación más antiguo tiene fecha de: {queries.MenorFechaDePublicacionDeLibros()}");

Console.WriteLine($"El libro con más páginas tiene : {queries.NumeroDePaginasDelLibroConMasPaginas()} páginas");

void ImprimirValores(IEnumerable<Book> ListaDeLibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n","Titulo", "N. páginas", "Fecha publicacion");
    foreach(var item in ListaDeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirValoresSoloTituloYPaginas(IEnumerable<Book> ListaDeLibros)
{
    Console.WriteLine("{0,-60} {1, 15}\n","Titulo", "N. páginas");
    foreach(var item in ListaDeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15}\n", item.Title, item.PageCount);
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

