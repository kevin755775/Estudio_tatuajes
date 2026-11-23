# Estudio de Tatuajes

## Descripción

Aplicación web desarrollada para la administración y gestión de un estudio de tatuajes. Permite gestionar la información de las diferentes áreas del negocio mediante una interfaz web y servicios API.

## Tecnologías utilizadas

- C#
- .NET 10
- ASP.NET Core Razor Pages
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MSTest

## Funcionalidades

- Gestión de usuarios y roles.
- Administración de personas, clientes, empleados y tatuadores.
- Gestión de sedes, citas y sesiones.
- Administración de tatuajes, estilos y portafolios.
- Gestión de cotizaciones, facturas, pagos y descuentos.
- Administración de productos, implementos, proveedores y gastos.
- Registro y consulta de auditorías.
- Generación de reportes en PDF.

## Arquitectura del proyecto

La solución está organizada en diferentes proyectos:

- **Aplicaciones_libreria:** contiene las entidades, interfaces e implementaciones de la lógica de aplicación y acceso a datos.
- **servicio_EstudioTatuajes:** contiene los controladores de las APIs desarrolladas con ASP.NET Core.
- **front_EstudioTatuajes:** contiene la aplicación web desarrollada con ASP.NET Core Razor Pages.
- **presentacion_consola:** contiene la aplicación de presentación por consola.
- **pruebas_unitarias:** contiene las pruebas unitarias del proyecto.

## Base de datos

El proyecto utiliza SQL Server y Entity Framework Core para la conexión y manipulación de los datos.

La base de datos `estudio_tatuajes_db` contiene las tablas necesarias para gestionar la información del estudio.

## Pruebas unitarias

Se utiliza MSTest para realizar pruebas sobre las operaciones de inserción, consulta, actualización y eliminación de registros mediante Entity Framework Core.

## Reportes

La aplicación permite generar reportes en formatos PDF.

## Repositorio

El código fuente y los avances del proyecto se encuentran alojados en GitHub.
