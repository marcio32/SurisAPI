# 🏥 Suris API - Sistema de Reservas  

**Suris API** es una API REST desarrollada con **.NET 8** que permite gestionar reservas de servicios.  
Incluye autenticación mediante **JWT**, persistencia con **Entity Framework Core y SQL Server**,  
y documentación con **Swagger**.

## 📌 Características  
✅ Autenticación con **JWT**.  
✅ Gestión de **usuarios, servicios y reservas**.  
✅ **Validaciones** para evitar reservas duplicadas.  
✅ Documentación con **Swagger**.  
✅ Desarrollado con **.NET 8 y Entity Framework Core**.  

## 📌 Requisitos previos  

Antes de ejecutar el proyecto, asegúrate de tener instalado:  

- [✔ .NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  
- [✔ SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  
- [✔ Visual Studio 2022](https://visualstudio.microsoft.com/)
- [✔ Postman](https://www.postman.com/) (opcional para probar la API)  

---

## 📌 Configuración del entorno  

**Clona el repositorio**  
    
    git clone https://github.com/tu-usuario/suris-api.git

**Configura la cadena de conexión en appsettings.json**  
Abre el archivo appsettings.json y actualiza la cadena de conexión con los datos de tu base de datos SQL Server:

    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=Reservations;User Id=tu_usuario;Password=tu_contraseña;TrustServerCertificate=True;"
    }

**Instalación y configuración** 
Aplica las migracion con 

    update-database

## 📌 Ejecutar la API
Una vez ejecutada la API, abre tu navegador y accede a:

    http://localhost:7163/swagger

## 📌 Autenticación y uso
Para acceder a los endpoints protegidos, primero debes iniciar sesión y obtener un token JWT.
Iniciar sesión

    Endpoint: /api/auth/login
    Método: POST
    Cuerpo:
    {
      "username": "marcioabriola@gmail.com",
      "password": "1234"
    }
    
    Respuesta:
    {
      "token": "eyJhbGciOiJIUzI1..."
    }

Cómo usar el token:
Debes enviarlo en cada petición protegida usando el encabezado:

    Authorization: Bearer {token}

## 📌 Endpoints disponibles
Autenticación (/api/auth)

    POST /api/auth/login → Iniciar sesión y obtener un token JWT.

Servicios (/api/services)

    GET /api/services → Obtener la lista de servicios. ( Requiere token)

Reservas (/api/reservations)

    GET /api/reservations → Obtener todas las reservas. ( Requiere token)

    POST /api/reservations → Crear una nueva reserva. ( Requiere token)

        Cuerpo:
        {
          "clientName": "Juan Pérez",
          "dateReservation": "2024-04-01T14:30:00",
          "serviceId": 1
        }

        Errores posibles:

        "Ya existe una reserva para ese día y horario."

        "El cliente ya tiene una reserva en ese día."

## 📌 Tecnologías utilizadas

    .NET 8 - Framework principal.
    Entity Framework Core - ORM para acceso a datos.
    SQL Server - Base de datos.
    JWT - Autenticación segura.
    Swagger - Documentación de la API.
