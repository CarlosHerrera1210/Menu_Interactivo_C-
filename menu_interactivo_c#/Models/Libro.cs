namespace menu_ineractivo_c_.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnioPublicacion { get; set; }
    public string Categoria { get; set; }
    public string Isbn { get; set; }
    public bool Disponible { get; set; }

    public Libro()
    {
        Titulo = string.Empty;
        Autor = string.Empty;
        Categoria = string.Empty;
        Isbn = string.Empty;
        Disponible = true;
    }

    public Libro(
        int id,
        string titulo,
        string autor,
        int anioPublicacion,
        string categoria,
        string isbn,
        bool disponible = true)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anioPublicacion;
        Categoria = categoria;
        Isbn = isbn;
        Disponible = disponible;
    }

    public string ResumenCorto()
    {
        return $"{Id} - {Titulo} | {Autor} | Disponible: {(Disponible ? "Si" : "No")}";
    }

    public string DetalleCompleto()
    {
        return
            $"Id: {Id}\n" +
            $"Titulo: {Titulo}\n" +
            $"Autor: {Autor}\n" +
            $"Anio de publicacion: {AnioPublicacion}\n" +
            $"Categoria: {Categoria}\n" +
            $"ISBN: {Isbn}\n" +
            $"Disponible: {(Disponible ? "Si" : "No")}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
