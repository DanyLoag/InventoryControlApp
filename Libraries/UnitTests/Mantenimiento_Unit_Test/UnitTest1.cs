namespace Mantenimiento_Unit_Test;
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
    var mantenimientos = new List<Mantenimiento>
    {
        new Mantenimiento
        {
            MantenimientoId = 1,
            Nombre = "Mantenimiento1",
            Descripcion = "Descripción de Mantenimiento1",
            ReporteMantenimientos = new List<ReporteMantenimiento>()
        },
        // ... otros mantenimientos
    };

    var mockDbSetMantenimientos = new Mock<DbSet<Mantenimiento>>();
    var queryableMantenimientos = mantenimientos.AsQueryable();
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.Provider).Returns(queryableMantenimientos.Provider);
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.Expression).Returns(queryableMantenimientos.Expression);
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.ElementType).Returns(queryableMantenimientos.ElementType);
    mockDbSetMantenimientos.As<IQueryable<Mantenimiento>>().Setup(x => x.GetEnumerator()).Returns(() => queryableMantenimientos.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Mantenimientos).Returns(mockDbSetMantenimientos.Object);

    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });

    return mockDbContext;
}
 [Fact]
    public void GetMantenimientoIDTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="1";
        int EXP=UI.GetMantenimientoIDTest(id,mockDbContext.Object);
        int ACT=1;
        Assert.Equal(EXP,ACT);

    }

    [Fact]
    public void GetMantenimientoIDTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="5";
        int EXP=UI.GetMantenimientoIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void GetMantenimientoIDTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="";
        int EXP=UI.GetMantenimientoIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void MantenimientoValidationTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.MantenimientoValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    public void MantenimientoValidationTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=0;
        bool ACT=UI.MantenimientoValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    public void MantenimientoValidationTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=-1;
        bool ACT=UI.MantenimientoValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
}