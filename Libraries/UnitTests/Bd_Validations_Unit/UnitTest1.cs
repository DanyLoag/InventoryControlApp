namespace Delete_Unit_Test;
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
     var laboratorios = new List<Laboratorio>
    {
        new Laboratorio
        {
            LaboratorioId = 1,
            Nombre = "Laboratorio A",
            Descripcion = "Descripción del Laboratorio A",
            Pedidos = new List<Pedido>()
        },
        // ... otros laboratorios
    };

     var pedidos = new List<Pedido>
    {
        new Pedido
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
            DescPedidos = new List<DescPedido>(),
            Docente = new Docente(),
            Estudiante = new Estudiante(),
            Coordinador = new Coordinador(),
            Laboratorio = new Laboratorio(),
        },
        // ... otros pedidos
    };

    var mockDbSetLaboratorios = new Mock<DbSet<Laboratorio>>();
    var queryableLaboratorios = laboratorios.AsQueryable();
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.Provider).Returns(queryableLaboratorios.Provider);
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.Expression).Returns(queryableLaboratorios.Expression);
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.ElementType).Returns(queryableLaboratorios.ElementType);
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.GetEnumerator()).Returns(() => queryableLaboratorios.GetEnumerator());

    var mockDbSetPedidos = new Mock<DbSet<Pedido>>();
    var queryablePedidos = pedidos.AsQueryable();
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.Provider).Returns(queryablePedidos.Provider);
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.Expression).Returns(queryablePedidos.Expression);
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.ElementType).Returns(queryablePedidos.ElementType);
    mockDbSetPedidos.As<IQueryable<Pedido>>().Setup(x => x.GetEnumerator()).Returns(() => queryablePedidos.GetEnumerator());



    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Laboratorios).Returns(mockDbSetLaboratorios.Object);
    mockDbContext.Setup(x => x.Pedidos).Returns(mockDbSetPedidos.Object);

    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });

    return mockDbContext;
}
private Mock<IAlmacenDataContext> ConfigurarMockDbContextEmpty()
{
     var laboratorios = new List<Laboratorio>
    {
       
        // ... otros laboratorios
    };

    var mockDbSetLaboratorios = new Mock<DbSet<Laboratorio>>();
    var queryableLaboratorios = laboratorios.AsQueryable();
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.Provider).Returns(queryableLaboratorios.Provider);
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.Expression).Returns(queryableLaboratorios.Expression);
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.ElementType).Returns(queryableLaboratorios.ElementType);
    mockDbSetLaboratorios.As<IQueryable<Laboratorio>>().Setup(x => x.GetEnumerator()).Returns(() => queryableLaboratorios.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Laboratorios).Returns(mockDbSetLaboratorios.Object);

    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });

    return mockDbContext;
}
    [Fact]
    public void Lab_Validations_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.LabValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);

    }
        [Fact]
    public void Lab_Validations_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=0;
        bool ACT=UI.LabValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
     [Fact]
    public void Lab_Validations_EXP()
    {
        var mockDbContext = ConfigurarMockDbContextEmpty();
        int id=-1;
        bool ACT=UI.LabValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

   
    
    [Fact]
    public void Pedido_Id_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="1";
        int ACT=UI.GetPedidoIDTest(id,mockDbContext.Object);
        int EXP=1;
        Assert.Equal(ACT,EXP);
    }
    
    [Fact]
    public void Pedido_Id_EXP1()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string? id=null;
        int ACT=UI.GetPedidoIDTest(id,mockDbContext.Object);
        int EXP=0;
        Assert.Equal(ACT,EXP);
    }

    [Fact]
    public void Pedido_Id_Exp2()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="dasdaskndask";
        int ACT=UI.GetPedidoIDTest(id,mockDbContext.Object);
         int EXP=0;
        Assert.Equal(ACT,EXP);
    } 
    
    [Fact]
    public void Pedido_Id_0()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string? id="2";
        int ACT=UI.GetPedidoIDTest(id,mockDbContext.Object);
        int EXP=0;
        Assert.Equal(ACT,EXP);
    } 


    [Fact]
    public void Pedido_Validation_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.PedidoValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    public void Pedido_Validation_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=10;
        bool ACT=UI.PedidoValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
    [Fact]
    public void Pedido_Validation_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=-0;
        bool ACT=UI.PedidoValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

}