using System;

using menu_ineractivo_c_.Models;

class Program
{
    static void Main()
    {
        ShowMainMenu();
    }


    static void ShowMainMenu()
    {
        bool exit = false;

        while (!exit)
        {
            SafeClear();
            Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");

            string op = ReadOption();

            switch (op)
            {
                case "1":
                    ShowBooksMenu();
                    break;

                case "2":
                    ShowUsersMenu();
                    break;

                case "3":
                    ShowLoansMenu();
                    break;

                case "4":
                    ShowSearchReportsMenu();
                    break;

                case "5":
                    ShowPersistenceMenu();
                    break;

                case "6":
                    exit = ConfirmExitAndSave();
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    Pause();
                    break;
            }
        }
    }
    

    static void ShowBooksMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== GESTIÓN DE LIBROS ===");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": RegisterBook(); break;
                case "2": ListBooksMenu(); break;
                case "3": ViewBookDetail(); break;
                case "4": UpdateBookMenu(); break;
                case "5": DeleteBook(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void RegisterBook()
    {
        Libro libro = GetSampleBooks()[0];

        Console.WriteLine("=== OBJETO DE PRUEBA: REGISTRAR LIBRO ===");
        Console.WriteLine(libro.DetalleCompleto());
        Console.WriteLine($"ToString(): {libro}");
    }

    static void ListBooksMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== LISTAR LIBROS ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Disponibles");
            Console.WriteLine("3. Prestados");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": ListBooksAll(); break;
                case "2": ListBooksAvailable(); break;
                case "3": ListBooksBorrowed(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void ListBooksAll()
    {
        Console.WriteLine("=== RESUMENES DE LIBROS ===");

        foreach (Libro libro in GetSampleBooks())
        {
            Console.WriteLine(libro.ResumenCorto());
        }
    }

    static void ListBooksAvailable()
    {
        Console.WriteLine("=== LIBROS DISPONIBLES ===");

        foreach (Libro libro in GetSampleBooks().Where(libro => libro.Disponible))
        {
            Console.WriteLine(libro.ResumenCorto());
            Console.WriteLine($"Validacion Disponible: {libro.Disponible}");
            Console.WriteLine();
        }
    }

    static void ListBooksBorrowed()
    {
        Console.WriteLine("=== LIBROS PRESTADOS ===");

        foreach (Libro libro in GetSampleBooks().Where(libro => !libro.Disponible))
        {
            Console.WriteLine(libro.ResumenCorto());
            Console.WriteLine($"Validacion Disponible: {libro.Disponible}");
            Console.WriteLine();
        }
    }

    static void ViewBookDetail()
    {
        Console.WriteLine("=== DETALLES COMPLETOS DE LIBROS ===");

        foreach (Libro libro in GetSampleBooks())
        {
            Console.WriteLine(libro.DetalleCompleto());
            Console.WriteLine();
        }
    }

    static void UpdateBookMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== ACTUALIZAR LIBRO ===");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": EditBookTitle(); break;
                case "2": EditBookAuthor(); break;
                case "3": EditBookYearCategory(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void EditBookTitle()
    {
        Console.WriteLine("Simulación: editar título del libro.");
    }

    static void EditBookAuthor()
    {
        Console.WriteLine("Simulación: editar autor del libro.");
    }

    static void EditBookYearCategory()
    {
        Console.WriteLine("Simulación: editar año o categoría.");
    }

    static void DeleteBook()
    {
        Console.WriteLine("Simulación: eliminar libro (validar que no esté prestado).");
    }

    static void ShowUsersMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": RegisterUser(); break;
                case "2": ListUsers(); break;
                case "3": ViewUserDetail(); break;
                case "4": UpdateUserMenu(); break;
                case "5": DeleteUser(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void RegisterUser()
    {
        Usuario usuario = GetSampleUsers()[0];

        Console.WriteLine("=== OBJETO DE PRUEBA: REGISTRAR USUARIO ===");
        Console.WriteLine(usuario.DetalleCompleto());
        Console.WriteLine($"ToString(): {usuario}");
    }

    static void ListUsers()
    {
        Console.WriteLine("=== RESUMENES DE USUARIOS ===");

        foreach (Usuario usuario in GetSampleUsers())
        {
            Console.WriteLine(usuario.ResumenCorto());
            Console.WriteLine($"Validacion Activo: {usuario.Activo}");
            Console.WriteLine();
        }
    }

    static void ViewUserDetail()
    {
        Console.WriteLine("=== DETALLES COMPLETOS DE USUARIOS ===");

        foreach (Usuario usuario in GetSampleUsers())
        {
            Console.WriteLine(usuario.DetalleCompleto());
            Console.WriteLine();
        }
    }

    static void UpdateUserMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== ACTUALIZAR USUARIO ===");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": EditUserName(); break;
                case "2": EditUserContact(); break;
                case "3": ToggleUserActiveStatus(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void EditUserName()
    {
        Console.WriteLine("Simulación: editar nombre del usuario.");
    }

    static void EditUserContact()
    {
        Console.WriteLine("Simulación: editar contacto.");
    }

    static void ToggleUserActiveStatus()
    {
        Console.WriteLine("Simulación: activar o desactivar usuario.");
    }

    static void DeleteUser()
    {
        Console.WriteLine("Simulación: eliminar usuario (validar préstamos activos).");
    }

    static void ShowLoansMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== GESTIÓN DE PRÉSTAMOS ===");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": CreateLoan(); break;
                case "2": ListLoansMenu(); break;
                case "3": ViewLoanDetail(); break;
                case "4": RegisterReturn(); break;
                case "5": DeleteLoan(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void CreateLoan()
    {
        Prestamo prestamo = GetSampleLoan();

        Console.WriteLine("=== OBJETO DE PRUEBA: CREAR PRESTAMO ===");
        Console.WriteLine(prestamo.DetalleCompleto());
        Console.WriteLine();
        Console.WriteLine($"Validacion Estado: {prestamo.Estado}");
        Console.WriteLine($"Validacion FechaDevolucion inicial: {(prestamo.FechaDevolucion is null ? "null" : prestamo.FechaDevolucion.Value.ToString("dd/MM/yyyy"))}");
        Console.WriteLine($"Validacion usuario activo: {prestamo.Usuario.Activo}");
        Console.WriteLine($"Validacion libro disponible: {prestamo.Libro.Disponible}");
    }

    static void ListLoansMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== LISTAR PRÉSTAMOS ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": ListLoansAll(); break;
                case "2": ListLoansActive(); break;
                case "3": ListLoansClosed(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void ListLoansAll()
    {
        Prestamo prestamo = GetSampleLoan();

        Console.WriteLine("=== RESUMEN DEL PRESTAMO ===");
        Console.WriteLine(prestamo.ResumenCorto());
        Console.WriteLine($"Validacion Estado: {prestamo.Estado}");
    }

    static void ListLoansActive()
    {
        Prestamo prestamo = GetSampleLoan();

        Console.WriteLine("=== PRESTAMOS ACTIVOS ===");

        if (prestamo.Estado == EstadoPrestamo.Activo)
        {
            Console.WriteLine(prestamo.ResumenCorto());
        }
    }

    static void ListLoansClosed()
    {
        Prestamo prestamo = GetSampleLoan();

        Console.WriteLine("=== PRESTAMOS CERRADOS ===");

        if (prestamo.Estado != EstadoPrestamo.Activo)
        {
            Console.WriteLine(prestamo.ResumenCorto());
        }
        else
        {
            Console.WriteLine("No hay prestamos cerrados en el objeto de prueba.");
        }
    }

    static void ViewLoanDetail()
    {
        Prestamo prestamo = GetSampleLoan();

        Console.WriteLine("=== DETALLE COMPLETO DEL PRESTAMO ===");
        Console.WriteLine(prestamo.DetalleCompleto());
        Console.WriteLine();
        Console.WriteLine($"Validacion Estado: {prestamo.Estado}");
        Console.WriteLine($"Validacion EstaVencido(): {prestamo.EstaVencido()}");
        Console.WriteLine($"Validacion DiasTranscurridos(): {prestamo.DiasTranscurridos()}");
    }

    static void RegisterReturn()
    {
        Prestamo prestamo = GetSampleLoan();
        prestamo.FechaDevolucion = DateTime.Now;
        prestamo.Estado = EstadoPrestamo.Devuelto;

        Console.WriteLine("=== REGISTRAR DEVOLUCION ===");
        Console.WriteLine(prestamo.DetalleCompleto());
    }

    static void DeleteLoan()
    {
        Console.WriteLine("Simulación: eliminar préstamo.");
    }

    static void ShowSearchReportsMenu()
    {
        bool back = false;

        while (!back)
        {
            SafeClear();
            Console.WriteLine("=== BÚSQUEDAS Y REPORTES ===");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver");

            string op = ReadOption();

            switch (op)
            {
                case "1": SearchBook(); break;
                case "2": SearchUser(); break;
                case "3": ReportsMenu(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (!back)
            {
                Pause();
            }
        }
    }

    static void SearchBook()
    {
        Console.WriteLine("Simulación: buscar libro por título/autor/id/categoría.");
    }

    static void SearchUser()
    {
        Console.WriteLine("Simulación: buscar usuario por nombre o ID.");
    }

    static void ReportsMenu()
    {
        Console.WriteLine("Simulación: mostrar reportes.");
        Console.WriteLine("Reportes disponibles: por usuario, por libro, vencidos, resumen.");
    }

    static void ShowPersistenceMenu()
    {
        SafeClear();
        Console.WriteLine("=== GUARDAR / CARGAR DATOS ===");
        Console.WriteLine("1. Guardar datos");
        Console.WriteLine("2. Cargar datos");
        Console.WriteLine("3. Reiniciar datos");

        string op = ReadOption();

        switch (op)
        {
            case "1": SaveData(); break;
            case "2": LoadData(); break;
            case "3": ResetData(); break;
        }

        Pause();
    }

    static void SaveData()
    {
        Console.WriteLine("Simulación: datos guardados.");
    }

    static void LoadData()
    {
        Console.WriteLine("Simulación: datos cargados.");
    }

    static void ResetData()
    {
        Console.WriteLine("¿Seguro que desea reiniciar datos? (S/N)");
        string op = ReadOption();

        if (op.ToUpper() == "S")
        {
            Console.WriteLine("Simulación: datos reiniciados.");
        }
    }

     static bool ConfirmExitAndSave()
    {
        Console.WriteLine("¿Guardar antes de salir? (S/N)");
        string op = ReadOption();

        if (op.ToUpper() == "S")
        {
            SaveData();
        }

        return true;
    }

    static string ReadOption()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    static void Pause()
    {
        if (Console.IsInputRedirected || Console.IsOutputRedirected)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey(true);
    }

    static void SafeClear()
    {
        if (Console.IsOutputRedirected)
        {
            Console.WriteLine();
            return;
        }

        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            WriteAnsiClear();
        }
        catch (PlatformNotSupportedException)
        {
            WriteAnsiClear();
        }
    }

    static void WriteAnsiClear()
    {
        Console.Write("\u001b[2J\u001b[H");
    }

    static List<Libro> GetSampleBooks()
    {
        return new List<Libro>
        {
            new Libro(1, "Cien anos de soledad", "Gabriel Garcia Marquez", 1967, "Novela", "9780307474728"),
            new Libro(2, "Clean Code", "Robert C. Martin", 2008, "Programacion", "9780132350884", false)
        };
    }

    static List<Usuario> GetSampleUsers()
    {
        return new List<Usuario>
        {
            new Usuario(1, "Carlos Herrera", "carlos@example.com", "3001234567"),
            new Usuario(2, "Ana Gomez", "ana@example.com", "3009876543", false)
        };
    }

    static Prestamo GetSampleLoan()
    {
        Libro libroPrestado = GetSampleBooks()[1];
        Usuario usuarioActivo = GetSampleUsers()[0];

        return new Prestamo(
            1,
            libroPrestado,
            usuarioActivo,
            DateTime.Now.AddDays(-10),
            DateTime.Now.AddDays(-2));
    }
}
