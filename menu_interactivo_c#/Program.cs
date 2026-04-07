using System;

using menu_ineractivo_c_.Models;
using menu_ineractivo_c_.Services;

class Program
{
    private static readonly LibroService libroService = new();
    private static readonly UsuarioService usuarioService = new();
    private static readonly PrestamoService prestamoService = new();

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
        Console.WriteLine("=== REGISTRAR LIBRO ===");

        int id = GetNextBookId();
        Console.Write("Titulo: ");
        string titulo = ReadOption();
        Console.Write("Autor: ");
        string autor = ReadOption();
        int anioPublicacion = ReadInt("Anio de publicacion: ");
        Console.Write("Categoria: ");
        string categoria = ReadOption();
        Console.Write("ISBN: ");
        string isbn = ReadOption();

        Libro libro = new(id, titulo, autor, anioPublicacion, categoria, isbn);
        libroService.AgregarLibro(libro);

        Console.WriteLine();
        Console.WriteLine("Libro registrado correctamente.");
        Console.WriteLine(libro.DetalleCompleto());
        Console.WriteLine($"Total libros en List<T>: {libroService.ObtenerTotalLibros()}");
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

        if (libroService.ObtenerTotalLibros() == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        foreach (Libro libro in libroService.ObtenerTodos())
        {
            Console.WriteLine(libro.ResumenCorto());
        }
    }

    static void ListBooksAvailable()
    {
        Console.WriteLine("=== LIBROS DISPONIBLES ===");

        List<Libro> librosDisponibles = libroService.ObtenerTodos().Where(libro => libro.Disponible).ToList();

        if (librosDisponibles.Count == 0)
        {
            Console.WriteLine("No hay libros disponibles.");
            return;
        }

        foreach (Libro libro in librosDisponibles)
        {
            Console.WriteLine(libro.ResumenCorto());
            Console.WriteLine($"Validacion Disponible: {libro.Disponible}");
            Console.WriteLine();
        }
    }

    static void ListBooksBorrowed()
    {
        Console.WriteLine("=== LIBROS PRESTADOS ===");

        List<Libro> librosPrestados = libroService.ObtenerTodos().Where(libro => !libro.Disponible).ToList();

        if (librosPrestados.Count == 0)
        {
            Console.WriteLine("No hay libros prestados.");
            return;
        }

        foreach (Libro libro in librosPrestados)
        {
            Console.WriteLine(libro.ResumenCorto());
            Console.WriteLine($"Validacion Disponible: {libro.Disponible}");
            Console.WriteLine();
        }
    }

    static void ViewBookDetail()
    {
        Console.WriteLine("=== DETALLES COMPLETOS DE LIBROS ===");
        int id = ReadInt("Ingrese el ID del libro: ");
        Libro? libro = libroService.BuscarPorId(id);

        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
            return;
        }

        Console.WriteLine(libro.DetalleCompleto());
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
        Console.WriteLine("=== EDITAR TITULO DEL LIBRO ===");
        Libro? libro = GetBookByIdFromInput();

        if (libro is null)
        {
            return;
        }

