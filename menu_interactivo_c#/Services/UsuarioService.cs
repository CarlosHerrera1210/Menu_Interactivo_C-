using menu_ineractivo_c_.Models;

namespace menu_ineractivo_c_.Services;

public class UsuarioService
{
    private readonly List<Usuario> usuarios = new();

    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    public bool EliminarUsuario(int id)
    {
        Usuario? usuario = usuarios.FirstOrDefault(item => item.Id == id);

        if (usuario is null)
        {
            return false;
        }

        return usuarios.Remove(usuario);
    }

    public List<Usuario> ObtenerTodos()
    {
        return usuarios.ToList();
    }

    public void ReemplazarTodos(IEnumerable<Usuario> nuevosUsuarios)
    {
        usuarios.Clear();
        usuarios.AddRange(nuevosUsuarios);
    }

    public void Limpiar()
    {
        usuarios.Clear();
    }

    public Usuario? BuscarPorId(int id)
    {
        return usuarios.FirstOrDefault(usuario => usuario.Id == id);
    }

    public Usuario? BuscarPorDocumento(string documento)
    {
        return usuarios.FirstOrDefault(usuario =>
            usuario.Documento.Equals(documento, StringComparison.OrdinalIgnoreCase));
    }

    public List<Usuario> BuscarPorNombre(string nombre)
    {
        return usuarios
            .Where(usuario => usuario.NombreCompleto.Contains(nombre, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Usuario> OrdenarPorNombre()
    {
        return usuarios
            .OrderBy(usuario => usuario.NombreCompleto)
            .ToList();
    }

    public int ObtenerTotalUsuarios()
    {
        return usuarios.Count;
    }

    public int ObtenerTotalActivos()
    {
        return usuarios.Count(usuario => usuario.Activo);
    }

    public int ObtenerTotalInactivos()
    {
        return usuarios.Count(usuario => !usuario.Activo);
    }
}
