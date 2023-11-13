using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public static partial class CrudFuntions{
    public static int DeleteMaterials(int materialId,IAlmacenDataContext dataContext){
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
    
    public static int DeleteOrders(int pedidoId,IAlmacenDataContext dataContext){
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
    
    public static int DeleteTeachers(int docenteId,IAlmacenDataContext dataContext){
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
    
    public static int DeleteInventoryManager(int almacenistaId,IAlmacenDataContext dataContext){
        using (var db = dataContext){
            
            Almacenista? almacenistas = db.Almacenistas!.FirstOrDefault(p => p.AlmacenistaId == almacenistaId);
            if((almacenistas is null)){
                WriteLine("No se encontro un almacenista para eliminar");
                return -1;
            }
            else{
                if(db.Almacenistas is null) return 0;
                db.Almacenistas.RemoveRange(almacenistas);
            }
            int affected = db.SaveChanges();
            return affected;
        }
    }
    
    public static int DeleteStudents(int estudianteId ,IAlmacenDataContext dataContext){
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

    public static int DeleteMant(int mantenimientoId,IAlmacenDataContext dataContext){
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