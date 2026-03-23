namespace menu_ineractivo_c_.Models;

public class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaLimiteDevolucion { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    public Prestamo()
    {
        Libro = new Libro();
        Usuario = new Usuario();
        FechaPrestamo = DateTime.Now;
        FechaLimiteDevolucion = DateTime.Now.AddDays(7);
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    public Prestamo(
        int id,
        Libro libro,
        Usuario usuario,
        DateTime fechaPrestamo,
        DateTime fechaLimiteDevolucion,
        DateTime? fechaDevolucion = null,
        EstadoPrestamo estado = EstadoPrestamo.Activo)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaLimiteDevolucion = fechaLimiteDevolucion;
        FechaDevolucion = fechaDevolucion;
        Estado = estado;
    }

    public bool EstaVencido()
    {
        return Estado == EstadoPrestamo.Activo &&
               FechaDevolucion is null &&
               DateTime.Now.Date > FechaLimiteDevolucion.Date;
    }

    public int DiasTranscurridos()
    {
        DateTime fechaFinal = FechaDevolucion ?? DateTime.Now;
        return (fechaFinal.Date - FechaPrestamo.Date).Days;
    }

    public string ResumenCorto()
    {
        return $"{Id} - {Libro.Titulo} -> {Usuario.NombreCompleto} | Estado: {Estado}";
    }

    public string DetalleCompleto()
    {
        string fechaDevolucion = FechaDevolucion?.ToString("dd/MM/yyyy") ?? "Pendiente";

        return
            $"Id: {Id}\n" +
            $"Libro: {Libro.Titulo}\n" +
            $"Usuario: {Usuario.NombreCompleto}\n" +
            $"Fecha prestamo: {FechaPrestamo:dd/MM/yyyy}\n" +
            $"Fecha limite de devolucion: {FechaLimiteDevolucion:dd/MM/yyyy}\n" +
            $"Fecha devolucion: {fechaDevolucion}\n" +
            $"Estado: {Estado}\n" +
            $"Esta vencido: {(EstaVencido() ? "Si" : "No")}\n" +
            $"Dias transcurridos: {DiasTranscurridos()}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
