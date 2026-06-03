# Especificación del sistema

## Nombre del sistema

DataFlow Manager

## Descripción

DataFlow Manager es un sistema de escritorio desarrollado en C# con Windows Forms, orientado a la gestión de tareas e incidencias dentro de una empresa de desarrollo de software.

## Problema

La empresa presenta dificultades para organizar el trabajo del equipo, controlar errores, asignar responsables y dar seguimiento a las incidencias del proyecto.

## Objetivo general

Desarrollar un sistema que permita registrar, consultar, editar, eliminar y controlar incidencias asignadas a trabajadores de un equipo de software.

## Actores del sistema

- Administrador del proyecto
- Desarrollador
- Analista QA
- DevOps
- Project Manager

## Requisitos funcionales

### RF01 - Registrar incidencia

El sistema debe permitir registrar una incidencia con ID, título, descripción, responsable, prioridad, estado, fecha de creación y fecha límite.

### RF02 - Asignar responsable

El sistema debe permitir seleccionar un trabajador responsable de la incidencia.

### RF03 - Editar incidencia

El sistema debe permitir modificar los datos de una incidencia previamente registrada.

### RF04 - Eliminar incidencia

El sistema debe permitir eliminar una incidencia seleccionada.

### RF05 - Buscar incidencia

El sistema debe permitir buscar incidencias por título, descripción, responsable, prioridad o estado.

### RF06 - Mostrar incidencias

El sistema debe mostrar las incidencias registradas en un DataGridView.

### RF07 - Dashboard

El sistema debe mostrar un resumen de incidencias por estado y prioridad.

## Requisitos no funcionales

### RNF01 - Usabilidad

La interfaz debe ser sencilla y permitir al usuario registrar y consultar datos de forma clara.

### RNF02 - Mantenibilidad

El proyecto debe estar organizado en carpetas: Entidades, Controlador y Formularios.

### RNF03 - Control de versiones

El código debe estar alojado en GitHub y gestionado mediante ramas.

### RNF04 - Automatización

El repositorio debe incluir un pipeline de GitHub Actions para validar la compilación del proyecto.

## Actualización de documentación

Se documenta que el sistema utiliza formularios Windows Forms, entidades, controlador y DataGridView para la gestión de incidencias.

## Criterios de aceptación

- El sistema permite registrar incidencias.
- Los datos aparecen correctamente en el DataGridView.
- Se puede editar una incidencia seleccionada.
- Se puede eliminar una incidencia seleccionada.
- Se puede buscar información.
- El dashboard muestra conteos generales.
- El proyecto se encuentra subido a GitHub.
- Existe al menos un Pull Request.
- Existe al menos un pipeline en GitHub Actions.
