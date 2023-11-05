using InventoryControl;
public static partial class UI
{
    public static void Manage()
    {
        while (true)
        {
            Console.WriteLine("1: Login ");
            Console.WriteLine("2: Signup");
            string res = Console.ReadLine()??"";
            Console.Clear();
            switch (res)
            {
                case "1":
                Console.WriteLine("Ingresa tu usuario:");
                string userName = Console.ReadLine()??"";
                Console.WriteLine("Ingresa tu contraseña:");
                string password = Console.ReadLine()??"";
                var (usuarioEncontrado, MenuCorrespondiente) = LogIn(userName,password) ;
                MenuSelected(MenuCorrespondiente);
                break;
                case "2":
                    SignUp();
                    break;
                case "3":
                return;
                default:
                    Console.WriteLine("Opción no válida, intentelo de nuevo");
                    break;
            }
        }
    }

    static UI()
    {
    }
}
