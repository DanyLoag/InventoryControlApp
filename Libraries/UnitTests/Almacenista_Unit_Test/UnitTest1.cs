namespace Almacenista_Unit_Test;
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

     var mockDbSetAlmacenistas = new Mock<DbSet<Almacenista>>();
    var queryableAlmacenistas = almacenistas.AsQueryable();
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.Provider).Returns(queryableAlmacenistas.Provider);
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.Expression).Returns(queryableAlmacenistas.Expression);
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.ElementType).Returns(queryableAlmacenistas.ElementType);
    mockDbSetAlmacenistas.As<IQueryable<Almacenista>>().Setup(x => x.GetEnumerator()).Returns(() => queryableAlmacenistas.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Almacenistas).Returns(mockDbSetAlmacenistas.Object);

    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });
    return mockDbContext;
}

    [Fact]
    public void GetAlmacenistaIDTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string? id="1";
        int ACT=UI.GetAlmacenistaIDTest(id,mockDbContext.Object);
        int EXP=1;
        Assert.Equal(EXP,ACT);
    }
    [Fact]
    public void GetAlmacenistaIDTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string? id="0";
        int ACT=UI.GetAlmacenistaIDTest(id,mockDbContext.Object);
        int EXP=0;
        Assert.Equal(EXP,ACT);
    }
    [Fact]
    public void GetAlmacenistaIDTest_EXC()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string? id="dsfds";
        int ACT=UI.GetAlmacenistaIDTest(id,mockDbContext.Object);
        int EXP=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void AlmacenistaValidationTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.AlmacenistaValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    public void AlmacenistaValidationTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=12;
        bool ACT=UI.AlmacenistaValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    public void AlmacenistaValidationTest_EXC()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=-11;
        bool ACT=UI.AlmacenistaValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
    
}