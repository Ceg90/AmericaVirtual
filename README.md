# AmericaVirtual

Buend día, a quién corresponda. Espero que tanto el funcionamiento de la aplicación como el razonamiento utilizado sea acorde a sus estándares. Ahora paso a detallar el despliegue de la aplicación y las tecnologías que se utilizaron en dicha aplicación.


Despliegue de la aplicación:
    Primero deben elegir el ConnectionString que van a utilizar, ya sea DefaultConnection o AzureConnection (Siendo este último una conexión a la base de datos ya creada en Azure pero se necesita habilitar la ip que desean utilizar); por defecto, está colocado el primero en la clase de Statup. Luego pasamos a los scripts para armar la base de datos, y en ese caso hay que crear las tablas, ejecutar los stored procedures y llenar las tablas con datos.
    
    En cuanto a lo primero, hay 2 formas de hacerlo, una es a través de EntityFramework, ejecutando los comandos "Add-Migration FirstMigration" y "Update-Database" desde la consola del administrador de paquetes que se encuentra en (Herramientas -> Administrador de paquetes NuGet -> Consola del administrador de paquetes), y la otra, es corriendo los scripts para crear las tablas que se encuentran en el proyecto (AmericaVirtual -> Data -> DataBase -> Tables) siendo los scripts de User y Product los primeros en ser ejecutados.

    Luego se deben ejecutar en la base correspondiente los stored procedures (AmericaVirtual -> Data -> DataBase -> Stored Procedures); y por último, los datos pueden ser completados con el script que se encuentra en el proyecto (AmericaVirtual -> Data -> DataBase -> Script), o pueden ser ingresados mediante los endpoints para crear usuarios o productos que tiene la aplicación.

    Teniendo ya listo todo lo previamente aclarado, se puede proceder a ejecutar la aplicación y, por ende, utilizarla con normalidad.


Tecnologías utilizadas:

    A continuación, paso a listar las tecnologías utilizadas en dicha aplicación:
        - .NET Core
        - ASP.NET
        - Entity Framework Core
        - SQL Server
        - Swagger
        - Azure SQL