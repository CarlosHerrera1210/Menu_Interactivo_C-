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
            Console.Clear();
            Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");

            string op = Console.ReadLine();

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
                    Console.ReadKey();
                    break;
            }
        }
    }
    

    static void ShowBooksMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE LIBROS ===");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

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

            Console.ReadKey();
        }
    }

    static void RegisterBook()
    {
        Console.WriteLine("Simulación: registrar libro.");
    }

    static void ListBooksMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR LIBROS ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Disponibles");
            Console.WriteLine("3. Prestados");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1": ListBooksAll(); break;
                case "2": ListBooksAvailable(); break;
                case "3": ListBooksBorrowed(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.ReadKey();
        }
    }

    static void ListBooksAll()
    {
        Console.WriteLine("Simulación: listar todos los libros.");
    }

    static void ListBooksAvailable()
    {
        Console.WriteLine("Simulación: listar libros disponibles.");
    }

    static void ListBooksBorrowed()
    {
        Console.WriteLine("Simulación: listar libros prestados.");
    }

    static void ViewBookDetail()
    {
        Console.WriteLine("Simulación: ver detalle de libro por ID/ISBN.");
    }

    static void UpdateBookMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR LIBRO ===");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1": EditBookTitle(); break;
                case "2": EditBookAuthor(); break;
                case "3": EditBookYearCategory(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.ReadKey();
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
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

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

            Console.ReadKey();
        }
    }

    static void RegisterUser()
    {
        Console.WriteLine("Simulación: registrar usuario.");
    }

    static void ListUsers()
    {
        Console.WriteLine("Simulación: listar usuarios.");
    }

    static void ViewUserDetail()
    {
        Console.WriteLine("Simulación: ver detalle del usuario.");
    }

    static void UpdateUserMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR USUARIO ===");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1": EditUserName(); break;
                case "2": EditUserContact(); break;
                case "3": ToggleUserActiveStatus(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.ReadKey();
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
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE PRÉSTAMOS ===");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

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

            Console.ReadKey();
        }
    }

    static void CreateLoan()
    {
        Console.WriteLine("Simulación: crear préstamo.");
        Console.WriteLine("Validaciones: usuario activo, libro disponible, límite de préstamos.");
    }

    static void ListLoansMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR PRÉSTAMOS ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1": ListLoansAll(); break;
                case "2": ListLoansActive(); break;
                case "3": ListLoansClosed(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.ReadKey();
        }
    }

    static void ListLoansAll()
    {
        Console.WriteLine("Simulación: listar todos los préstamos.");
    }

    static void ListLoansActive()
    {
        Console.WriteLine("Simulación: listar préstamos activos.");
    }

    static void ListLoansClosed()
    {
        Console.WriteLine("Simulación: listar préstamos cerrados.");
    }

    static void ViewLoanDetail()
    {
        Console.WriteLine("Simulación: ver detalle del préstamo.");
    }

    static void RegisterReturn()
    {
        Console.WriteLine("Simulación: registrar devolución del libro.");
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
            Console.Clear();
            Console.WriteLine("=== BÚSQUEDAS Y REPORTES ===");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1": SearchBook(); break;
                case "2": SearchUser(); break;
                case "3": ReportsMenu(); break;
                case "0": back = true; break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            Console.ReadKey();
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
}