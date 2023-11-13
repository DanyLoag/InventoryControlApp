namespace Login_Unit_Test;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using AlmacenDataContext;
using AlmacenSQLiteEntities;
//using EntityFrameworkCore.Testing;

public class UnitTest1
{

    private Mock<IAlmacenDataContext> ConfigurarMockDbContext()
    {

        var usuarios = new List<Usuario>
{
     new Usuario
    {
        Usuario1 = "Jared",
        Password = "Jared",
        Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{new Estudiante()},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    },
     new Usuario
    {
        Usuario1 = "Aneel",
        Password = "Aneel",
       Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{},
        Almacenistas = new List<Almacenista>{new Almacenista()},
        // Puedes incluir un objeto Docente aquí
    },
     new Usuario
    {
        Usuario1 = "Andres",
        Password = "Andres",
        Coordinadores = new List<Coordinador> { new Coordinador() },
        Docentes = new List<Docente> {},
        Estudiantes = new List<Estudiante>{},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    },
     new Usuario
    {
        Usuario1 = "Angel",
        Password = "Angel",
       Coordinadores = new List<Coordinador> {},
        Docentes = new List<Docente> {new Docente()},
        Estudiantes = new List<Estudiante>{},
        Almacenistas = new List<Almacenista>{}, // Puedes incluir un objeto Docente aquí
    },
};
    var mockDbSet = new Mock<DbSet<Usuario>>();
    var queryableUsuarios = usuarios.AsQueryable();

    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.Provider).Returns(queryableUsuarios.Provider);
    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.Expression).Returns(queryableUsuarios.Expression);
    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.ElementType).Returns(queryableUsuarios.ElementType);
    mockDbSet.As<IQueryable<Usuario>>().Setup(x => x.GetEnumerator()).Returns(() => queryableUsuarios.GetEnumerator());

    var mockDbContext = new Mock<IAlmacenDataContext>();
    mockDbContext.Setup(x => x.Usuarios).Returns(mockDbSet.Object);

    return mockDbContext;
    }

    [Fact]
    public void NoPasswordSent()
    {
        var mockDbContext = ConfigurarMockDbContext();
        var (usuario, tipoUsuario) = UI.LogIn("Jared", "", mockDbContext.Object);
        int EXP = 0;
        Assert.Equal(tipoUsuario, EXP);
    }
    
    [Fact]
    public void NoUserSent()
    {
        // Given
        var mockDbContext = ConfigurarMockDbContext();
        string Password="";
        string user="Jared";
        // When
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(user,Password,mockDbContext.Object);
        int EXP=0;
        // Then
        Assert.Equal(MenuCorrespondiente,EXP);
        
    }
    
    [Fact]
    public void NoUserAndPasswordSent()
    {
        // Given
        var mockDbContext = ConfigurarMockDbContext();
        string Password="";
        string User="";
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(User,Password,mockDbContext.Object);
        int EXP=0;
        // Then
        Assert.Equal(MenuCorrespondiente,EXP);
    }
    [Fact]
    public void AlumnoLogin()
    {
        // Given
        var mockDbContext = ConfigurarMockDbContext();
        string Password="Jared";
        string User="Jared";
        // When
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(User,Password,mockDbContext.Object);
        int EXP=2;
        // Then
        Assert.Equal(MenuCorrespondiente,EXP);
    }
    
    [Fact]
    public void DocenteLogin()
    {
        // Given
        var mockDbContext = ConfigurarMockDbContext();
        string Password="Angel";
        string User="Angel";
        // When
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(User,Password,mockDbContext.Object);
        int EXP=1;
        // Then
        Assert.Equal(MenuCorrespondiente,EXP);
    }
    [Fact]
    public void AlmacenistaLogin()
    {
        // Given
        var mockDbContext = ConfigurarMockDbContext();
        string Password="Aneel";
        string User="Aneel";
        // When
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(User,Password,mockDbContext.Object);
        int EXP=3;
        // Then
        Assert.Equal(MenuCorrespondiente,EXP);
    }
    [Fact]
    public void CordinadorLogin()
    {
        // Given
        var mockDbContext = ConfigurarMockDbContext();
        string Password="Andres";
        string User="Andres";
        // When
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(User,Password,mockDbContext.Object);
        int EXP=4;
        // Then
        Assert.Equal(MenuCorrespondiente,EXP);
    }

    [Fact]
    public void TestUserIsNull()
    {
        // Given

        var mockDbContext = ConfigurarMockDbContext();
        string Password="";
        string User="";
        // When
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(User,Password,mockDbContext.Object);
        // Then
        Assert.Null(usuarioEncontrado);
    }
    [Fact]
    public void TestUserIsNotNull()
    {
        var mockDbContext = ConfigurarMockDbContext();
        string Password="Jared";
        string User="Jared";
        // When
        var (usuarioEncontrado, MenuCorrespondiente)=UI.LogIn(User,Password,mockDbContext.Object);
        // Then
        Assert.NotNull(usuarioEncontrado);
    }


}