namespace Create_Unit_Test;
using System.Collections.Generic;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public class UnitTest1

{
    private Mock<IAlmacenDataContext> ConfigurarMockDbContext()
{
    var usuarios = new List<Usuario>
    {
        new Usuario
        {
            Usuario1 = "Eduardo",
            Password = "Eduardo",
            Coordinadores = new List<Coordinador> { },
            Docentes = new List<Docente> { },
            Estudiantes = new List<Estudiante> { new Estudiante() },
            Almacenistas = new List<Almacenista> { },
        },
        // ... otros usuarios
    };
     var estudiantes = new List<Estudiante>
    {
        new Estudiante
        {
            EstudianteId = 1,
            Nombre = "Eduardo",
            ApellidoPaterno = "ApellidoEduardo",
            ApellidoMaterno = "ApellidoMaternoEduardo",
            SemestreId = 1, // Reemplaza con el ID de semestre adecuado
            GrupoId = 1, // Reemplaza con el ID de grupo adecuado o deja como null si no hay grupo
            Adeudo = 0.0M, // Reemplaza con el adeudo adecuado
            Correo = "eduardo@example.com",
            PlantelId = 1, // Reemplaza con el ID de plantel adecuado
            UsuarioId = 2 // Reemplaza con el ID de usuario adecuado
            // Puedes establecer otros campos según sea necesario
        }
    };

    var almacenistas = new List<Almacenista>{
    new Almacenista
    {
    AlmacenistaId = 1,
    Nombre = "NombreAlmacenista",
    ApellidoPaterno = "ApellidoPaternoAlmacenista",
    ApellidoMaterno = "ApellidoMaternoAlmacenista",
    Correo = "almacenista@example.com",
    PlantelId = 1, // Reemplaza con el ID de plantel adecuado
    UsuarioId = 2}
    };

    var docentes = new List<Docente>{
    new Docente
    {
    DocenteId = 1,
    Nombre = "NombreDocente",
    ApellidoPaterno = "ApellidoPaternoDocente",
    ApellidoMaterno = "ApellidoMaternoDocente",
    Correo = "docente@example.com",
    PlantelId = 1, // Reemplaza con el ID de plantel adecuado
    UsuarioId = 1
    }
    };

      var materiales = new List<Material>
    {
        new Material
        {
            MaterialId = 1,
            ModeloId = 1,
            Descripcion = "Material de prueba",
            YearEntrada = 2023,
            MarcaId = 1,
            CategoriaId = 1,
            PlantelId = 1,
            Serie = "ABC123",
            ValorHistorico = 100.00m,
            Condicion = "B",
        },new Material
        {
            MaterialId = 2
        }
        
    };

    var pedidos = new List<Pedido>
    {
        new Pedido
        {
            PedidoId = 0,
            Fecha = DateTime.Now,
            LaboratorioId = 1,
            HoraEntrega = DateTime.Now.AddHours(1),
            HoraDevolucion = DateTime.Now.AddHours(3),
            EstudianteId = 1,
            DocenteId = 1,
            CoordinadorId = 1,
            Estado = true,
        },
    };

    var mantenimientos = new List<Mantenimiento>
    {
        new Mantenimiento
        {
            MantenimientoId = 1,
            Nombre = "Mantenimiento 1",
            Descripcion = "Descripción del mantenimiento 1",
        },
    };

    List<DescPedido> descPedidosList = new List<DescPedido>
{
    new DescPedido
    {
        DescPedidoId =0,
        Cantidad = 10,
        PedidoId = 1,
        MaterialId = 1,
        
    }
};

    var mockDbSet = new Mock<DbSet<Usuario>>();
    var queryableUsuarios = usuarios.AsQueryable();
    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.Provider).Returns(queryableUsuarios.Provider);
    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.Expression).Returns(queryableUsuarios.Expression);
    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.ElementType).Returns(queryableUsuarios.ElementType);
    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.GetEnumerator()).Returns(() => queryableUsuarios.GetEnumerator());

    var mockDbSetEstudiantes = new Mock<DbSet<Estudiante>>();
    var queryableEstudiantes = estudiantes.AsQueryable();
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.Provider).Returns(queryableEstudiantes.Provider);
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.Expression).Returns(queryableEstudiantes.Expression);
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.ElementType).Returns(queryableEstudiantes.ElementType);
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.GetEnumerator()).Returns(() => queryableEstudiantes.GetEnumerator());


    var mockDbSetAlmacenistas = new Mock<DbSet<Almacenista>>();
    var queryableAlmacenistas = almacenistas.AsQueryable();
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.Provider).Returns(queryableAlmacenistas.Provider);
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.Expression).Returns(queryableAlmacenistas.Expression);
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.ElementType).Returns(queryableAlmacenistas.ElementType);
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.GetEnumerator()).Returns(() => queryableAlmacenistas.GetEnumerator());

    var mockDbSetDocentes = new Mock<DbSet<Docente>>();
    var queryableDocentes = docentes.AsQueryable();
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.Provider).Returns(queryableDocentes.Provider);
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.Expression).Returns(queryableDocentes.Expression);
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.ElementType).Returns(queryableDocentes.ElementType);
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.GetEnumerator()).Returns(() => queryableDocentes.GetEnumerator());

     var mockDbSetMateriales = new Mock<DbSet<Material>>();
    var queryableMateriales = materiales.AsQueryable();
    mockDbSetMateriales.As<IQueryable<Material>>().Setup(x => x.Provider).Returns(queryableMateriales.Provider);
    mockDbSetMateriales.As<IQueryable<Material>>().Setup(x => x.Expression).Returns(queryableMateriales.Expression);
    mockDbSetMateriales.As<IQueryable<Material>>().Setup(x => x.ElementType).Returns(queryableMateriales.ElementType);
    mockDbSetMateriales.As<IQueryable<Material>>().Setup(x => x.GetEnumerator()).Returns(() => queryableMateriales.GetEnumerator());

    var mockDbSetPedidos = new Mock<DbSet<Pedido>>();
    var queryablePedidos = pedidos.AsQueryable();
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.Provider).Returns(queryablePedidos.Provider);
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.Expression).Returns(queryablePedidos.Expression);
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.ElementType).Returns(queryablePedidos.ElementType);
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.GetEnumerator()).Returns(() => queryablePedidos.GetEnumerator());

    var mockDbSetMantenimientos = new Mock<DbSet<Mantenimiento>>();
    var queryableMantenimientos = mantenimientos.AsQueryable();
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.Provider).Returns(queryableMantenimientos.Provider);
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.Expression).Returns(queryableMantenimientos.Expression);
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.ElementType).Returns(queryableMantenimientos.ElementType);
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.GetEnumerator()).Returns(() => queryableMantenimientos.GetEnumerator());

   var mockDbSetDescPedidos = new Mock<DbSet<DescPedido>>();
