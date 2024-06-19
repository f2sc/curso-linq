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

//Console.WriteLine($"El libro con más páginas tiene : {queries.NumeroDePaginasDelLibroConMasPaginas()} páginas");

//ImprimirValoresDelLibro(queries.LibroConMenorNumeroDePaginasPeroMayorQueCero());

//ImprimirValoresDelLibro(queries.libroConFechaDePublicacionMasReciente());

//Console.WriteLine($"La cantidad de páginas de todos los libros que tienen entre 0 y 500 páginas es de: {queries.NumeroDePaginasTotalesDeLosLibrosQueTienenEntre0Y500Paginas()} páginas.");

//Console.WriteLine($"Estos son los títulos de los libros publicados desde el año 2015:\n {queries.TitulosDeLibrosDespuesDe2015Concatenados()}");

//Console.WriteLine($"Promedio de caracteres que tienen los títulos:\n {queries.PromedioDeCaracteresQueTienenLosTitulos()}");

//Console.WriteLine($"Promedio de número de páginas que tienen todos los libros:\n {queries.PromedioDeNumeroDePaginasDeTodosLosLibros()}");

ImprimirValoresAgrupados(queries.LibrosDespuesDel2000AgrupadosPorAno());

void ImprimirValoresAgrupados(IEnumerable<IGrouping<int, Book>> ListaDeLibros)
{
    foreach(var grupo in ListaDeLibros)
    {
        Console.WriteLine("\n");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2,15}","Título", "N. páginas", "Fecha publicacion");
        foreach (var libro in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2,15}", libro.Title, libro.PageCount, libro.PublishedDate.ToShortDateString());
        }
    }
}

void ImprimirValores(IEnumerable<Book> ListaDeLibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n","Título", "N. páginas", "Fecha publicacion");
    foreach(var item in ListaDeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2,15}\n", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirValoresDelLibro(Book? Libro)
{
    if (Libro == null)
    {
        Console.WriteLine("No se ha encontrado ningún libro.");
        return;
    }
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n","Título", "N. páginas", "Fecha publicacion");
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n", Libro.Title, Libro.PageCount, Libro.PublishedDate.ToShortDateString());
}

void ImprimirValoresSoloTituloYPaginas(IEnumerable<Book> ListaDeLibros)
{
    Console.WriteLine("{0,-60} {1, 15}\n","Título", "N. páginas");
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

