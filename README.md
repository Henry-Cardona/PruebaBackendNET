# MarcasAutosAPI

Este proyecto es una API que maneja marcas de automóviles, construida con **.NET 8.0** y usando **PostgreSQL** como base de datos. Además, se incluyen pruebas unitarias ejecutadas con **XUnit** y **Moq**, y se integran mediante **Docker** y **Docker Compose**.

c Prerrequisitos

1. **Docker** y **Docker Compose** instalados.
   - [Instalar Docker](https://docs.docker.com/get-docker/)
   - [Instalar Docker Compose](https://docs.docker.com/compose/install/)

2. **.NET 8 SDK** instalado en caso de ejecutar localmente sin Docker.
   - [Instalar .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Estructura del Proyecto

- **MarcasAutosAPI**: Proyecto principal de la API.
- **MarcasAutosAPI.Tests**: Proyecto que contiene las pruebas unitarias.
- **Dockerfile**: Dockerfile para construir y ejecutar la API.
- **docker-compose.yml**: Configuración de Docker Compose para la API y PostgreSQL.

## Campos de Auditoría

La API incluye campos de auditoría en la tabla de marcas de automóviles para rastrear cuándo y quién creó o actualizó un registro. Estos campos son útiles para mantener un historial de cambios y controlar la integridad de los datos.

### Campos incluidos:

- `CreatedBy`: Indica el usuario que creó el registro.
- `CreatedAt`: Fecha y hora en que se creó el registro.
- `UpdatedBy`: Indica el usuario que actualizó el registro.
- `UpdatedAt`: Fecha y hora en que se actualizó el registro.

## Cómo ejecutar el proyecto con Docker
1. **Construir y levantar los contenedores**
    Ejecutar el siguiente comando para construir la imagen de la API y el contenedor de PostgreSQL, luego levantarlos, desde la terminal en la direccion de la carpeta raiz del proyecto API:

    docker-compose up --build

2. **Consultar la API**.
    - [Consultar documentacion] http://localhost:5000/swagger/index.html#/
    - [Consultar navegador] http://localhost:5000/api/MarcasAutos

3. **Detener y eliminar los contenedores**
    docker-compose down
4. Ver los logs

## Ejecutar Pruebas
    dotnet test /p:CollectCoverage=true /p:CoverletOutput=./coverage/ /p:CoverletOutputFormat=opencover
    desde la carpeta raiz del proyecto de pruebas

