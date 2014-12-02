ConigQuery
==========

Programa para realizar consultas en Conig y clasificar la informacion resultante.
---------------------------------------------------------------------------------

Conig es un aplicativo de gestion online para el programa Conectar Igualdad. Mediante este aplicativo puede administrarse la provision de netbooks para un colegio, realizar ABMs para alumnos, asignar equipos, hacer reclamos de servicio tecnico y consultas en la base de datos.

ConigQuery pretende automatizar la tarea de consulta y clasificacion de los datos existentes en la base del aplicativo Conig con el fin de clarificar la situacion de cada alumno respecto del programa. Esto se vuelve necesario ya que la base de datos esta desactualizada desde el año 2010, por lo que no figuran efectivamente todas las devoluciones de equipo y pases de equipos entre colegios.

Para realizar esta tarea, ConigQuery parte de una tabla que posee todos los numeros de serie de las maquinas entregadas a alumnos desde 2010. De esta tabla se desestiman los datos personales ya que en el transcurso de los años podrian haber cambiado (esto es, una maquina podria haber pasado de un beneficiario a otro). Luego, ingresando el numero de serie en Conig, consulta la identidad del beneficiario asociado al equipo. Del resultado de la busqueda levanta su numero de CUIL con el que realiza una busqueda en la matricula escolar, la cual ya no se encuentra en el aplicativo sino en un archivo excel provisto por el colegio. En la matricula escolar figura el estado del alumno (regular, libre o pase de colegio). Dependiendo del estado del alumno ConigQuery enviara sus datos a la tabla "Irregular" (libre o pase) o "Regular". También pueden darse otros dos casos: En caso de que el aplicativo no devuelva un cuil el numero de serie se guardara en la tabla "NoEnConig". Por ultimo, en caso de que el CUIL levantado desde el aplicativo no se encuentre en la matricula, el numero de serie y el CUIL se guardaran en la tabla "NoEnMatricula".

En un desarrollo posterior deberán agregarse los algoritmos necesarios para aconsejar un tratamiento puntual para cada caso de estado. Para ello se cruzaran datos provenientes de otras consultas posibles mediante el aplicativo y se realizaran otro tipo de comparaciones (Por Ej.: Comparacion de Nombres)
