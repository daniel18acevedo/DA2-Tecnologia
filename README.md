[Volver - Main](https://github.com/IngSoft-DA2/DA2-Tecnologia)

# Configuración Inicial del Repositorio – DA2

Esta guía te ayudará a dejar tu repositorio listo para trabajar de manera profesional en el curso, con buenas prácticas y herramientas automáticas desde el principio.

---

## 🚦 Paso 1: Configuración de Github Self Hosted Runners

Para que las acciones (Actions) funcionen correctamente y puedas compilar, testear y analizar tu código automáticamente, es fundamental instalar un runner propio.

Consulta la siguiente guía para hacerlo con Docker:  
👉 [Configuración de self-hosted runner](https://github.com/IngSoft-DA2/DA2-Tecnologia/blob/main/github-self-hosted-runner-docker.md)

---

## 📥 Paso 2: Subida de archivos y preparación del repositorio

1. **Clona tu repositorio obligatorio** recién creado.
2. Asegúrate de estar en la rama `main`.
3. Agrega todos los archivos descriptos en la sección [Archivos de configuración](#archivos-de-configuración) (respetando nombres, carpetas y extensiones).
4. **IMPORTANTE:**  
   - Respetar las carpetas, los nombres y extensiones de los archivos.
   - Agrega un archivo `.cs` (por ejemplo `Test.cs`). Esto hará que se ejecuten las actions al hacer commit.
   - En los dos workflows, reemplaza el placeholder de `solution-name` por el nombre del archivo de tu solución **con la extensión incluida**. A partir de .NET 10 `dotnet new sln` genera un archivo `.slnx` (por ejemplo `Test.slnx`); el formato `.sln` clásico también sigue siendo válido y los workflows funcionan igual con ambos.
5. Modifica el `README.md` y **agrega los badges para distinguir el estado de las ramas `main` y `develop`**:

   ```md
   ## Main

   ![Build - Test - Main](<<url de tu repo>>/actions/workflows/build-test.yml/badge.svg?branch=main&event=push)
   ![Code Analysis - Main](<<url de tu repo>>/actions/workflows/code-analysis.yml/badge.svg?branch=main&event=push)

   ## Develop

   ![Build - Test - Develop](<<url de tu repo>>/actions/workflows/build-test.yml/badge.svg?branch=develop&event=push)
   ![Code Analysis - Develop](<<url de tu repo>>/actions/workflows/code-analysis.yml/badge.svg?branch=develop&event=push)
   ```

   - Cambia `<<url de tu repo>>` por la URL real de tu repositorio.
   - Respeta el formato vertical para que las insignias queden una debajo de la otra.

6. Realiza el commit inicial con todos los archivos y el `Test.cs` de prueba, y sube los cambios.
7. Las Actions deberían ejecutarse y probablemente fallar (no hay código aún para probar, compilar o analizar).
8. Cuando terminen de ejecutarse las Actions, continúa con: [Configuración de branches](#configuración-de-branches).
9. Al finalizar toda la configuración, deberías tener:
   - Un único commit en `origin/main` y `origin/develop` debe estar generado a partir de este.
   - Dos actions ejecutadas y en estado failure.
   - Los badges en `main` en failure y los de `develop` sin estado (aún no hay commits).
10. Cuando termines el PR inicial, puedes eliminar `Test.cs`.

---

## ⚙️ Archivos de configuración

Estos archivos son esenciales para que tu repositorio siga las buenas prácticas y utilice las herramientas automáticas del curso.

### Archivos requeridos

- **[.gitignore](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/repo-configuration/.gitignore):** Ignora archivos no deseados en control de versiones.
- **[.editorconfig](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/repo-configuration/.editorconfig):** Reglas de estilo y clean code para C#.
- **[Directory.Build.props](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/repo-configuration/Directory.Build.props):** Referencias y versiones de paquetes para todos los proyectos.
- **[Directory.Build.targets](https://github.com/IngSoft-DA2/DA2-Tecnologia/blob/repo-configuration/Directory.Build.targets):** Agrega `coverlet.collector` (cobertura de código) a los proyectos de prueba, sin que tengas que declararlo en cada `.csproj`.
- **[pull_request_template.md](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/repo-configuration/pull_request_template.md):** Guía de información para los pull requests.
- **[.github/workflows/build-test.yml](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/repo-configuration/.github/workflows/build-test.yml):** Compilación y pruebas automáticas.
- **[.github/workflows/code-analysis.yml](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/repo-configuration/.github/workflows/code-analysis.yml):** Análisis estático de código.
  - Ambos archivos deben estar en `.github/workflows/` en la raíz.
- **[.gitattributes](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/repo-configuration/.gitattributes):** Configura atributos de archivos para Git.
- **[.runsettings](https://github.com/IngSoft-DA2/DA2-Tecnologia/blob/repo-configuration/.runsettings):** Configura cobertura de código para los tests.
- **[.config](https://github.com/IngSoft-DA2/DA2-Tecnologia/blob/repo-configuration/.config):** Configura una version estable de la herramienta dotnet ef para el proyecto.
- **[global.json](https://github.com/IngSoft-DA2/DA2-Tecnologia/blob/repo-configuration/global.json):** Configura una version estable del SDK de .NET para el proyecto.

---

## 🔀 Paso 3: Configuración de branches y ajustes generales

Configura las ramas principales y las opciones generales para proteger el código y evitar conflictos.

### 1. Rama por defecto: ¿Por qué debe ser `develop`?

La rama por defecto **debe ser `develop`** porque así aislamos el desarrollo activo (nuevas funcionalidades, correcciones, experimentos) de la rama principal de producción (`main`). Esto permite:

- Trabajar de forma segura sin afectar la versión productiva.
- Forzar que todo pase por un Pull Request y revisiones antes de llegar a producción.
- Pruebas, builds y code analysis automáticos se aplican primero en `develop`.
- Mejor organización y flujo de trabajo profesional (Git Flow básico).

**¿Cómo configurarlo?**
---

### 2. Configuración General

- Dirígete a la sección **General**.
- En la subsección **Default Branch**, selecciona `develop` como la rama por defecto.
- En la subsección **Features**, asegúrate de que **solo la opción "Projects" esté activa**. Desactiva Wiki, Issues, Discussions y demás opciones si no son necesarias para el curso.
---

### 3. Opciones de Pull Requests

Al configurar Pull Requests, verás diferentes acciones para hacer merge cuando un PR está listo:

- **Create a merge commit**: (recomendado y debe estar activo) Esta opción crea un commit de merge, manteniendo el historial completo de los cambios y es la más clara para trabajos colaborativos.
- **Squash merging**: Fusiona todos los commits del PR en un solo commit en la rama base. Útil para mantener un historial más limpio, pero puede ocultar detalles.
- **Rebase and merge**: Aplica los commits del PR de forma individual sobre la rama base, reescribiendo el historial. Puede ser útil para un historial lineal, pero es más avanzado.

> **Para el curso, deja **solo la opción "Create a merge commit"** activa y desactiva las otras. Es la más fácil de auditar para docentes y mantiene el contexto de los cambios.

Además, encontrarás otras opciones importantes:
- **Always suggest updating pull requests**: Recomienda siempre actualizar los PRs con la rama base antes de hacer merge.  
  _Sugerimos dejar esta opción **activa** para evitar conflictos y mantener la rama actualizada._
- **Allow auto-merge**: Permite que los PRs se fusionen automáticamente cuando cumplen los requisitos de revisión y CI.  
  _Activa esta opción para facilitar la integración continua._
- **Automatically delete head branches**: Elimina la rama automáticamente después de hacer merge.  
  _Activa esta opción para mantener tu repositorio limpio._

---

### 4. Protección de ramas

Crea reglas de protección para `main` y `develop`:
- Haz click en `Add classic branch protection rule`.
- Especifica el nombre: `main` o `develop`.
- Selecciona:
  - `Require a pull request before merging`
  - `Require status checks to pass before merging` y marca `Build`, `Test` y `Analysis`.
  - `Do not allow bypassing the above settings`
- Guarda la regla.
- Repite para ambas ramas principales.

---

¡Con esto tu repositorio estará listo y seguro para comenzar a trabajar de forma profesional!
