using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class UI
{
    public static void Manage()
    {
        while (true)
        {
            WriteLine("1: Login ");
            WriteLine("2: Signup");
            WriteLine("3: Olvidé mi contraseña");
            string res = ReadLine()??"";
            Clear();
            switch (res)
            {
                case "1":
                WriteLine("Ingresa tu usuario:");
                string userName = ReadLine()??"";
                WriteLine("Ingresa tu contraseña:");
                string password = ReadLine()??"";
                IAlmacenDataContext? db = (IAlmacenDataContext)new Almacen();
                var user=LogIn(userName,password,db) ;
                MenuSelected(user.usuarioEncontrado,user.typeOfUser);
                break;
                case "2":
                    SignUpEstudent();
                    break;
                case "3":
                    ForgotPassword();
                    break;
                case "4":
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