using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
using System.Text.RegularExpressions;

    public static partial class UI
    {
        
public static int GetMaterialIDTest(int categoryId,IAlmacenDataContext dataContext){
    using (var db = dataContext){
        try{
            Material material = db.Materiales.Where(m => m.Condicion == "1").First(m => m.CategoriaId == categoryId);
            material.Condicion = "2";
            db.SaveChanges();
            if (material is null){
                Program.Fail("Ese material no esta disponible");
                return -1;
            }
            else
            {
                return material.MaterialId;
            }
        }
        catch (Exception e)
        {
            WriteLine($"{e.Message}");
            Program.Fail("Ese material no exite");
            return 0;
            throw;
        }
    }
}

public static bool LabValidationTest(int realLab,IAlmacenDataContext dataContext)
{
    bool validLab;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Laboratorio> queryableLab = db.Laboratorios.Where(l => l.LaboratorioId == realLab);
            if (queryableLab is null || (!queryableLab.Any()))
            {
                Program.Fail("Ese laboratorio no exite");
                validLab = false;
            }
            else
            {
                validLab = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validLab = false;
        throw;
    }
    return validLab;
} 

public static int GetMaterialForIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Material material = db.Materiales.First(l => l.MaterialId == int.Parse(id));
            if (material is null)
            {
                Program.Fail("Ese material no exite");
                return 0;
            }
            else
            {
                return material.MaterialId;
            }
        }
        catch (Exception e)
        {
            Program.Fail("Ese material no exite");
            return 0;

        }
    }
}

public static bool MaterialValidationTest(int realMaterial,IAlmacenDataContext dataContext)
{
    bool validMaterial;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Material> queryableMaterial = db.Materiales.Where(l => l.MaterialId == realMaterial);
            if (queryableMaterial is null || (!queryableMaterial.Any()))
            {
                Program.Fail("Ese material no exite");
                validMaterial = false;
            }
            else
            {
                validMaterial = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validMaterial = false;
        throw;
    }
    return validMaterial;
}

public static int GetPedidoIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Pedido? pedido = db.Pedidos.First(l => l.PedidoId == int.Parse(id));
            if (pedido is null)
            {
                Program.Fail("Ese pedido no exite");
                return 0;
            }
            else
            {
                return pedido.PedidoId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese pedido no exite");
            return 0;
            throw;
        }
    }
}

public static bool PedidoValidationTest(int realPedido,IAlmacenDataContext dataContext)
{
    bool validPedido;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Pedido> queryablePedido = db.Pedidos.Where(l => l.PedidoId == realPedido);
            if (queryablePedido is null || (!queryablePedido.Any()))
            {
                Program.Fail("Ese pedido no exite");
                validPedido = false;
            }
            else
            {
                validPedido = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validPedido = false;
        throw;
    }
    return validPedido;
}

public static int GetDocenteIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Docente docente = db.Docentes.First(d => d.DocenteId == int.Parse(id));
            if (docente is null)
            {
                Program.Fail("Ese docente no exite");
                return 0;
            }
            else
            {
                return docente.DocenteId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese docente no exite");
            return 0;
            throw;
        }
    }
}

//funcion que verifica el docente ingresado por el usuario
public static bool DocenteValidationTest(int realDocente,IAlmacenDataContext dataContext)
{
    bool validDocente;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Docente> queryableDocente = db.Docentes.Where(d => d.DocenteId == realDocente);
            if (queryableDocente is null || (!queryableDocente.Any()))
            {
                Program.Fail("Ese docente no exite");
                validDocente = false;
            }
            else
            {
                validDocente = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validDocente = false;
        throw;
    }
    return validDocente;
}



public static int GetAlmacenistaIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Almacenista almacenista = db.Almacenistas.First(d => d.AlmacenistaId == int.Parse(id));
            if (almacenista is null)
            {
                Program.Fail("Ese almacenista no exite");
                return 0;
            }
            else
            {
                return almacenista.AlmacenistaId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese almacenista no exite");
            return 0;
            throw;
        }
    }
}

//funcion que valida el almacenista ingresado por el usuario
public static bool AlmacenistaValidationTest(int realAlmacenista,IAlmacenDataContext dataContext)
{
    bool validAlmacenista;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Almacenista> queryableAlmacenista = db.Almacenistas.Where(d => d.AlmacenistaId == realAlmacenista);
            if (queryableAlmacenista is null || (!queryableAlmacenista.Any()))
            {
                Program.Fail("Ese almacenista no exite");
                validAlmacenista = false;
            }
            else
            {
                validAlmacenista = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validAlmacenista = false;
        throw;
    }
    return validAlmacenista;
}

