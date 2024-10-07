# Grades Managment System BackEnd
Back End created using .Net8, Entity Framework and Swagger
## Endpoints
>[GET](https://github.com/Alejoxd70/GradeManagmentSystem-BackEnd?tab=readme-ov-file#get-apientidad)</br>
[POST](https://github.com/Alejoxd70/GradeManagmentSystem-BackEnd?tab=readme-ov-file#post-apientidad)</br>
[PUT](https://github.com/Alejoxd70/GradeManagmentSystem-BackEnd?tab=readme-ov-file#put-apientidadid)</br>
[DELETE](https://github.com/Alejoxd70/GradeManagmentSystem-BackEnd?tab=readme-ov-file#delete-apiassignmentsid)</br>
[LOGIN](https://github.com/Alejoxd70/GradeManagmentSystem-BackEnd?tab=readme-ov-file#post-apiuserslogin-login)</br>
[PERMISOS](https://github.com/Alejoxd70/GradeManagmentSystem-BackEnd?tab=readme-ov-file#get-apipermissionusertypesvalidate-permisos)</br>

### GET /api/[Entidad]
**Descripción:** Obtiene una lista de todos los registros existentes en la base de datos del sistema. </br>
**Respuesta esperada:** Una lista en formato JSON con los campos específicos de cada entidad (Ejemplo para usuario seria ID, Nombre, Correo, etc.) </br>
**Código de estado:** 200 (OK) si es exitoso, 404 (Not Found) si no se encuentra el recurso. 

### POST /api/[Entidad]
**Descripción:** Crea un nuevo registro en la entidad almacenandolo en la base de datos del sistema. </br>
**Cuerpo de la solicitud:** JSON con los detalles del nuevo registro.  </br>
**Respuesta esperada:** El recurso creado. </br>
**Código de estado:** 201 (Created) si es exitoso, 400 (Bad Request) si hay algún error en los datos enviados. </br>

### PUT /api/[Entidad]/[id]
**Descripción:** Actualiza uno o más campos de un registro existente.  </br>
**Cuerpo de la solicitud:** ID del registro a actualizar, JSON con los detalles que se quieren actualizar del registro. </br>
**Respuesta esperada:** El recurso actualizado. </br>
**Código de estado:** 200 (OK) si es exitoso, 404 (Not Found) si el recurso no existe, 400 (Bad Request) si los datos enviados no son válidos.   </br>

### DELETE /api/assignments/{id}
**Descripción:** Elimina un registro específico.  </br>
**Cuerpo de la solicitud:** ID del registro a eliminar </br>
**Respuesta esperada:** Un mensaje de éxito o confirmación. </br>
**Código de estado:** 200 (OK) si es exitoso, 404 (Not Found) si el recurso no existe.   </br>

### POST /api/Users/login (LOGIN)
**Descripción:** El endpoint de login se utiliza para autenticar a un usuario en el sistema. El proceso de login verifica que las credenciales proporcionadas, un email y una contraseña sean correctas. </br>
**Cuerpo de la solicitud:** JSON con los credenciales de email y password. </br>
**Respuesta esperada:** Si las credenciales son correctas, el sitema dejará ingresar el usuraio al sistema.  </br>
**Código de estado:** 401 Unauthorized: Cuando las credenciales son incorrectas </br>

### GET /api/PermissionUserTypes/validate (PERMISOS)
**Descripción:** Los permisos en el sistema definen qué acciones puede realizar un usuario en función de su rol o tipo de usuario. En este caso los roles que se usaran son: administrador, profesor y estudiante. Cada uno de estos roles tiene permisos específicos para acceder a ciertos endpoints o realizar acciones particulares (crear, actualizar, eliminar datos, etc.).  </br>
**Cuerpo de la solicitud:** JSON con el tipo de usuario y permisos relacionados</br>
**Respuesta esperada:** Permitir al usuario hacer ciertas acciones. </br>
**Código de estado:** 403 Forbidden Cuando el usuario no puede hacer determinada acción.</br>
