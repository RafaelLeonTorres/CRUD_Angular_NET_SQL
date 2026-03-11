# CRUD Angular + .NET 9 + SQL Server

Aplicación de ejemplo que implementa un **CRUD de materiales** utilizando:

* Angular para el frontend
* .NET 9 con ASP.NET Core para la API
* SQL Server como base de datos

La aplicación permite **crear, consultar, actualizar y eliminar materiales** desde una interfaz web.

---

# Estructura del proyecto

```
CRUD_Angular_NET_SQL
│
├── AngularApp        → Aplicación frontend en Angular
│
├── MaterialAPI       → API REST desarrollada en .NET 9
│
├── .github           → Configuración de GitHub
│
└── README.md
```

---

# Requisitos

Antes de ejecutar el proyecto debes tener instalado:

* Node.js
* Angular CLI
* .NET 9 SDK
* SQL Server

---

# 1 Crear la Base de Datos

Crear la base de datos:

```sql
CREATE DATABASE BaseDePrueba
GO
```

Usar la base de datos:

```sql
USE [BaseDePrueba]
GO
```

Crear la tabla **Material**:

```sql
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Material](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
    [Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

---

# 2 Configurar conexión a la base de datos

En el proyecto **MaterialAPI**, configurar el archivo:

```
MaterialAPI/appsettings.json
```

Con la cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost; Database=BaseDePrueba;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

# 3 Ejecutar la API (.NET)

Ir al directorio del API:

```bash
cd MaterialAPI
```

Restaurar dependencias:

```bash
dotnet restore
```

Ejecutar el proyecto:

```bash
dotnet run
```

Swagger estará disponible en:

```
https://localhost:7006/swagger/index.html
```

---

# 4 Ejecutar la aplicación Angular

Ir al proyecto Angular:

```bash
cd AngularApp
```

Instalar dependencias:

```bash
npm install
```

Ejecutar la aplicación:

```bash
ng serve
```

La aplicación estará disponible en:

```
http://localhost:4200/
```

---

# Configuración del Endpoint en Angular

El servicio Angular que consume la API se encuentra en:

```
AngularApp/src/services/material.service.ts
```

El endpoint configurado es:

```typescript
private urlBase = 'https://localhost:7006/api/Materials';
```

Este endpoint conecta el frontend con la API desarrollada en .NET.

---

# Funcionalidades

La aplicación permite:

* Crear materiales
* Consultar materiales
* Actualizar materiales
* Eliminar materiales

Todo mediante una **API REST en .NET conectada a SQL Server**.

---

# Tecnologías utilizadas

* Angular
* TypeScript
* .NET 9
* ASP.NET Core
* SQL Server

---

# Autor

**Rafael León**
