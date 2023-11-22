namespace Categoria_Unit_Test;
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
    var categorias = new List<Categoria>
    {
        new Categoria
        {
            CategoriaId = 1,
            Nombre = "Categoria1",
            Descripcion = "Descripción de Categoria1",
            Acceso = "A",
            Materiales = new List<Material>()
        },
        // ... otras categorias
    };

    var mockDbSetCategorias = new Mock<DbSet<Categoria>>();
    var queryableCategorias = categorias.AsQueryable();
    mockDbSetCategorias.As<IQueryable<Categoria>>().Setup(x => x.Provider).Returns(queryableCategorias.Provider);
    mockDbSetCategorias.As<IQueryable<Categoria>>().Setup(x => x.Expression).Returns(queryableCategorias.Expression);
    mockDbSetCategorias.As<IQueryable<Categoria>>().Setup(x => x.ElementType).Returns(queryableCategorias.ElementType);
    mockDbSetCategorias.As<IQueryable<Categoria>>().Setup(x => x.GetEnumerator()).Returns(() => queryableCategorias.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Categorias).Returns(mockDbSetCategorias.Object);

    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });

    return mockDbContext;
}
     [Fact]
    public void GetCategoriaIDTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="1";
        int EXP=UI.GetCategoriaIDTest(id,mockDbContext.Object);
        int ACT=1;
        Assert.Equal(EXP,ACT);

    }

    [Fact]
    public void GetCategoriaIDTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="5";
        int EXP=UI.GetCategoriaIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void GetCategoriaIDTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="";
        int EXP=UI.GetCategoriaIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void CategoriaValidationTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.CategoriaValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    public void CategoriaValidationTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=0;
        bool ACT=UI.CategoriaValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    public void CategoriaValidationTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=-1;
        bool ACT=UI.CategoriaValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
}