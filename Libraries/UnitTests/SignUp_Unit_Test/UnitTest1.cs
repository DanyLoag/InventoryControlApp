namespace SignUp_Unit_Test;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
public class UnitTest1{


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

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Usuarios).Returns(mockDbSet.Object);
    mockDbContext.Setup(x => x.Estudiantes).Returns(mockDbSetEstudiantes.Object);
    mockDbContext.Setup(x => x.Docentes).Returns(mockDbSetDocentes.Object);
    mockDbContext.Setup(x => x.Almacenistas).Returns(mockDbSetAlmacenistas.Object);

    // Configuración para admitir el método SaveChanges
    mockDbContext.Setup(x => x.SaveChanges()).Callback(() =>
    {
        // Puedes agregar lógica adicional aquí si es necesario
    });
    return mockDbContext;
}

    [Fact]
    public void Test_Succesful_User_Add()
    {
        var mockDbContext = ConfigurarMockDbContext();
          var nuevoEstudiante = new Estudiante
        {
            Nombre = "Danile",
            ApellidoPaterno = "ApellidoDanile",
            ApellidoMaterno = "ApellidoMaternoDanile",
            SemestreId = 1, // Reemplaza con el ID de semestre adecuado
            GrupoId = 1, // Reemplaza con el ID de grupo adecuado o deja como null si no hay grupo
            Adeudo = 0.0M, // Reemplaza con el adeudo adecuado
            Correo = "danile@example.com",
            PlantelId = 1, // Reemplaza con el ID de plantel adecuado
            UsuarioId = 1 // Reemplaza con el ID de usuario adecuado
            // Puedes establecer otros campos según sea necesario
        };
        var usuario=  new Usuario
    {
        Usuario1 = "Jared",
        Password = "Jared",
        Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{new Estudiante()},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    };

        bool ACT=CrudFuntions.AddStudentTest(nuevoEstudiante,usuario,mockDbContext.Object);
        Assert.True(ACT);
    }

    [Fact]
    
    public void Test_UnSuccesful_User_Add()
    {
        var mockDbContext = ConfigurarMockDbContext();
          var nuevoEstudiante = new Estudiante
        {
            Nombre = "Danile",
            ApellidoPaterno = "ApellidoDanile",
            ApellidoMaterno = "ApellidoMaternoDanile",
            SemestreId = 1, // Reemplaza con el ID de semestre adecuado
            GrupoId = 1, // Reemplaza con el ID de grupo adecuado o deja como null si no hay grupo
            Adeudo = 0.0M, // Reemplaza con el adeudo adecuado
            Correo = "eduardo@example.com",
            PlantelId = 1, // Reemplaza con el ID de plantel adecuado
            UsuarioId = 1 // Reemplaza con el ID de usuario adecuado
            // Puedes establecer otros campos según sea necesario
        };
        var usuario=  new Usuario
    {
        Usuario1 = "Jared",
        Password = "Jared",
        Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{new Estudiante()},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    };

        bool ACT=CrudFuntions.AddStudentTest(nuevoEstudiante,usuario,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    
    public void Test_UnSuccesful_Docente_Add()
    {
        var mockDbContext = ConfigurarMockDbContext();
          var nuevoDocente = new Docente
        
    {
    DocenteId = 1,
    Nombre = "NombreDocente",
    ApellidoPaterno = "ApellidoPaternoDocente",
    ApellidoMaterno = "ApellidoMaternoDocente",
    Correo = "docente@example.com",
    PlantelId = 1, // Reemplaza con el ID de plantel adecuado
    UsuarioId = 1
        };
        var usuario=  new Usuario
    {
        Usuario1 = "Jared",
        Password = "Jared",
        Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{new Estudiante()},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    };

        bool ACT=CrudFuntions.AddTeacherTest( nuevoDocente,usuario,mockDbContext.Object);
        Assert.False(ACT);
    }

    [Fact]
    public void Test_Succesful_Docente_Add(){

    {
        var mockDbContext = ConfigurarMockDbContext();
          var nuevoDocente = new Docente
        
    {
    DocenteId = 1,
    Nombre = "Sergio",
    ApellidoPaterno = "ApellidoPaternoDocente",
    ApellidoMaterno = "ApellidoMaternoDocente",
    Correo = "Sergio@example.com",
    PlantelId = 1, // Reemplaza con el ID de plantel adecuado
    UsuarioId = 1
        };
        var usuario=  new Usuario
    {
        Usuario1 = "Jared",
        Password = "Jared",
        Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{new Estudiante()},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    };

        bool ACT=CrudFuntions.AddTeacherTest( nuevoDocente,usuario,mockDbContext.Object);
        Assert.False(ACT);
    }}

       [Fact]
    
    public void Test_UnSuccesful_Almacenista_Add()
    {
        var mockDbContext = ConfigurarMockDbContext();
          var nuevoAlmacenista = new Almacenista
        
    {
     AlmacenistaId = 1,
    Nombre = "NombreAlmacenista",
    ApellidoPaterno = "ApellidoPaternoAlmacenista",
    ApellidoMaterno = "ApellidoMaternoAlmacenista",
    Correo = "almacenista@example.com",
    PlantelId = 1, // Reemplaza con el ID de plantel adecuado
    UsuarioId = 2
        };
        var usuario=  new Usuario
    {
        Usuario1 = "Jared",
        Password = "Jared",
        Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{new Estudiante()},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    };
    bool ACT=CrudFuntions.AddWarehouseManagerTest( nuevoAlmacenista,usuario,mockDbContext.Object);
    Assert.False(ACT);

}   
   [Fact] 
    public void Test_Succesful_Almacenista_Add()
    {
        var mockDbContext = ConfigurarMockDbContext();
          var nuevoAlmacenista = new Almacenista
        
    {
     AlmacenistaId = 0,
    Nombre = "Annel",
    ApellidoPaterno = "ApellidoPaternoAlmacenista",
    ApellidoMaterno = "ApellidoMaternoAlmacenista",
    Correo = "Annel@example.com",
    PlantelId = 1, // Reemplaza con el ID de plantel adecuado
    UsuarioId = 2
        };
        var usuario=  new Usuario
    {
        Usuario1 = "Jared",
        Password = "Jared",
        Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{new Estudiante()},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    };
    bool ACT=CrudFuntions.AddWarehouseManagerTest( nuevoAlmacenista,usuario,mockDbContext.Object);
    Assert.True(ACT);

}


}