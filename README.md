# ZiurSoftware - Prueba Técnica Blazor

Aplicación Blazor Web App que consume la API REST de Ziur Software para mostrar el listado de documentos/empleados.

## Objetivo

Desarrollar una aplicación en Blazor Web App que se conecte y consuma la API REST provista:

```
https://mainserver.ziursoftware.com/Ziur.API/basedatos_01/ZiurServiceRest.svc/api/DocumentosFillsCombos
```

La autenticación se realiza mediante Bearer Token.

## Tecnologías

- .NET 10 (Blazor Web App)
- Render mode: **WebAssembly** (sin prerender)
- `HttpClientFactory` + `DelegatingHandler` para inyección automática del token
- C#

## Estructura del proyecto

```
ZiurSoftware/
├── ZiurSoftware/                  # Proyecto Server
├── ZiurSoftware.Client/           # Proyecto Client (WebAssembly)
│   ├── Handlers/
│   │   └── AuthTokenHandler.cs    # Middleware que agrega el Bearer Token a cada request
│   ├── Models/
│   │   └── Empleado.cs            # Modelo de datos de la API
│   ├── Services/
│   │   ├── IEmpleadoService.cs
│   │   └── EmpleadoService.cs     # Servicio que consume el endpoint DocumentosFillsCombos
│   ├── Pages/
│   │   └── Empleados.razor        # Página de consulta
│   └── Program.cs                 # Configuración de HttpClient, handler y servicios
└── ZiurSoftware.slnx
```

## Arquitectura de la solución

- **Autenticación centralizada**: el Bearer Token se inyecta automáticamente en cada request mediante un `DelegatingHandler` (`AuthTokenHandler`), evitando repetir la lógica de headers en cada componente.
- **Separación de responsabilidades**: los componentes Razor no conocen `HttpClient` directamente — dependen de `IEmpleadoService`, que encapsula toda la comunicación con la API externa.
- **Render mode WebAssembly sin prerender**: se configuró `@rendermode @(new InteractiveWebAssemblyRenderMode(prerender: false))` en las páginas que consumen la API, para evitar que el servidor intente resolver servicios registrados solo en el Client durante el prerenderizado.

## Cómo ejecutar el proyecto

```bash
cd src/ZiurSoftware
dotnet restore
dotnet run --project ZiurSoftware
```

Navegar a `https://localhost:XXXX/empleados` (verificar el puerto asignado en la consola al ejecutar).

## Configuración del token

El token se define en `Program.cs` del proyecto Client. Para un entorno de producción, se recomienda moverlo a `appsettings.json` o a un proveedor de configuración seguro (Azure Key Vault, variables de entorno), en vez de mantenerlo hardcodeado.

## Notas

- Se utilizó asistencia de herramientas de IA (Claude) durante el desarrollo para depuración de errores de configuración de `HttpClient`/`BaseAddress`, resolución de conflictos de render mode en Blazor Web App, y buenas prácticas de estructuración de servicios.
