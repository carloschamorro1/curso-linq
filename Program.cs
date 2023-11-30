// See https://aka.ms/new-console-template for more information

LinqQueries queries = new LinqQueries();

//Toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesDel2000());

//Libros con mas de 250 paginas y titulo que contenga "Action"
//ImprimirValores(queries.LibrosConMasDe250PagConPalabrasInAction("in Action"));

//Todos los libros tienen status
//Console.WriteLine($" Todos los libros tienen status? -{queries.TodosLosLibrosTieneStatus()}");

//Si algun libro fue publicado en 2005
//Console.WriteLine($" Si algun libro fue publicado en 2005? -{queries.SiAlgunLibroFuePublicado2005()}");

//Libros de Python
//ImprimirValores(queries.LibrosDePython());

//Libros de Java por nombre ascendente
//ImprimirValores(queries.LibrosDeMasDe450PagOrdenadosPorNumPagDescendente());

//Tres primeros libros de Java ordenados por fecha
//ImprimirValores(queries.TresPrimerosLibrosDeJavaOrdenadosPorFecha());

//tercer y cuarto libro de Java con mas de 450 paginas
//ImprimirValores(queries.TercerYCuartoLibroDeMas400Pag());

//tres primeros libros filtrados por select
//ImprimirValores(queries.TresPrimerosLibrosDeLaCollection());

//Cantidad de libros que tienen entre 200 y 500 paginas
//Console.WriteLine($"Cantidad de libros entre 200 y 500 paginas = {queries.CantidadDeLibrosEntre200y500Pag()}");

//Fecha de publicacion menor de todos los libros
//Console.WriteLine($"Fecha de publicacion menor: {queries.FechaDePublicacionMenor()}");

//Libro con mas paginas
//Console.WriteLine($"El libro con mas paginas tiene {queries.LibroConMasPaginas()} paginas");

//libro con menor numero de paginas
//var libroMenorPag = queries.LibroConMenosPaginasMayorACero();
//Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");

//libro con fecha de publicacion mas reciente
//var libroMasReciente = queries.LibroConFechaPublicacionMasReciente();
//Console.WriteLine($"{libroMasReciente.Title} - {libroMasReciente.PublishedDate.ToShortDateString()}");

//suma de paginas de libros que tienen entre 0 y 500 paginas
//Console.WriteLine($"La suma total de paginas es {queries.SumaDeTodasLasPaginasLibrosEntre0Y500()}");

//Libros publicados despues del 2015
//Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015Concatenados());

//Promedio de caracteres del titulo de los libros
//Console.WriteLine($"Promedio caracteres de los titulos: {queries.PromedioCaracteresTitulo()}");

//Libros publicados a partir del 2000 agrupados por anio
//ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAnio());

//Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookup = queries.DiccionarioDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'J');

// libros filtradaor con la clausula join 
ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Paginas());

void ImprimirValores(IEnumerable<Book> listaDeLibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (Book libro in listaDeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", libro.Title, libro.PageCount, libro.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine("====================================================================================");
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
   Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
   foreach(var item in ListadeLibros[letra])
   {
         Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
   }
}
