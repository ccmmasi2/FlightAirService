Notas previas:
Instale nodejs desde la pagina: https://nodejs.org/en/download/current
	la versión de node instalada es: v18.13.0
	puede validar la version con el comando: node -v
Instale Angular: npm install -g @angular/cli desde la ventana de comandos de Visual Studio Code
	la versión de angular instalada es: 16.2.12
	puede validar la version con el comando: ng version

/*********************/

1 - descargue el código de el siguiente enlace https://github.com/ccmmasi2/FlightAirService.git

2- Cuando lo descargue encontrará dos carpetas iniciales: flightairserviceWeb proyecto en angular Angular CLI: 16.2.12 Node: v18.13.0 

Flight.AirService.Solution proyecto de visual studio 2022 NET Core 8

3 - Dentro de Flight.AirService.Solution ejecute el archivo Flight.AirService.Solution.sln El proyecto fue creado sobre visual studio 2022 NET Core 8

Valide la conexión a la bd en el archivo: appsettings.Development.json en Flight.AirService.Api/appsettings.json/appsettings.Development.json
    el servidor al que se esta conectando es CCMMASI: "Server=CCMMASI", cambie al nombre del servidor que necesite. La autentiación esta por windows

4 - Ejecute la aplicación

5 - La aplicación creará la base de datos automaticamente

6 - La ejecutar la aplicación de visual studio se espera que tenga SqlServer Instalado y en lo posible el Management Studio

7 - Esta predeterminado para crear la bd en "(el nombre que usted indice del servidor)" de SqlServer

8 - Si tiene una configuración diferente de Sql por favor valide la cadena de conexión en la api en el archivo appsettings.Development.json y busque AirServiceConectionDB

9 - Despliegue la aplicación sobre Visual Studio 2022, si todo se genera correctamente debería ver el swagger y la base de datos creada 

10 - Abra el proyecto flightairserviceWeb de angular abriendo ventana de comandos sobre la ruta y pulsando "code ."

11 - Una vez abierto abra una ventana de comandos

12 - Instale los node_modules con "npm install"

13 - Ejecute la aplicación con "ng serve -o" 