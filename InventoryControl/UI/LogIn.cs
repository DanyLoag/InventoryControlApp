using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class UI
{
    
    /// <summary>
    /// Metodo de login , revisa si existe ese usuario en la bd y retorna su tipo y usuario encontrado
    /// </summary>
    /// <param name="usuarioEncontrado">Usuario que encontro segun las credenciales</param>
    /// <param name="userName">usuario</param>
    /// <param name="password">contraseña</param>
    /// <returns></returns>
    static public (Usuario? usuarioEncontrado,int typeOfUser) LogIn(string userName,string password)
    {
        using (Almacen db = new())
        {
            var user = db.Usuarios.FirstOrDefault(u => u.Usuario1 == userName && u.Password == password);//busca al usuario en la BD 
            if (user != null)//si no es nulo , osea que si encontro un usuario regresara al usuario encontrado junto con su tipo
            {
                Clear();
                WriteLine($"¡Bienvenido, {userName}!");
                WriteLine("");
                int TipoUsuario=0;
                if (user.Docentes.Any())
                {
                    TipoUsuario=1;
                }
                else if (user.Estudiantes.Any())
                {
                    TipoUsuario=2;
                }
                else if (user.Almacenistas.Any())
                {
                    TipoUsuario=3;
                }
                else if (user.Coordinadores.Any())
                {
                    TipoUsuario=4;
                }
                return (user,TipoUsuario);
            }
            else
            {
                Clear();
                WriteLine("Usuario o contraseña incorrectos. Inténtalo nuevamente.");
                return (user,0);
            }
        }
    }

    /// <summary>
    /// Metodo que segun el tipo de usuario encontrado desplegara el menu correspondiente 
    /// </summary>
    /// <param name="i">tipo de usuario 1,2,3,4</param> <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    static public void MenuSelected(Usuario currentUser, int typeOfUser){
        using(Almacen db = new()){
            switch(typeOfUser){
                case 1:
                Docente? docente = db.Docentes!.FirstOrDefault(r => r.UsuarioId == currentUser.UsuarioId);
                TeacherUI(docente);
                break;
                case 2:
                Estudiante? estudiante = db.Estudiantes!.FirstOrDefault(r => r.UsuarioId == currentUser.UsuarioId);
                StudentUI(estudiante);
                break;
                case 3:
                Almacenista? almacenista = db.Almacenistas!.FirstOrDefault(r => r.UsuarioId == currentUser.UsuarioId);
                InventoryManagerUI(almacenista);
                break;
                case 4:
                Coordinador? coordinador = db.Coordinadores!.FirstOrDefault(r => r.UsuarioId == currentUser.UsuarioId);
                AdministratorUI(coordinador);
                break;
            }
        }
    }

      public static (Usuario? usuarioEncontrado,int typeOfUser) LogInTest(string userName,string password,IAlmacenDataContext dataContext)
    {
        using (var db = dataContext)
        {
            var user = db.Usuarios.FirstOrDefault(u => u.Usuario1 == userName && u.Password == password);//busca al usuario en la BD 
            if (user != null)//si no es nulo , osea que si encontro un usuario regresara al usuario encontrado junto con su tipo
            {
                Clear();
                WriteLine($"¡Bienvenido, {userName}!");
                WriteLine("");
                int TipoUsuario=0;
                if (user.Docentes.Any())
                {
                    TipoUsuario=1;
                }
                else if (user.Estudiantes.Any())
                {
                    TipoUsuario=2;
                }
                else if (user.Almacenistas.Any())
                {
                    TipoUsuario=3;
                }
                else if (user.Coordinadores.Any())
                {
                    TipoUsuario=4;
                }
                return (user,TipoUsuario);
            }
            else
            {
                Clear();
                WriteLine("Usuario o contraseña incorrectos. Inténtalo nuevamente.");
                return (user,0);
            }
        }
    }
}
