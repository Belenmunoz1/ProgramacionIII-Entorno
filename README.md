# ProgramacionIII-Entorno
# CapasApp

CapasApp es una API REST desarrollada en ASP.NET Core 8 para gestionar usuarios y entidades de un sistema deportivo/educativo, con autenticación JWT y acceso a base de datos MySQL.

## Descripción general

La solución está dividida en tres proyectos principales:

- `API`: contiene los controladores, configuración de autenticación, Swagger y punto de entrada de la aplicación.
- `DAO`: encapsula la lógica de acceso a datos y la interacción con Entity Framework.
- `Entities`: define las entidades del dominio y los modelos que se persisten en la base de datos.

La API incluye:

- Registro e inicio de sesión de usuarios
- Generación y validación de tokens JWT
- CRUD de jugadores
- CRUD de estudiantes
- Entidades relacionadas con cursos, equipos, actividades y usuarios
- Documentación interactiva con Swagger

## Tecnologías

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- JWT (Json Web Tokens)
- Swagger / OpenAPI

## Estructura del proyecto

```text
CapasApp.sln
API/
    Controllers/
    DTOs/
    Helpers/
    Services/
    Program.cs
    appsettings.Development.json
DAO/
    entity_framework/
    ...
Entities/
    ...
```

## Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- .NET SDK 8 o superior
- MySQL 8.x
- Visual Studio 2022 o VS Code
- (Opcional) MySQL Workbench o un cliente SQL para gestionar la base

## Configuración

1. Crear una base de datos MySQL llamada `capasapp`.
2. Abrir el archivo `API/appsettings.Development.json`.
3. Ajustar la cadena de conexión `DefaultConnection` para tu entorno local.

Ejemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost; port=3306; database=capasapp; Uid=root; pwd=tu_contraseña;"
}
```

También se configuran los valores para la autenticación JWT:

```json
"Jwt": {
  "Key": "clave-secreta-de-desarrollo-programacion-iii-cambiar-en-produccion",
  "Issuer": "CapasApp.API",
  "Audience": "CapasApp.Frontend",
  "ExpirationMinutes": 60
}
```

## Ejecutar la aplicación

Desde la raíz del proyecto:

```bash
dotnet restore
dotnet build CapasApp.sln
dotnet run --project API
```

La API queda disponible por defecto en:

- HTTP: `http://localhost:5006`
- HTTPS: `https://localhost:7250`

Swagger queda habilitado en modo desarrollo en:

- `http://localhost:5006/swagger`
- `https://localhost:7250/swagger`

## Endpoints principales

### Usuarios

- `POST /api/user/register` - Registro de usuario
- `POST /api/user/login` - Inicio de sesión
- `GET /api/user` - Listar usuarios (requiere JWT)
- `GET /api/user/{id}` - Obtener usuario por ID (requiere JWT)

### Jugadores

- `GET /api/player` - Listar jugadores
- `GET /api/player/{id}` - Obtener jugador por ID
- `POST /api/player` - Crear jugador
- `PUT /api/player/{id}` - Actualizar jugador
- `DELETE /api/player/{id}` - Eliminar jugador

### Estudiantes

- `GET /api/student` - Listar estudiantes
- `GET /api/student/{id}` - Obtener estudiante por ID
- `POST /api/student` - Crear estudiante
- `PUT /api/student/{id}` - Actualizar estudiante
- `DELETE /api/student/{id}` - Eliminar estudiante

## Seguridad

El sistema usa JWT para proteger endpoints sensibles. En Swagger se puede ingresar el token en el botón `Authorize` para probar rutas protegidas.

## Notas importantes

- La contraseña no se almacena en texto plano; se guarda como hash.
- La base de datos debe estar levantada antes de correr la API.
- Para producción, cambiar la clave JWT, la cadena de conexión y desactivar valores de desarrollo.

## Autor

Muñoz Belen y Basualdo Dario
