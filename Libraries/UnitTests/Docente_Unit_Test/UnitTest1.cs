namespace Docente_Unit_Test;

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
    },new Docente
    {
    DocenteId = 2,
    Nombre = "NombreDocente2",
    ApellidoPaterno = "ApellidoPaternoDocente",
    ApellidoMaterno = "ApellidoMaternoDocente",
    Correo = "docente@example.com",
    PlantelId = 1, // Reemplaza con el ID de plantel adecuado
    UsuarioId = 1
    }
    };

    var mockDbSetDocentes = new Mock<DbSet<Docente>>();
    var queryableDocentes = docentes.AsQueryable();
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.Provider).Returns(queryableDocentes.Provider);
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.Expression).Returns(queryableDocentes.Expression);
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.ElementType).Returns(queryableDocentes.ElementType);
    mockDbSetDocentes.As<IQueryable<Docente>>().Setup(x => x.GetEnumerator()).Returns(() => queryableDocentes.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Docentes).Returns(mockDbSetDocentes.Object);
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });
    return mockDbContext;    

}

    [Fact]
    public void GetDocenteIDTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="1";
        int ACT=UI.GetDocenteIDTest(id,mockDbContext.Object);
        int EXP=1;
        Assert.Equal(ACT,EXP);
    }

     [Fact]
    public void GetDocenteIDTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="5";
        int ACT=UI.GetDocenteIDTest(id,mockDbContext.Object);
        int EXP=0;
        Assert.Equal(ACT,EXP);
    }

     [Fact]
    public void GetDocenteIDTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="asdas";
        int ACT=UI.GetDocenteIDTest(id,mockDbContext.Object);
        int EXP=0;
        Assert.Equal(ACT,EXP);
        /*bool ACT=UI.GetDocenteIDTest(id,mockDbContext.Object);
        Assert.False(ACT);*/
    }

    [Fact]
    public void DocenteValidationTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.DocenteValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

     [Fact]
    public void DocenteValidationTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=54;
        bool ACT=UI.DocenteValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

     [Fact]
    public void DocenteValidationTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=2;
        bool ACT=UI.DocenteValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }
}