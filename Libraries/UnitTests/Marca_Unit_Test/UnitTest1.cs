namespace Marca_Unit_Test;
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
    var marcas = new List<Marca>
    {
        new Marca
        {
            MarcaId = 1,
            Nombre = "Marca1",
            Descripcion = "Descripción de Marca1",
            Materiales = new List<Material>()
        },
        // ... otras marcas
    };

    var mockDbSetMarcas = new Mock<DbSet<Marca>>();
    var queryableMarcas = marcas.AsQueryable();
    mockDbSetMarcas.As<IQueryable<Marca>>().Setup(x => x.Provider).Returns(queryableMarcas.Provider);
    mockDbSetMarcas.As<IQueryable<Marca>>().Setup(x => x.Expression).Returns(queryableMarcas.Expression);
    mockDbSetMarcas.As<IQueryable<Marca>>().Setup(x => x.ElementType).Returns(queryableMarcas.ElementType);
    mockDbSetMarcas.As<IQueryable<Marca>>().Setup(x => x.GetEnumerator()).Returns(() => queryableMarcas.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Marcas).Returns(mockDbSetMarcas.Object);

    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });

    return mockDbContext;
}
   [Fact]
    public void GetMarcaIDTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="1";
        int EXP=UI.GetMarcaIDTest(id,mockDbContext.Object);
        int ACT=1;
        Assert.Equal(EXP,ACT);

    }

    [Fact]
    public void GetMarcaIDTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="5";
        int EXP=UI.GetMarcaIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void GetMarcaIDTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="";
        int EXP=UI.GetMarcaIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void MarcaValidationTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.MarcaValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    public void MarcaValidationTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=0;
        bool ACT=UI.MarcaValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    public void MarcaValidationTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=-1;
        bool ACT=UI.MarcaValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
}