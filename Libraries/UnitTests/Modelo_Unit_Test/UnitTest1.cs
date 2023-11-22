namespace Modelo_Unit_Test;
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
    var modelos = new List<Modelo>
    {
        new Modelo
        {
            ModeloId = 1,
            Nombre = "Modelo1",
            Descripcion = "Descripción de Modelo1",
            Materiales = new List<Material>()
        },
        // ... otros modelos
    };

    var mockDbSetModelos = new Mock<DbSet<Modelo>>();
    var queryableModelos = modelos.AsQueryable();
    mockDbSetModelos.As<IQueryable<Modelo>>().Setup(x => x.Provider).Returns(queryableModelos.Provider);
    mockDbSetModelos.As<IQueryable<Modelo>>().Setup(x => x.Expression).Returns(queryableModelos.Expression);
    mockDbSetModelos.As<IQueryable<Modelo>>().Setup(x => x.ElementType).Returns(queryableModelos.ElementType);
    mockDbSetModelos.As<IQueryable<Modelo>>().Setup(x => x.GetEnumerator()).Returns(() => queryableModelos.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Modelos).Returns(mockDbSetModelos.Object);

    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });

    return mockDbContext;
}
    [Fact]
    public void GetModeloIDTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="1";
        int EXP=UI.GetModeloIDTest(id,mockDbContext.Object);
        int ACT=1;
        Assert.Equal(EXP,ACT);

    }

    [Fact]
    public void GetModeloIDTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="5";
        int EXP=UI.GetModeloIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void GetModeloIDTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="";
        int EXP=UI.GetModeloIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void ModeloValidationTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.ModeloValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    public void ModeloValidationTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=0;
        bool ACT=UI.ModeloValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    public void ModeloValidationTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=-1;
        bool ACT=UI.ModeloValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
}