namespace menu_ineractivo_c_.Models;

public class Usuario
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; }
    public string CorreoElectronico { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; }

    public Usuario()
    {
        NombreCompleto = string.Empty;
        CorreoElectronico = string.Empty;
        Telefono = string.Empty;
        Activo = true;
    }

    public Usuario(
        int id,
        string nombreCompleto,
        string correoElectronico,
        string telefono,
        bool activo = true)
    {
        Id = id;
        NombreCompleto = nombreCompleto;
        CorreoElectronico = correoElectronico;
        Telefono = telefono;
        Activo = activo;
    }

    public string ResumenCorto()
    {
        return $"{Id} - {NombreCompleto} | Activo: {(Activo ? "Si" : "No")}";
    }

    public string DetalleCompleto()
    {
        return
            $"Id: {Id}\n" +
            $"Nombre completo: {NombreCompleto}\n" +
            $"Correo electronico: {CorreoElectronico}\n" +
            $"Telefono: {Telefono}\n" +
            $"Activo: {(Activo ? "Si" : "No")}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
