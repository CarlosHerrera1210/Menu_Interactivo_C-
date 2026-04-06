namespace menu_ineractivo_c_.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Documento { get; set; }
    public string NombreCompleto { get; set; }
    public string CorreoElectronico { get; set; }
    public string Telefono { get; set; }
    public bool Activo { get; set; }

    public Usuario()
    {
        Documento = string.Empty;
        NombreCompleto = string.Empty;
        CorreoElectronico = string.Empty;
        Telefono = string.Empty;
        Activo = true;
    }

    public Usuario(
        int id,
        string documento,
        string nombreCompleto,
        string correoElectronico,
        string telefono,
        bool activo = true)
    {
        Id = id;
        Documento = documento;
        NombreCompleto = nombreCompleto;
        CorreoElectronico = correoElectronico;
        Telefono = telefono;
        Activo = activo;
    }

    public string ResumenCorto()
    {
        return $"{Id} - {NombreCompleto} | Documento: {Documento} | Activo: {(Activo ? "Si" : "No")}";
    }

    public string DetalleCompleto()
    {
        return
            $"Id: {Id}\n" +
            $"Documento: {Documento}\n" +
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
