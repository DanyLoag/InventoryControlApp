namespace Estudiante_Unit_Test;
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

     var mockDbSetEstudiantes = new Mock<DbSet<Estudiante>>();
    var queryableEstudiantes = estudiantes.AsQueryable();
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.Provider).Returns(queryableEstudiantes.Provider);
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.Expression).Returns(queryableEstudiantes.Expression);
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.ElementType).Returns(queryableEstudiantes.ElementType);
    mockDbSetEstudiantes.As<IQueryable<Estudiante>>().Setup(x => x.GetEnumerator()).Returns(() => queryableEstudiantes.GetEnumerator());

      var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Estudiantes).Returns(mockDbSetEstudiantes.Object);
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
        int EXP=UI.GetEstudianteIDTest(id,mockDbContext.Object);
        int ACT=1;
        Assert.Equal(EXP,ACT);

    }

    [Fact]
    public void GetMarcaIDTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="5";
        int EXP=UI.GetEstudianteIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void GetMarcaIDTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string id="";
        int EXP=UI.GetEstudianteIDTest(id,mockDbContext.Object);
        int ACT=0;
        Assert.Equal(EXP,ACT);
    }

    [Fact]
    public void MarcaValidationTest_True()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=1;
        bool ACT=UI.EstudianteValidationTest(id,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    public void MarcaValidationTest_False()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=0;
        bool ACT=UI.EstudianteValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    public void MarcaValidationTest_EXP()
    {
        var mockDbContext = ConfigurarMockDbContext();
        int id=-1;
        bool ACT=UI.EstudianteValidationTest(id,mockDbContext.Object);
        Assert.False(ACT);
    }
}