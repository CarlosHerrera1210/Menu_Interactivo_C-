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
}