        Console.Write("Nuevo titulo: ");
        libro.Titulo = ReadOption();
        Console.WriteLine("Titulo actualizado correctamente.");
        Console.WriteLine(libro.DetalleCompleto());
    }

    static void EditBookAuthor()
    {
        Console.WriteLine("=== EDITAR AUTOR DEL LIBRO ===");
        Libro? libro = GetBookByIdFromInput();

        if (libro is null)
        {
            return;
        }

        Console.Write("Nuevo autor: ");
        libro.Autor = ReadOption();
        Console.WriteLine("Autor actualizado correctamente.");
        Console.WriteLine(libro.DetalleCompleto());
    }

    static void EditBookYearCategory()
    {
        Console.WriteLine("=== EDITAR ANIO Y CATEGORIA DEL LIBRO ===");
        Libro? libro = GetBookByIdFromInput();

        if (libro is null)
        {
            return;
        }

        libro.AnioPublicacion = ReadInt("Nuevo anio de publicacion: ");
        Console.Write("Nueva categoria: ");
        libro.Categoria = ReadOption();
        Console.WriteLine("Anio y categoria actualizados correctamente.");
        Console.WriteLine(libro.DetalleCompleto());
    }

    static void DeleteBook()
    {
        Console.WriteLine("=== ELIMINAR LIBRO ===");
        int id = ReadInt("Ingrese el ID del libro a eliminar: ");
        Libro? libro = libroService.BuscarPorId(id);

        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
            return;
        }

        if (!libro.Disponible)
        {
            Console.WriteLine("No se puede eliminar un libro prestado.");
            return;
        }

        bool eliminado = libroService.EliminarLibro(id);
        Console.WriteLine(eliminado ? "Libro eliminado correctamente." : "No fue posible eliminar el libro.");
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
        Console.WriteLine("=== REGISTRAR USUARIO ===");

        int id = GetNextUserId();
        Console.Write("Documento: ");
        string documento = ReadOption();
        Console.Write("Nombre completo: ");
        string nombreCompleto = ReadOption();
        Console.Write("Correo electronico: ");
        string correo = ReadOption();
        Console.Write("Telefono: ");
        string telefono = ReadOption();

        Usuario usuario = new(id, documento, nombreCompleto, correo, telefono);
        usuarioService.AgregarUsuario(usuario);

        Console.WriteLine();
        Console.WriteLine("Usuario registrado correctamente.");
        Console.WriteLine(usuario.DetalleCompleto());
        Console.WriteLine($"Total usuarios en List<T>: {usuarioService.ObtenerTotalUsuarios()}");
    }

    static void ListUsers()
    {
        Console.WriteLine("=== RESUMENES DE USUARIOS ===");

        if (usuarioService.ObtenerTotalUsuarios() == 0)
        {
            Console.WriteLine("No hay usuarios registrados.");
            return;
        }

        foreach (Usuario usuario in usuarioService.ObtenerTodos())
        {
            Console.WriteLine(usuario.ResumenCorto());
            Console.WriteLine($"Validacion Activo: {usuario.Activo}");
            Console.WriteLine();
        }
    }

    static void ViewUserDetail()
    {
        Console.WriteLine("=== DETALLES COMPLETOS DE USUARIOS ===");
        int id = ReadInt("Ingrese el ID del usuario: ");
        Usuario? usuario = usuarioService.BuscarPorId(id);

        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        Console.WriteLine(usuario.DetalleCompleto());
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
        Console.WriteLine("=== EDITAR NOMBRE DEL USUARIO ===");
        Usuario? usuario = GetUserByIdFromInput();

        if (usuario is null)
        {
            return;
        }

        Console.Write("Nuevo nombre completo: ");
        usuario.NombreCompleto = ReadOption();
        Console.WriteLine("Nombre actualizado correctamente.");
        Console.WriteLine(usuario.DetalleCompleto());
    }

    static void EditUserContact()
    {
        Console.WriteLine("=== EDITAR CONTACTO DEL USUARIO ===");
        Usuario? usuario = GetUserByIdFromInput();

        if (usuario is null)
        {
            return;
        }

        Console.Write("Nuevo correo electronico: ");
        usuario.CorreoElectronico = ReadOption();
        Console.Write("Nuevo telefono: ");
        usuario.Telefono = ReadOption();
        Console.WriteLine("Contacto actualizado correctamente.");
        Console.WriteLine(usuario.DetalleCompleto());
    }

    static void ToggleUserActiveStatus()
    {
        Console.WriteLine("=== ACTIVAR / DESACTIVAR USUARIO ===");
        Usuario? usuario = GetUserByIdFromInput();

        if (usuario is null)
        {
            return;
        }

        usuario.Activo = !usuario.Activo;
        Console.WriteLine($"Estado actualizado. Activo: {(usuario.Activo ? "Si" : "No")}");
        Console.WriteLine(usuario.DetalleCompleto());
    }

    static void DeleteUser()
    {
        Console.WriteLine("=== ELIMINAR USUARIO ===");
        int id = ReadInt("Ingrese el ID del usuario a eliminar: ");
        Usuario? usuario = usuarioService.BuscarPorId(id);

        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        bool tienePrestamosActivos = prestamoService
            .ObtenerTodos()
            .Any(prestamo => prestamo.Usuario.Id == id && prestamo.Estado == EstadoPrestamo.Activo);

        if (tienePrestamosActivos)
        {
            Console.WriteLine("No se puede eliminar un usuario con prestamos activos.");
            return;
        }

        bool eliminado = usuarioService.EliminarUsuario(id);
        Console.WriteLine(eliminado ? "Usuario eliminado correctamente." : "No fue posible eliminar el usuario.");
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
        Console.WriteLine("=== CREAR PRESTAMO ===");
        List<Libro> librosDisponibles = libroService.ObtenerTodos().Where(libro => libro.Disponible).ToList();
        List<Usuario> usuariosActivos = usuarioService.ObtenerTodos().Where(usuario => usuario.Activo).ToList();

        if (librosDisponibles.Count == 0)
        {
            Console.WriteLine("No hay libros disponibles para prestar.");
            return;
        }

        if (usuariosActivos.Count == 0)
        {
            Console.WriteLine("No hay usuarios activos para prestar libros.");
            return;
        }

        Console.WriteLine("Libros disponibles:");
        foreach (Libro libroDisponible in librosDisponibles)
        {
            Console.WriteLine(libroDisponible.ResumenCorto());
        }

        Console.WriteLine();
        Console.WriteLine("Usuarios activos:");
        foreach (Usuario usuarioActivo in usuariosActivos)
        {
            Console.WriteLine(usuarioActivo.ResumenCorto());
        }

        Console.WriteLine();
        int libroId = ReadInt("Ingrese el ID del libro: ");
        int usuarioId = ReadInt("Ingrese el ID del usuario: ");
        int diasPrestamo = ReadInt("Ingrese la cantidad de dias del prestamo: ");

        Libro? libro = libroService.BuscarPorId(libroId);
        Usuario? usuario = usuarioService.BuscarPorId(usuarioId);

        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
            return;
        }

        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
            return;
        }

        if (!libro.Disponible)
        {
            Console.WriteLine("El libro no esta disponible.");
            return;
        }

        if (!usuario.Activo)
        {
            Console.WriteLine("El usuario no esta activo.");
            return;
        }

        Prestamo prestamo = new(
            GetNextLoanId(),
            libro,
            usuario,
            DateTime.Now,
            DateTime.Now.AddDays(diasPrestamo));

        libro.Disponible = false;
        prestamoService.AgregarPrestamo(prestamo);

        Console.WriteLine();
        Console.WriteLine("Prestamo creado correctamente.");
        Console.WriteLine(prestamo.DetalleCompleto());
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
        Console.WriteLine("=== RESUMENES DE PRESTAMOS ===");

        foreach (Prestamo prestamo in prestamoService.ObtenerTodos())
        {
            Console.WriteLine(prestamo.ResumenCorto());
            Console.WriteLine($"Validacion Estado: {prestamo.Estado}");
            Console.WriteLine();
        }
    }

    static void ListLoansActive()
    {
        Console.WriteLine("=== PRESTAMOS ACTIVOS ===");

        foreach (Prestamo prestamo in prestamoService.BuscarPorEstado(EstadoPrestamo.Activo))
        {
            Console.WriteLine(prestamo.ResumenCorto());
        }
    }

    static void ListLoansClosed()
    {
        List<Prestamo> prestamosCerrados = prestamoService
            .ObtenerTodos()
            .Where(prestamo => prestamo.Estado != EstadoPrestamo.Activo)
            .ToList();

        Console.WriteLine("=== PRESTAMOS CERRADOS ===");

        if (prestamosCerrados.Count > 0)
        {
            foreach (Prestamo prestamo in prestamosCerrados)
            {
                Console.WriteLine(prestamo.ResumenCorto());
            }
        }
        else
        {
            Console.WriteLine("No hay prestamos cerrados en el objeto de prueba.");
        }
    }

    static void ViewLoanDetail()
    {
        int id = ReadInt("Ingrese el ID del prestamo: ");
        Prestamo? prestamo = prestamoService.BuscarPorId(id);

        if (prestamo is null)
        {
            Console.WriteLine("Prestamo no encontrado.");
            return;
        }

        Console.WriteLine("=== DETALLE COMPLETO DEL PRESTAMO ===");
        Console.WriteLine(prestamo.DetalleCompleto());
        Console.WriteLine();
        Console.WriteLine($"Validacion Estado: {prestamo.Estado}");
        Console.WriteLine($"Validacion EstaVencido(): {prestamo.EstaVencido()}");
        Console.WriteLine($"Validacion DiasTranscurridos(): {prestamo.DiasTranscurridos()}");
    }

    static void RegisterReturn()
    {
        Console.WriteLine("=== REGISTRAR DEVOLUCION ===");
        Console.WriteLine("Prestamos activos:");
        foreach (Prestamo prestamoActivo in prestamoService.BuscarPorEstado(EstadoPrestamo.Activo))
        {
            Console.WriteLine(prestamoActivo.ResumenCorto());
        }

        int id = ReadInt("Ingrese el ID del prestamo a devolver: ");
        Prestamo? prestamo = prestamoService.BuscarPorId(id);

        if (prestamo is null || prestamo.Estado != EstadoPrestamo.Activo)
        {
            Console.WriteLine("Prestamo activo no encontrado.");
            return;
        }

        prestamo.FechaDevolucion = DateTime.Now;
        prestamo.Estado = EstadoPrestamo.Devuelto;
        prestamo.Libro.Disponible = true;
        Console.WriteLine(prestamo.DetalleCompleto());
    }

    static void DeleteLoan()
    {
        Console.WriteLine("=== ELIMINAR PRESTAMO ===");
        int id = ReadInt("Ingrese el ID del prestamo a eliminar: ");
        Prestamo? prestamo = prestamoService.BuscarPorId(id);

        if (prestamo is null)
        {
            Console.WriteLine("Prestamo no encontrado.");
            return;
        }

        if (prestamo.Estado == EstadoPrestamo.Activo)
        {
            prestamo.Libro.Disponible = true;
        }

        bool eliminado = prestamoService.EliminarPrestamo(id);
        Console.WriteLine(eliminado ? "Prestamo eliminado correctamente." : "No fue posible eliminar el prestamo.");
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
        Console.WriteLine("=== BUSQUEDA DE LIBROS EN SERVICES ===");
        Console.WriteLine("1. Buscar por ISBN");
        Console.WriteLine("2. Buscar por titulo");
        Console.WriteLine("3. Buscar por autor");
        string op = ReadOption();

        switch (op)
        {
            case "1":
                Console.Write("ISBN: ");
                string isbn = ReadOption();
                Libro? libroPorIsbn = libroService.BuscarPorIsbn(isbn);
                Console.WriteLine(libroPorIsbn?.DetalleCompleto() ?? "No encontrado");
                break;
            case "2":
                Console.Write("Titulo: ");
                string titulo = ReadOption();
                ShowBooksSearchResults(libroService.BuscarPorTitulo(titulo));
                break;
            case "3":
                Console.Write("Autor: ");
                string autor = ReadOption();
                ShowBooksSearchResults(libroService.BuscarPorAutor(autor));
                break;
            default:
                Console.WriteLine("Opcion invalida.");
                break;
        }
    }

    static void SearchUser()
    {
        Console.WriteLine("=== BUSQUEDA DE USUARIOS EN SERVICES ===");
        Console.WriteLine("1. Buscar por documento");
        Console.WriteLine("2. Buscar por nombre");
        string op = ReadOption();

        switch (op)
        {
            case "1":
                Console.Write("Documento: ");
                string documento = ReadOption();
                Usuario? usuarioPorDocumento = usuarioService.BuscarPorDocumento(documento);
                Console.WriteLine(usuarioPorDocumento?.DetalleCompleto() ?? "No encontrado");
                break;
            case "2":
                Console.Write("Nombre: ");
                string nombre = ReadOption();
                ShowUsersSearchResults(usuarioService.BuscarPorNombre(nombre));
                break;
            default:
                Console.WriteLine("Opcion invalida.");
                break;
        }
    }

    static void ReportsMenu()
    {
        Console.WriteLine("=== REPORTES, ORDENACIONES Y KPIS ===");
        Console.WriteLine();

        Console.WriteLine("Libros ordenados por titulo:");
        foreach (Libro libro in libroService.OrdenarPorTitulo())
        {
            Console.WriteLine(libro.ResumenCorto());
        }

        Console.WriteLine();
        Console.WriteLine("Usuarios ordenados por nombre:");
        foreach (Usuario usuario in usuarioService.OrdenarPorNombre())
        {
            Console.WriteLine(usuario.ResumenCorto());
        }

        Console.WriteLine();
        Console.WriteLine("Prestamos ordenados por fecha limite:");
        foreach (Prestamo prestamo in prestamoService.OrdenarPorFechaLimite())
        {
            Console.WriteLine($"{prestamo.ResumenCorto()} | Limite: {prestamo.FechaLimiteDevolucion:dd/MM/yyyy}");
        }

        Console.WriteLine();
        Console.WriteLine("KPIs de libros:");
        Console.WriteLine($"Total de libros: {libroService.ObtenerTotalLibros()}");
        Console.WriteLine($"Libros disponibles: {libroService.ObtenerTotalDisponibles()}");
        Console.WriteLine($"Libros prestados: {libroService.ObtenerTotalPrestados()}");

        Console.WriteLine();
        Console.WriteLine("KPIs de usuarios:");
        Console.WriteLine($"Total de usuarios: {usuarioService.ObtenerTotalUsuarios()}");
        Console.WriteLine($"Usuarios activos: {usuarioService.ObtenerTotalActivos()}");
        Console.WriteLine($"Usuarios inactivos: {usuarioService.ObtenerTotalInactivos()}");

        Console.WriteLine();
        Console.WriteLine("KPIs de prestamos:");
        Console.WriteLine($"Total de prestamos: {prestamoService.ObtenerTotalPrestamos()}");
        Console.WriteLine($"Prestamos activos: {prestamoService.ObtenerTotalActivos()}");
        Console.WriteLine($"Prestamos vencidos: {prestamoService.ObtenerTotalVencidos()}");
        Console.WriteLine($"Prestamos devueltos: {prestamoService.ObtenerTotalDevueltos()}");
        Console.WriteLine($"Promedio de dias de prestamo: {prestamoService.ObtenerPromedioDiasPrestamo():F2}");

        Console.WriteLine();
        Console.WriteLine("Prestamos devueltos:");
        foreach (Prestamo prestamo in prestamoService.BuscarPorEstado(EstadoPrestamo.Devuelto))
        {
            Console.WriteLine($"Devuelto: {prestamo.ResumenCorto()}");
        }

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

    static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = ReadOption();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Ingrese un numero valido.");
        }
    }

    static int GetNextBookId()
    {
        List<Libro> libros = libroService.ObtenerTodos();
        return libros.Count == 0 ? 1 : libros.Max(libro => libro.Id) + 1;
    }

    static int GetNextUserId()
    {
        List<Usuario> usuarios = usuarioService.ObtenerTodos();
        return usuarios.Count == 0 ? 1 : usuarios.Max(usuario => usuario.Id) + 1;
    }

    static int GetNextLoanId()
    {
        List<Prestamo> prestamos = prestamoService.ObtenerTodos();
        return prestamos.Count == 0 ? 1 : prestamos.Max(prestamo => prestamo.Id) + 1;
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

    static Libro? GetBookByIdFromInput()
    {
        if (libroService.ObtenerTotalLibros() == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return null;
        }

        int id = ReadInt("Ingrese el ID del libro: ");
        Libro? libro = libroService.BuscarPorId(id);

        if (libro is null)
        {
            Console.WriteLine("Libro no encontrado.");
        }

        return libro;
    }

    static Usuario? GetUserByIdFromInput()
    {
        if (usuarioService.ObtenerTotalUsuarios() == 0)
        {
            Console.WriteLine("No hay usuarios registrados.");
            return null;
        }

        int id = ReadInt("Ingrese el ID del usuario: ");
        Usuario? usuario = usuarioService.BuscarPorId(id);

        if (usuario is null)
        {
            Console.WriteLine("Usuario no encontrado.");
        }

        return usuario;
    }

    static void ShowBooksSearchResults(List<Libro> libros)
    {
        if (libros.Count == 0)
        {
            Console.WriteLine("No se encontraron libros.");
            return;
        }

        foreach (Libro libro in libros)
        {
            Console.WriteLine(libro.ResumenCorto());
        }
    }

    static void ShowUsersSearchResults(List<Usuario> usuarios)
    {
        if (usuarios.Count == 0)
        {
            Console.WriteLine("No se encontraron usuarios.");
            return;
        }

        foreach (Usuario usuario in usuarios)
        {
            Console.WriteLine(usuario.ResumenCorto());
        }
    }
}
