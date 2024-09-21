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

**Models**

- **Modelo**: representación de una entidad en la base de datos
- **DTO (Data Transfers Object)**: objeto para la transferencia de datos, el cual tiene como ventaja indicar cuantos datos son los que viajan entre cada capa.

Cuando se mando un JSON en el body, .NET lo toma de manera automática y lo serializa para usar esa informacion en nuestro código.

La diferencia entre un **List** y un **IEnumerable**, es que List es una clase que contiene muchos métodos para la manipulación de datos, en cambio, IEnumerable (que es solo de lectura) solo tiene lo necesario para iterar datos haciendo que sea más eficiente que List.

_**Créditos:**_

👉 [https://www.udemy.com/course/aprende-programacion-backend-en-c-net/](https://www.udemy.com/course/aprende-programacion-backend-en-c-net/)
