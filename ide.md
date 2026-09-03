[🔙 Volver - Main](https://github.com/IngSoft-DA2/DA2-Tecnologia/tree/main#preparaci%C3%B3n-del-ambiente-local)

# 🖥️ IDE (Entorno de Desarrollo Integrado)

Un **IDE** (*Integrated Development Environment*, por sus siglas en inglés) es un software que proporciona un entorno unificado para el desarrollo de aplicaciones. Los IDEs agrupan, en una sola interfaz, todas las herramientas necesarias para programar de forma eficiente y organizada.

## ✨ Características principales de un IDE

En un entorno IDE típicamente encontrarás:

- 🛠️ **Compilador:** Traduce el código fuente a un lenguaje que la máquina pueda entender.
- 📝 **Editor de texto:** Permite escribir y editar el código fuente de manera eficiente.
- 🐞 **Depurador (Debugger):** Facilita la identificación y corrección de errores en el código.
- ⚙️ **Herramientas de compilación automática:** Automatizan tareas como la compilación, ejecución de pruebas y generación de artefactos.

**Ventajas:**  
Centralizar todas estas herramientas en una única interfaz simplifica el flujo de trabajo, mejora la productividad y reduce la complejidad del proceso de desarrollo.

---

## 💡 IDE recomendado: Visual Studio

Microsoft recomienda utilizar **Visual Studio** como entorno de desarrollo. Al instalarlo, se configura automáticamente todo lo necesario para empezar a trabajar en proyectos de software, especialmente aquellos basados en tecnologías Microsoft.

### 🏆 Herramientas y ventajas de Visual Studio

Visual Studio ofrece numerosas herramientas adicionales, entre las que se destacan:

- 🐛 **Depurador avanzado:** Incluye *time travel debugging* mediante IntelliTrace.
- 🚦 **Monitoreo de rendimiento:** Permite detectar cuellos de botella y optimizar aplicaciones.
- 📊 **Pruebas de carga** y herramientas SQL integradas.
- 🧪 **Suite integral de pruebas** y análisis estático de código.
- 🔗 **Integración superior con sistemas de control de versiones:** Compatible con GIT, TFS y otros.
- 🧩 **Herramientas de arquitectura y modelado** preinstaladas.
- 📝 **Refactorización avanzada:** Mejor que la ofrecida por Visual Studio Code.
- 🌐 **Soporte para múltiples lenguajes y frameworks** desde la primera instalación.
- 📱 **Herramientas Xamarin** para desarrollo móvil multiplataforma.
- 📱 **Emuladores móviles** para pruebas.
- 🎁 ¡Y mucho más!

> **¿Cómo identificar un IDE?**  
> Una herramienta es considerada un **IDE** si, desde su instalación, integra todas las utilidades mencionadas anteriormente (editor, depurador, compilador, etc.) en una sola interfaz.

---

## 🛠️ Instalación de un IDE

Elige el entorno de desarrollo más adecuado para tu sistema operativo:

- 🪟 [Visual Studio Enterprise para Windows](https://github.com/IngSoft-DA2/DA2-Tecnologia/blob/main/ide-windows.md)
- 🍏 [Visual Studio Code para Mac o Windows](https://github.com/IngSoft-DA2/DA2-Tecnologia/blob/main/ide-mac.md)

---

## ⚙️ Instalación de .NET 10

Para trabajar con proyectos .NET, asegúrate de instalar el **.NET 10.0 SDK**. Este kit proporciona todas las herramientas necesarias para compilar y ejecutar aplicaciones .NET.

### 🔽 Pasos para instalar .NET 10.0 SDK

1. 🌐 Accede a la página oficial de descargas: [**.NET 10.0 SDK**](https://dotnet.microsoft.com/download/dotnet/10.0) y descarga la versión adecuada para tu sistema operativo.
2. 💾 Ejecuta el instalador descargado y sigue las instrucciones en pantalla.
3. 🧑‍💻 Comprueba la instalación:
   - Si usas **Visual Studio Enterprise** en Windows, deberías poder seleccionar la versión de .NET 10 al crear nuevos proyectos.
     - ⚠️ Para poder **targetear `net10.0`** necesitás **Visual Studio 2026 (18.0)** o superior. Visual Studio 2022 puede tener el SDK de .NET 10 instalado, pero solo te deja targetear hasta `net9.0`. Si al crear un proyecto no te aparece .NET 10 en el desplegable de framework, actualizá Visual Studio desde el **Visual Studio Installer**.
   - Si usas **Visual Studio Code**, abre una terminal y ejecuta el comando:
     ```
     dotnet --version
     ```
     Debería mostrar la versión recién instalada.
4. 🔄 Si la versión no aparece correctamente, reinicia tu equipo y vuelve a ejecutar el paso 3.

---

❓¿Dudas o problemas durante la instalación? Consulta las guías enlazadas arriba o comunícate con tu docente.
