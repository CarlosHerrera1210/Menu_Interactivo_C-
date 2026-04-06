using System;

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
        Console.WriteLine("Simulacion: registrar libro en el sistema.");
        Console.WriteLine("Aqui solo se muestra el flujo por consola, sin crear objetos reales.");
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

        Console.WriteLine("Simulacion: listar todos los libros.");
    }

    static void ListBooksAvailable()
    {
        Console.WriteLine("=== LIBROS DISPONIBLES ===");

        Console.WriteLine("Simulacion: listar libros disponibles.");
    }

    static void ListBooksBorrowed()
    {
        Console.WriteLine("=== LIBROS PRESTADOS ===");

        Console.WriteLine("Simulacion: listar libros prestados.");
    }

    static void ViewBookDetail()
    {
        Console.WriteLine("Simulacion: ver detalle de libro por ID o ISBN.");
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
        Console.WriteLine("Simulacion: eliminar libro.");
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
        Console.WriteLine("Simulacion: registrar usuario.");
        Console.WriteLine("El sistema solo muestra el flujo sin guardar datos reales.");
    }

    static void ListUsers()
    {
        Console.WriteLine("=== RESUMENES DE USUARIOS ===");

        Console.WriteLine("Simulacion: listar usuarios.");
    }

    static void ViewUserDetail()
    {
        Console.WriteLine("Simulacion: ver detalle de usuario.");
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
        Console.WriteLine("Simulacion: eliminar usuario.");
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
        Console.WriteLine("Simulacion: crear prestamo.");
        Console.WriteLine("Se validaria usuario activo y libro disponible, pero no se crea una coleccion real.");
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
        Console.WriteLine("Simulacion: listar todos los prestamos.");
    }

    static void ListLoansActive()
    {
        Console.WriteLine("Simulacion: listar prestamos activos.");
    }

    static void ListLoansClosed()
    {
        Console.WriteLine("Simulacion: listar prestamos cerrados.");
    }

    static void ViewLoanDetail()
    {
        Console.WriteLine("Simulacion: ver detalle del prestamo.");
    }

    static void RegisterReturn()
    {
        Console.WriteLine("Simulacion: registrar devolucion de un libro.");
    }

    static void DeleteLoan()
    {
        Console.WriteLine("Simulacion: eliminar prestamo.");
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
        Console.WriteLine("Simulacion: buscar libro por titulo, autor, ID o categoria.");
    }

    static void SearchUser()
    {
        Console.WriteLine("Simulacion: buscar usuario por nombre o ID.");
    }

    static void ReportsMenu()
    {
        Console.WriteLine("Simulacion: mostrar reportes.");
        Console.WriteLine("Reportes disponibles: por usuario, por libro, vencidos y resumen.");
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

}
