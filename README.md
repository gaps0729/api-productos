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

##  Ejecución local

### 1. Clonar repositorio


git clone https://github.com/gaps0729/api-productos.git



### 2. Entrar al proyecto


cd api-productos-clean


---

#  Ejecutar con Docker

## Requisitos

- Docker Desktop instalado

## Levantar contenedores


docker compose up --build


La API quedará disponible en:


http://localhost:8080/swagger


---

#  Ejecutar manualmente con .NET

## Requisitos

- .NET 8 SDK instalado

## Restaurar paquetes


dotnet restore


## Ejecutar proyecto


dotnet run --project src/WebAPI


La API quedará disponible en:


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

## Deploy público

https://api-productos-6ncp.onrender.com/swagger/