var queryableDescPedidos = descPedidosList.AsQueryable();
mockDbSetDescPedidos.As<IQueryable<DescPedido>>().Setup(x => x.Provider).Returns(queryableDescPedidos.Provider);
mockDbSetDescPedidos.As<IQueryable<DescPedido>>().Setup(x => x.Expression).Returns(queryableDescPedidos.Expression);
mockDbSetDescPedidos.As<IQueryable<DescPedido>>().Setup(x => x.ElementType).Returns(queryableDescPedidos.ElementType);
mockDbSetDescPedidos.As<IQueryable<DescPedido>>().Setup(x => x.GetEnumerator()).Returns(() => queryableDescPedidos.GetEnumerator());
     

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Usuarios).Returns(mockDbSet.Object);
    mockDbContext.Setup(x => x.Estudiantes).Returns(mockDbSetEstudiantes.Object);
    mockDbContext.Setup(x => x.Docentes).Returns(mockDbSetDocentes.Object);
    mockDbContext.Setup(x => x.Almacenistas).Returns(mockDbSetAlmacenistas.Object);
    mockDbContext.Setup(x => x.Materiales).Returns(mockDbSetMateriales.Object);
    mockDbContext.Setup(x => x.Pedidos).Returns(mockDbSetPedidos.Object);
    mockDbContext.Setup(x => x.Mantenimientos).Returns(mockDbSetMantenimientos.Object);
    mockDbContext.Setup(x => x.DescPedidos).Returns(mockDbSetDescPedidos.Object);


    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });
    return mockDbContext;
}




    [Fact]
    public void Test_Instert_FailReporte()
    {
        var mockDbContext = ConfigurarMockDbContext();
        var descPedido = new DescPedido
{
    DescPedidoId = 1,
    Cantidad = 10,
    PedidoId = 1, // Deberías asignar el PedidoId correspondiente
    MaterialId = 1, // Deberías asignar el MaterialId correspondiente
};
var pedido = new Pedido
        {
            PedidoId = 0,
            Fecha = DateTime.Now,
            LaboratorioId = 1,
            HoraEntrega = DateTime.Now.AddHours(1),
            HoraDevolucion = DateTime.Now.AddHours(3),
            EstudianteId = 1,
            DocenteId = 1,
            CoordinadorId = 1,
            Estado = true,
        };

         bool ACT=CrudFuntions.AddPedidoTest(pedido,descPedido,mockDbContext.Object);
        Assert.False(ACT);
    }

   [Fact]
    public void Test_Instert_Reporte()
    {
        var mockDbContext = ConfigurarMockDbContext();
        var descPedido = new DescPedido
{
    DescPedidoId = 1,
    Cantidad = 10,
    PedidoId = 1, // Deberías asignar el PedidoId correspondiente
    MaterialId = 1, // Deberías asignar el MaterialId correspondiente
};
var pedido = new Pedido
        {
            PedidoId = 1,
            Fecha = DateTime.Now,
            LaboratorioId = 1,
            HoraEntrega = DateTime.Now.AddHours(1),
            HoraDevolucion = DateTime.Now.AddHours(3),
            EstudianteId = 1,
            DocenteId = 1,
            CoordinadorId = 1,
            Estado = true,
        };

bool ACT=CrudFuntions.AddPedidoTest(pedido,descPedido,mockDbContext.Object);
        Assert.True(ACT);
    }
}