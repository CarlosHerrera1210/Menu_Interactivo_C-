using menu_ineractivo_c_.Models;

namespace menu_ineractivo_c_.Services;

public class PrestamoService
{
    private readonly List<Prestamo> prestamos = new();

    public void AgregarPrestamo(Prestamo prestamo)
    {
        prestamos.Add(prestamo);
    }

    public bool EliminarPrestamo(int id)
    {
        Prestamo? prestamo = prestamos.FirstOrDefault(item => item.Id == id);

        if (prestamo is null)
        {
            return false;
        }

        return prestamos.Remove(prestamo);
    }

    public List<Prestamo> ObtenerTodos()
    {
        return prestamos.ToList();
    }

    public void ReemplazarTodos(IEnumerable<Prestamo> nuevosPrestamos)
    {
        prestamos.Clear();
        prestamos.AddRange(nuevosPrestamos);
    }

    public void Limpiar()
    {
        prestamos.Clear();
    }

    public Prestamo? BuscarPorId(int id)
    {
        return prestamos.FirstOrDefault(prestamo => prestamo.Id == id);
    }

    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        return prestamos
            .Where(prestamo => prestamo.Estado == estado)
            .ToList();
    }

    public List<Prestamo> OrdenarPorFechaLimite()
    {
        return prestamos
            .OrderBy(prestamo => prestamo.FechaLimiteDevolucion)
            .ToList();
    }

    public int ObtenerTotalPrestamos()
    {
        return prestamos.Count;
    }

    public int ObtenerTotalActivos()
    {
        return prestamos.Count(prestamo => prestamo.Estado == EstadoPrestamo.Activo);
    }

    public int ObtenerTotalDevueltos()
    {
        return prestamos.Count(prestamo => prestamo.Estado == EstadoPrestamo.Devuelto);
    }

    public int ObtenerTotalVencidos()
    {
        return prestamos.Count(prestamo =>
            prestamo.Estado == EstadoPrestamo.Vencido || prestamo.EstaVencido());
    }

    public double ObtenerPromedioDiasPrestamo()
    {
        if (prestamos.Count == 0)
        {
            return 0;
        }

        return prestamos.Average(prestamo => prestamo.DiasTranscurridos());
    }
}
