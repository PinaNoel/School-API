
# 🎓 School_API 

API Rest para la gestion escolar que permite la autenticación de usuarios con diferentes roles (Alumnos, Docentes y Administradores), gestión de materias, calificaciones y periodos semestrales.


## 🚀 Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Unit of Work + Repository Pattern


## 📂 Estructura del proyecto

- `Core`: Entidades del dominio, interfaces.
- `Application`: Casos de uso, DTOs, servicios, validaciones.
- `Infrastructure`: Implementaciones de repositorios, EF, acceso a datos.
- `API`: Capa de presentación: controladores, middlewares.

```text
├── school-api/
│ ├── Properties/
│ ├── SQL/
│ │ |── Int.sql
│ |── Core/
│ |── Application/
│ |── Infrastructure/
│ |── API/
│ |── appsettings.Development.json
│ |── appsettings.json
| └── school_api.csproj
├── .gitignore
├── README.md
├── school_web_api.sln
```

## 🔐 Autenticación

- Autenticación basada en Json Web Token (JWT) con validacion de credenciales y control de acceso mediante roles de usuario.
- Hashing de contraseñas usando el algoritmo Argon2id


## 🗃️ Diagrama de Base de Datos

![Data Base diagram](school_api/SQL/Diagram.png)


## 🛠️ Instalar paquetes y ejecutar el proyecto

Instalar paquetes nuget via terminal 

```bash
dotnet restore
```

Ejecutar el proyecto

```bash
dotnet run --project school_api/school_api.csproj
```