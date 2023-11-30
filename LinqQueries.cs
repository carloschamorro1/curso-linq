public class LinqQueries
{
	private List<Book> librosCollection = new List<Book> ();


	public LinqQueries() 
	{
		using (StreamReader reader = new StreamReader("books.json"))
		{
			string json = reader.ReadToEnd();
			this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});

		}
	}

	public IEnumerable<Book> TodaLaColeccion()
	{
		return librosCollection;
	}

	public IEnumerable<Book> LibrosDespuesDel2000()
	{
		//extension method
		//return librosCollection.Where(p => p.PublishedDate.Year > 2000);

		//query expresion
		return from l in librosCollection 
		where l.PublishedDate.Year > 2000 
		select l;
	}

	public IEnumerable<Book> LibrosConMasDe250PagConPalabrasInAction(string titulo)
	{

		//extension method
		//return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains(titulo));
		
		//query expresion
		return from l in librosCollection
		where l.PageCount > 250 && l.Title.Contains(titulo)
		select l;
	}

	public bool TodosLosLibrosTieneStatus()
	{
		return librosCollection.All(p => p.Status != string.Empty);
	}

	public bool SiAlgunLibroFuePublicado2005()
	{
		return librosCollection.Any(p => p.PublishedDate.Year == 2005);
	}

	public IEnumerable<Book> LibrosDePython()
	{
		//extension method
		//return librosCollection.Where(p => p.Categories.Contains("Python"));
		
		//query expresion
		return from l in librosCollection
		where l.Categories.Contains("Python")
		select l;
	}

	public IEnumerable<Book> LibrosDeJavaPorNombreAscendente() 
	{
		//extension method
		return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
	}

	public IEnumerable<Book> LibrosDeMasDe450PagOrdenadosPorNumPagDescendente()
	{
		//extension method
		return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
	}

	public IEnumerable<Book> TresPrimerosLibrosDeJavaOrdenadosPorFecha()
	{
		return librosCollection.Where(p => p.Categories.Contains("Java"))
		.OrderBy(p => p.PublishedDate.Year)
		.TakeLast(3);
	}

	public IEnumerable<Book> TercerYCuartoLibroDeMas400Pag()
	{
		return librosCollection.Where(p => p.PageCount > 400)
		.Take(4)
		.Skip(2);
	}

	public IEnumerable<Book> TresPrimerosLibrosDeLaCollection()
	{
		return librosCollection.Take(3)
		.Select(p => new Book() {Title = p.Title,  PageCount =p.PageCount});
	}

	public int CantidadDeLibrosEntre200y500Pag()
	{
		return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
	}

	public DateTime FechaDePublicacionMenor()
	{
		return librosCollection.Min(p => p.PublishedDate);
	}

	public int LibroConMasPaginas()
	{
		return librosCollection.Max(p=> p.PageCount);
	}

	public Book LibroConMenosPaginasMayorACero()
	{
		return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
	}

	public Book LibroConFechaPublicacionMasReciente()
	{
		return librosCollection.MaxBy(p => p.PublishedDate);
	}

	public int SumaDeTodasLasPaginasLibrosEntre0Y500()
	{
		return librosCollection.Where(p=> p.PageCount >= 0 && p.PageCount <= 500)
		.Sum(p => p.PageCount);
	}

	public string TitulosDeLibrosDespuesDel2015Concatenados()
	{
		return librosCollection.Where(p => p.PublishedDate.Year > 2015)
		.Aggregate("", (TitulosLibros, next) => 
		{
			if(TitulosLibros!= string.Empty)
				TitulosLibros += " | " + next.Title;
			else
				TitulosLibros += next.Title;

			return TitulosLibros;
		});
	}

	public double PromedioCaracteresTitulo()
	{
		return librosCollection.Average(p => p.Title.Length);
	}

	public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAnio()
	{
		 return librosCollection.Where(p=> p.PublishedDate.Year >= 2000)
		 .GroupBy(p=> p.PublishedDate.Year);
	}

	public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
	{
		return librosCollection.ToLookup(p => p.Title[0], p => p);
	}

	public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Paginas()
	{
		var LibrosDespuesDel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);

		var LibrosConMasDe500Paginas = librosCollection.Where( p=> p.PageCount > 500);

		return LibrosDespuesDel2005
		.Join(LibrosConMasDe500Paginas, p=> p.Title, x=> x.Title, (p , x) => p);
	}

}