# Especificación: Gestión de incidencias

## Descripción

El sistema DataFlow Manager permite registrar, consultar, editar y eliminar incidencias dentro de una empresa de desarrollo de software.

## Problema

La empresa presenta desorganización en el seguimiento de tareas, errores frecuentes y falta de control sobre los responsables de cada incidencia.

## Usuarios

- Administrador del proyecto
- Desarrollador
- Analista QA
- DevOps
- Project Manager

## Requisitos funcionales

### RF01 - Registrar incidencia

El sistema debe permitir registrar una incidencia con ID, título, descripción, responsable, prioridad, estado y fecha límite.

### RF02 - Seleccionar responsable

El sistema debe permitir seleccionar un trabajador responsable de una lista previamente cargada.

### RF03 - Mostrar incidencias

El sistema debe mostrar las incidencias registradas en un DataGridView.

### RF04 - Editar incidencia

El sistema debe permitir editar una incidencia seleccionada desde el DataGridView.

### RF05 - Eliminar incidencia

El sistema debe permitir eliminar una incidencia seleccionada.

### RF06 - Buscar incidencia

El sistema debe permitir buscar incidencias por título, descripción, responsable, prioridad o estado.

### RF07 - Dashboard

El sistema debe mostrar un resumen de incidencias registradas.

## Criterios de aceptación

- El usuario puede registrar una incidencia.
- El responsable se muestra correctamente.
- El DataGridView actualiza los datos.
- La edición modifica el registro seleccionado.
- La eliminación quita el registro seleccionado.
- El dashboard muestra conteos generales.
