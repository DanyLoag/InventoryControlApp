using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;


   public static partial class CrudFuntions
    {
             public static bool AddPedidoTest(Pedido pedido, DescPedido descPedido,IAlmacenDataContext dataContext){
        using (var db = dataContext){
           int? lastPedidoId = db.Pedidos.OrderByDescending(u => u.PedidoId).Select(u => u.PedidoId).FirstOrDefault();
            int pedidoID = lastPedidoId.HasValue ? lastPedidoId.Value + 1 : 1;
            int ID= pedido.PedidoId;
            pedido.PedidoId = pedidoID;
            descPedido.PedidoId = pedidoID;

            int? lastDesPedidoId = db.DescPedidos.OrderByDescending(u => u.DescPedidoId).Select(u => u.DescPedidoId).FirstOrDefault();
            int desPedidoID = lastDesPedidoId.HasValue ? lastDesPedidoId.Value + 1 : 1;
            descPedido.DescPedidoId = desPedidoID;
            WriteLine($"{pedido.PedidoId} | {descPedido.PedidoId}");
            
            var CheckPedidos = db.Pedidos.FirstOrDefault(r => r.PedidoId == ID);
            if (CheckPedidos != null)
            {
                WriteLine("Datos de docentes ya existentes");
                return false;
            }
            try
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                db.DescPedidos.Add(descPedido);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                WriteLine($"{e}");
                throw;
            }
        }
    }

     public static bool AddStudentTest(Estudiante estudiante, Usuario usuario,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            var CheckStudent = db.Estudiantes.FirstOrDefault(r => r.EstudianteId == estudiante.EstudianteId || r.Correo == estudiante.Correo);
            if (CheckStudent != null)
            {
                WriteLine("Datos de usuario ya existentes");
                return false;
            }
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int UserID = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            usuario.UsuarioId = UserID;
            estudiante.UsuarioId = UserID;
            Clear();
            db.Usuarios.Add(usuario);
            db.SaveChanges();
            db.Estudiantes.Add(estudiante);
            db.SaveChanges();
            return true;
        }
    }

    public static bool AddTeacherTest(Docente docente, Usuario usuario,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            var CheckStudent = db.Docentes.FirstOrDefault(r => r.DocenteId == docente.DocenteId || r.Correo == docente.Correo);
            if (CheckStudent != null)
            {
                WriteLine("Datos de docentes ya existentes");
                return false;
            }
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int UserID = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            int? lastTeacherId = db.Docentes.OrderByDescending(u => u.DocenteId).Select(u => u.DocenteId).FirstOrDefault();
            int TeacherID = lastTeacherId.HasValue ? lastTeacherId.Value + 1 : 1;
            usuario.UsuarioId = UserID;
            docente.UsuarioId = UserID;
            docente.DocenteId = TeacherID;
            Clear();
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            db.Docentes.Add(docente);
            db.SaveChanges();
            return true;

        }
    }

    public static bool AddWarehouseManagerTest(Almacenista almacenista, Usuario usuario,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            var CheckStudent = db.Almacenistas.FirstOrDefault(r => r.AlmacenistaId == almacenista.AlmacenistaId || r.Correo == almacenista.Correo);
            if (CheckStudent != null)
            {

                WriteLine("Datos de almacenista ya existentes");
                return false;

            }
            int? lastUserId = db.Usuarios.OrderByDescending(u => u.UsuarioId).Select(u => u.UsuarioId).FirstOrDefault();
            int UserID = lastUserId.HasValue ? lastUserId.Value + 1 : 1;
            int? lastWarehouseManagerId = db.Almacenistas.OrderByDescending(u => u.AlmacenistaId).Select(u => u.AlmacenistaId).FirstOrDefault();
            int WarehouseManagerID = lastWarehouseManagerId.HasValue ? lastWarehouseManagerId.Value + 1 : 1;
            usuario.UsuarioId = UserID;
            almacenista.UsuarioId = UserID;
            almacenista.AlmacenistaId = WarehouseManagerID;
            Clear();
            db.Usuarios.Add(usuario);
            db.SaveChanges();

            db.Almacenistas.Add(almacenista);
            db.SaveChanges();
            return true;
        }
    }

    public static int DeleteMaterialsTest(int materialId,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            
            Material? materiales = db.Materiales!.FirstOrDefault(m => m.MaterialId == materialId);
            if((materiales is null)){
                WriteLine("No se encontro un material para eliminar");
                return -1;
            }
            else{
                if(db.Materiales is null) return -2;
                db.Materiales.RemoveRange(materiales);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
public static int DeleteOrdersTest(int pedidoId,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            
            Pedido? pedidos = db.Pedidos!.FirstOrDefault(p => p.PedidoId == pedidoId);
            if((pedidos is null)){
                WriteLine("No se encontro un pedido para eliminar");
                return -1;
            }
            else{
                if(db.Pedidos is null) return -2;
                db.Pedidos.RemoveRange(pedidos);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }

public static int DeleteTeachersTest(int docenteId,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            
            Docente? docentes = db.Docentes!.FirstOrDefault(p => p.DocenteId == docenteId);
            if((docentes is null)){
                WriteLine("No se encontro un docente para eliminar");
                return -1;
            }
            else{
                if(db.Docentes is null) return -2;
                db.Docentes.RemoveRange(docentes);
            }

            int affected = db.SaveChanges();
            return affected;
        }
    }
 public static int DeleteInventoryManagerTest(int almacenistaId,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            
            Almacenista? almacenistas = db.Almacenistas!.FirstOrDefault(p => p.AlmacenistaId == almacenistaId);
            if((almacenistas is null)){
                WriteLine("No se encontro un almacenista para eliminar");
                return -1;
            }
            else{
                if (almacenistas is null)
                {
                    WriteLine("No se encontró un almacenista para eliminar");
                    return 0;
                }
                else
                {

                    // Eliminar el usuario asociado al almacenista
                    if (almacenistas.Usuario != null)
                    {
                        db.Usuarios.Remove(almacenistas.Usuario);
                    }

                    // Eliminar al almacenista
                    db.Almacenistas.Remove(almacenistas);
                }
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }

public static int DeleteStudentsTest(int estudianteId ,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            
            Estudiante? estudiantes = db.Estudiantes!.FirstOrDefault(p => p.EstudianteId == estudianteId);
            if((estudiantes is null)){
                WriteLine("No se encontro un estudiante para eliminar");
                return -1;
            }
            else{
                if(db.Estudiantes is null) return -2;
                db.Estudiantes.RemoveRange(estudiantes);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }

 public static int DeleteMantTest(int mantenimientoId,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            Mantenimiento? mantenimiento = db.Mantenimientos!.FirstOrDefault(p => p.MantenimientoId == mantenimientoId);
            if((mantenimiento is null)){
                WriteLine("No se encontro un mantenimiento para eliminar");
                return -1;
            }
            else{
                if(db.Mantenimientos is null) return -2;
                db.Mantenimientos.RemoveRange(mantenimiento);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    }
