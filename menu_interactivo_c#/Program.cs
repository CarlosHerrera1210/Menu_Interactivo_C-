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
}