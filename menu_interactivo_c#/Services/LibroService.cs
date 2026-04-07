using menu_ineractivo_c_.Models;

namespace menu_ineractivo_c_.Services;

public class LibroService
{
    private readonly List<Libro> libros = new();

    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    public bool EliminarLibro(int id)
    {
        Libro? libro = libros.FirstOrDefault(item => item.Id == id);

        if (libro is null)
        {
            return false;
        }

        return libros.Remove(libro);
    }

    public List<Libro> ObtenerTodos()
    {
        return libros.ToList();
    }

    public void ReemplazarTodos(IEnumerable<Libro> nuevosLibros)
    {
        libros.Clear();
        libros.AddRange(nuevosLibros);
    }

    public void Limpiar()
    {
        libros.Clear();
    }

    public Libro? BuscarPorId(int id)
    {
        return libros.FirstOrDefault(libro => libro.Id == id);
    }

    public Libro? BuscarPorIsbn(string isbn)
    {
        return libros.FirstOrDefault(libro =>
            libro.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase));
    }

    public List<Libro> BuscarPorTitulo(string titulo)
    {
        return libros
            .Where(libro => libro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Libro> BuscarPorAutor(string autor)
    {
        return libros
            .Where(libro => libro.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Libro> OrdenarPorTitulo()
    {
        return libros
            .OrderBy(libro => libro.Titulo)
            .ToList();
    }

    public List<Libro> OrdenarPorAnioPublicacion()
    {
        return libros
            .OrderBy(libro => libro.AnioPublicacion)
            .ToList();
    }

    public int ObtenerTotalLibros()
    {
        return libros.Count;
    }

    public int ObtenerTotalDisponibles()
    {
        return libros.Count(libro => libro.Disponible);
    }

    public int ObtenerTotalPrestados()
    {
        return libros.Count(libro => !libro.Disponible);
    }
}
