# API Productos - Clean Architecture

API REST desarrollada en .NET 8 para la gestión de productos e inventario.

## Tecnologías

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQLite
- Swagger
- Docker

---

##  Arquitectura

El proyecto implementa Clean Architecture separando responsabilidades en capas:


src/
 Domain
 Application
 Infrastructure
 WebAPI


---

##  Funcionalidades

### Productos
- Crear producto
- Consultar producto
- Actualizar producto
- Eliminar producto
- Listado paginado

### Stock
- Incrementar inventario
- Descontar inventario
- Validación de stock negativo

---

##  Ejecutar localmente

### Restaurar dependencias


dotnet restore


### Ejecutar API


dotnet run --project src/WebAPI


---

##  Swagger


http://localhost:5000/swagger


---

##  Endpoints principales

### Obtener productos


GET /api/productos?page=1&pageSize=10


### Crear producto


POST /api/productos


### Incrementar stock


POST /api/productos/{id}/increment-stock


### Descontar stock


POST /api/productos/{id}/decrement-stock


---

## 🌐 Deploy público

Pendiente