# Apuntes de Backend con .NET

.NET es un marco de trabajo que nos ira indicando la estructura que debe tener nuestro proyecto para conecta, para nombrar etc. Para dejar en claro, _.NET Framework_ es privado, en cambio, _.NET Core_ es la parte Open Source y multiplataforma que luego pasó a llamarse solo .NET.

### Datos

- `{ get; set; }` permiten leer y modificar la variable
- `Func` funciones que retornar datos
- `Action` funciones que no devuelven nada

El **controllers** (base del endpoint) es una clase que herada de la clase controller de .NET, el cual recibe una petición (request) del usuario y le devuelve una respuesta ya sea un HTML, JSON o cualquier datos necesario, y a su vez también puede recibir datos junto a esa petición.

El **services** es donde va la lógica de negocio y la validación de los datos los cuales son devueltos al controller.

**Tipos de inyección de dependencias**

- **Singleton**: siempre es el mismo objeto, único en todo el sistema
- **Scoped**: el objeto es distinto en cada solicitud
- **Transient**: es cuando el objeto es de una misma clase, pero cambia según la solicitud

![Tipos de inyección](public/image.png)

Cuando se mando un JSON en el body, .NET lo toma de manera automática y lo serializa para usar esa informacion en nuestro código.

_**Créditos:**_

👉 [https://www.udemy.com/course/aprende-programacion-backend-en-c-net/](https://www.udemy.com/course/aprende-programacion-backend-en-c-net/)
