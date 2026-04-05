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
}