public static int GetEstudianteIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Estudiante estudiante = db.Estudiantes.First(d => d.EstudianteId == int.Parse(id));
            if (estudiante is null)
            {
                Program.Fail("Ese estudiante no exite");
                return 0;
            }
            else
            {
                return estudiante.EstudianteId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese estudiante no exite");
            return 0;
            throw;
        }
    }
}

//funcion que valida el estudiante seleccionado por el usuario
public static bool EstudianteValidationTest(int realEstudiante,IAlmacenDataContext dataContext)
{
    bool validEstudiante;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Estudiante> queryableEstudiante = db.Estudiantes.Where(d => d.EstudianteId == realEstudiante);
            if (queryableEstudiante is null || (!queryableEstudiante.Any()))
            {
                Program.Fail("Ese estudiante no exite");
                validEstudiante = false;
            }
            else
            {
                validEstudiante = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validEstudiante = false;
        throw;
    }
    return validEstudiante;
}

public static int GetMarcaIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Marca marca = db.Marcas.First(d => d.MarcaId == int.Parse(id));
            if (marca is null)
            {
                Program.Fail("Esa marca no exite");
                return 0;
            }
            else
            {
                return marca.MarcaId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese marca no exite");
            return 0;
            throw;
        }
    }
}

//funcion que valida la marca ingresada por el usuario
public static bool MarcaValidationTest(int realMarca,IAlmacenDataContext dataContext)
{
    bool validMarca;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Marca> queryableMarca = db.Marcas.Where(d => d.MarcaId == realMarca);
            if (queryableMarca is null || (!queryableMarca.Any()))
            {
                Program.Fail("Ese marca no exite");
                validMarca = false;
            }
            else
            {
                validMarca = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validMarca = false;
        throw;
    }
    return validMarca;
}

public static int GetModeloIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Modelo modelo = db.Modelos.First(d => d.ModeloId == int.Parse(id));
            if (modelo is null)
            {
                Program.Fail("Esa modelo no exite");
                return 0;
            }
            else
            {
                return modelo.ModeloId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese modelo no exite");
            return 0;
            throw;
        }
    }
}
//funcion que valida que el modelo ingresado sea correcto
public static bool ModeloValidationTest(int realModelo,IAlmacenDataContext dataContext)
{
    bool validModelo;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Modelo> queryableModelo = db.Modelos.Where(d => d.ModeloId == realModelo);
            if (queryableModelo is null || (!queryableModelo.Any()))
            {
                Program.Fail("Ese modelo no exite");
                validModelo = false;
            }
            else
            {
                validModelo = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validModelo = false;
        throw;
    }
    return validModelo;
}

public static int GetCategoriaIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Categoria categoria = db.Categorias.First(d => d.CategoriaId == int.Parse(id));
            if (categoria is null)
            {
                Program.Fail("Esa categoria no exite");
                return 0;
            }
            else
            {
                return categoria.CategoriaId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese categoria no exite");
            return 0;
            throw;
        }
    }
}
//funcion que valida la categoria ingresada por el usuario
public static bool CategoriaValidationTest(int realCategoria,IAlmacenDataContext dataContext)
{
    bool validCategoria;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Categoria> queryableCategoria = db.Categorias.Where(d => d.CategoriaId == realCategoria);
            if (queryableCategoria is null || (!queryableCategoria.Any()))
            {
                Program.Fail("Ese categoria no exite");
                validCategoria = false;
            }
            else
            {
                validCategoria = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validCategoria = false;
        throw;
    }
    return validCategoria;
}


public static int GetMantenimientoIDTest(string? id,IAlmacenDataContext dataContext)
{
    using (var db = dataContext)
    {
        try
        {
            Mantenimiento mantenimiento = db.Mantenimientos.First(d => d.MantenimientoId == int.Parse(id));
            if (mantenimiento is null)
            {
                Program.Fail("Esa mantenimiento no exite");
                return 0;
            }
            else
            {
                return mantenimiento.MantenimientoId;
            }
        }
        catch (System.Exception)
        {
            Program.Fail("Ese mantenimiento no exite");
            return 0;
            throw;
        }
    }
}

//validacion para revisar que el mantenimiento que ingreso el usuario es correcto
public static bool MantenimientoValidationTest(int realMantenimiento,IAlmacenDataContext dataContext)
{
    bool validMantenimiento;
    try
    {
        using (var db = dataContext)
        {
            IQueryable<Mantenimiento> queryableMantenimiento = db.Mantenimientos.Where(d => d.MantenimientoId == realMantenimiento);
            if (queryableMantenimiento is null || (!queryableMantenimiento.Any()))
            {
                Program.Fail("Ese mantenimiento no exite");
                validMantenimiento = false;
            }
            else
            {
                validMantenimiento = true;
            }
        }
    }
    catch (System.Exception)
    {
        Program.Fail("Introduce un numero por favor.");
        validMantenimiento = false;
        throw;
    }
    return validMantenimiento;
}
    }
