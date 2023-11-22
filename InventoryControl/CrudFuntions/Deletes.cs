using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions{
    public static int DeleteMaterials(){
        using(Almacen db = new()){
            string? input;
            int id;
            do{
                WriteLine("Ingresa el modelo a eliminar:");
                input = ReadLine();
                id = UI.GetModeloID(input);
            } while (UI.ModeloValidation(id) == false);
            Material? materiales = db.Materiales!.FirstOrDefault(m => m.MaterialId == id);
            if((materiales is null)){
                WriteLine("No se encontro un material para eliminar");
            }
            else{
                if(db.Materiales is null) return 0;
                db.Materiales.RemoveRange(materiales);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteOrders(){
        using(Almacen db = new()){
            string? input;
            int pedidoId;
            do{
                WriteLine("Que pedido quieres eliminar?");
                input = ReadLine();
                pedidoId = UI.GetPedidoID(input);
            } while (UI.PedidoValidation(pedidoId) == false);
            DescPedido? descPedido = db.DescPedidos.FirstOrDefault(p => p.PedidoId == pedidoId);
            Pedido? pedidos = db.Pedidos!.FirstOrDefault(p => p.PedidoId == pedidoId);
            if((pedidos is null)){
                WriteLine("No se encontro un pedido para eliminar");
                return 0;
            }
            else{
                if(db.DescPedidos is null) return 0;
                db.DescPedidos.RemoveRange(descPedido);
                if(db.Pedidos is null) return 0;
                db.Pedidos.RemoveRange(pedidos);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteTeachers(){
        using(Almacen db = new()){
            string input;
            int id;

            do
            {
                WriteLine("De cuál maestro quieres eliminar su información?");
                input = ReadLine();
                id = UI.GetDocenteID(input);
            } while (UI.DocenteValidation(id) == false);

            Docente docente = db.Docentes!.FirstOrDefault(p => p.DocenteId == id);

            if (docente is null)
            {
                WriteLine("No se encontró un docente para eliminar");
                return 0;
            }
            else
            {

                // Obtener los pedidos y desc_pedidos asociados al docente
                IQueryable<Pedido> pedidos = db.Pedidos!.Where(p => p.DocenteId == id);
                IQueryable<DescPedido> descPedidos = db.DescPedidos!.Where(dp => pedidos.Any(p => p.PedidoId == dp.PedidoId));

                // Eliminar los desc_pedidos asociados
                db.DescPedidos.RemoveRange(descPedidos);

                // Eliminar los pedidos asociados
                db.Pedidos.RemoveRange(pedidos);

                // Eliminar el usuario asociado al docente
                if (docente.Usuario != null)
                {
                    db.Usuarios.Remove(docente.Usuario);
                }

                // Eliminar al docente
                db.Docentes.Remove(docente);
            }

            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteInventoryManager(){
        using(Almacen db = new()){
            string? input;
            int id;
            do{
                WriteLine("De cual almacenista quieres eliminar su informacion?");
                input = ReadLine();
                id = UI.GetAlmacenistaID(input);
            } while (UI.AlmacenistaValidation(id) == false);
            Almacenista? almacenistas = db.Almacenistas!.FirstOrDefault(p => p.AlmacenistaId == id);
            if((almacenistas is null)){
                WriteLine("No se encontro un almacenista para eliminar");
                return 0;
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
    
    public static int DeleteStudents(){
        using(Almacen db = new()){
            string? input;
            int id;
            do{
                WriteLine("De cual estudiante quieres eliminar su informacion?");
                input = ReadLine();
                id = UI.GetEstudianteID(input);
            } while (UI.EstudianteValidation(id) == false);
            Estudiante? estudiantes = db.Estudiantes!.FirstOrDefault(p => p.EstudianteId == id);
            if (estudiantes is null)
            {
                WriteLine("No se encontró un docente para eliminar");
                return 0;
            }
            else
            {

                // Obtener los pedidos y desc_pedidos asociados al estudiante
                IQueryable<Pedido> pedidos = db.Pedidos!.Where(p => p.EstudianteId == id);
                IQueryable<DescPedido> descPedidos = db.DescPedidos!.Where(dp => pedidos.Any(p => p.PedidoId == dp.PedidoId));

                // Eliminar los desc_pedidos asociados
                db.DescPedidos.RemoveRange(descPedidos);

                // Eliminar los pedidos asociados
                db.Pedidos.RemoveRange(pedidos);

                // Eliminar el usuario asociado al estudiante
                if (estudiantes.Usuario != null)
                {
                    db.Usuarios.Remove(estudiantes.Usuario);
                }

                // Eliminar al estudiante
                db.Estudiantes.Remove(estudiantes);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }

    public static int DeleteMant(){
        using(Almacen db = new()){
            string? input;
            int id;
            do{
                WriteLine("De cual mantenimiento quieres eliminar su informacion?");
                input = ReadLine();
                id = UI.GetEstudianteID(input);
            } while (UI.EstudianteValidation(id) == false);
            Mantenimiento? mantenimiento = db.Mantenimientos!.FirstOrDefault(p => p.MantenimientoId == id);
            if((mantenimiento is null)){
                WriteLine("No se encontro un mantenimiento para eliminar");
                return 0;
            }
            else{
                if(db.Mantenimientos is null) return 0;
                db.Mantenimientos.RemoveRange(mantenimiento);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }



}